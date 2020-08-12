using System.Threading.Tasks;
using Application.Repository.Ldap;
using Application.Repository.SolicitacaoCadastro;
using Application.Repository.Usuario;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Prs.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SolicitacaoCadastroController : ControllerBase
    {
        private readonly ISolicitacaoCadastroRespository solicitacaoCadastroRespository;
        private readonly IUsuarioRepository usuarioRepository;
        private readonly ILdapRepository ldapRepository;

        public SolicitacaoCadastroController(
            ISolicitacaoCadastroRespository solicitacaoCadastroRespository,
            IUsuarioRepository usuarioRepository,
            ILdapRepository ldapRepository
        )
        {
            this.solicitacaoCadastroRespository = solicitacaoCadastroRespository;
            this.usuarioRepository = usuarioRepository;
            this.ldapRepository = ldapRepository;
        }

        [HttpPost("CreateSolicitacao")]
        [AllowAnonymous]
        public async Task<IActionResult> CreateSolicitacao(string nome, string email, string motivo)
            => Ok(await solicitacaoCadastroRespository.CreateSolicitacao(nome, email, motivo));

        [HttpPost("GetAll")]
        [Authorize(Roles = "administrador,licitacao")]
        public async Task<IActionResult> GetAll()
            => Ok(await solicitacaoCadastroRespository.GetAll());

        [HttpPost("AutorizarSolicitacao")]
        [Authorize]
        public async Task<IActionResult> AutorizarSolicitacao(int id, string login, string senha, int roleId)
        {
            if (!await usuarioRepository.AuthenticateUser(login, senha))
                return Unauthorized("Usuario ou senha invalidos");

            var solicitacao = await solicitacaoCadastroRespository.GetById(id);

            var userLdap = await ldapRepository.GetUser(login, senha, solicitacao.Email);

            if (userLdap == null && solicitacao.Email.Contains(".com.br"))
                userLdap = await ldapRepository.GetUser(login, senha, solicitacao.Email.Replace(".com.br", ".cloud"));

            if (userLdap == null && solicitacao.Email.Contains(".cloud"))
                userLdap = await ldapRepository.GetUser(login, senha, solicitacao.Email.Replace(".cloud", ".com.br"));

            if (userLdap == null)
                return NotFound("Não foi encontrado um funcionário com esse email");

            var verifyUsuario = await usuarioRepository.GetUserByEmail(solicitacao.Email);

            if (verifyUsuario == null && solicitacao.Email.Contains(".com.br"))
                verifyUsuario = await usuarioRepository.GetUserByEmail(solicitacao.Email.Replace(".com.br", ".cloud"));

            if (verifyUsuario == null && solicitacao.Email.Contains(".cloud"))
                verifyUsuario = await usuarioRepository.GetUserByEmail(solicitacao.Email.Replace(".cloud", ".com.br"));

            if (verifyUsuario == null)
                await usuarioRepository.CreateUser(userLdap.Name, userLdap.Login, userLdap.Email, roleId);
            else if (verifyUsuario != null)
                await usuarioRepository.RecreateUser(verifyUsuario.Id, userLdap.Name, userLdap.Login, userLdap.Email, roleId, verifyUsuario.Token);

            await solicitacaoCadastroRespository.Delete(solicitacao);

            return Ok(solicitacao);
        }

        [HttpPost("NaoAutorizarSolicitacao")]
        [Authorize]
        public async Task<IActionResult> NaoAutorizarSolicitacao(int id)
        {
            var solicitacao = await solicitacaoCadastroRespository.GetById(id);

            await solicitacaoCadastroRespository.Delete(solicitacao);

            return Ok(solicitacao);
        }

    }
}
