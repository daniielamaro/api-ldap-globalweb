using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Prs.Controllers.Request;
using System.Threading.Tasks;
using Application.Repository.Usuario;
using Infrastructure.Repository.Ldap.GetUserLdap;
using Application.Repository.Ldap;

namespace Prs.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepository usuarioRepository;
        private readonly ILdapRepository ldapRepository;

        public UsuarioController(IUsuarioRepository usuarioRepository, ILdapRepository ldapRepository)
        {
            this.usuarioRepository = usuarioRepository;
            this.ldapRepository = ldapRepository;
        }

        [HttpPost("Login")]
        [AllowAnonymous]
        public async Task<IActionResult> Autenticar(string login, string senha)
        {
            if (!await usuarioRepository.AuthenticateUser(login, senha))
                return Unauthorized("Usuario ou senha invalidos");

            var user = await usuarioRepository.GetUserByLogin(login);

            if (user == null)
                return NotFound("Usuario não cadastrado na Cental de Licitações.");

            return Ok(user);
        }

        [HttpPost("Create")]
        [Authorize(Roles = "licitacao,administrador")]
        public async Task<IActionResult> Create(string login, string senha, UsuarioRequestCreate usuario)
        {
            if (!await usuarioRepository.AuthenticateUser(login, senha))
                return Unauthorized("Usuario ou senha invalidos");

            var userLdap = await ldapRepository.GetUser(login, senha, usuario.Email);

            if (userLdap == null && usuario.Email.Contains(".com.br"))
                userLdap = await ldapRepository.GetUser(login, senha, usuario.Email.Replace(".com.br", ".cloud"));

            if (userLdap == null && usuario.Email.Contains(".cloud"))
                userLdap = await ldapRepository.GetUser(login, senha, usuario.Email.Replace(".cloud", ".com.br"));

            if (userLdap == null)
                return NotFound("Não foi encontrado um funcionário com esse email");

            var verifyUsuario = await usuarioRepository.GetUserByEmail(usuario.Email);

            if (verifyUsuario == null && usuario.Email.Contains(".com.br"))
                verifyUsuario = await usuarioRepository.GetUserByEmail(usuario.Email.Replace(".com.br", ".cloud"));

            if (verifyUsuario == null && usuario.Email.Contains(".cloud"))
                verifyUsuario = await usuarioRepository.GetUserByEmail(usuario.Email.Replace(".cloud", ".com.br"));

            return verifyUsuario == null ?
                    Ok(await usuarioRepository.CreateUser(userLdap.Name, userLdap.Login, userLdap.Email, usuario.RoleId)) :
                    Ok(await usuarioRepository.RecreateUser(verifyUsuario.Id, userLdap.Name, userLdap.Login, userLdap.Email, usuario.RoleId, verifyUsuario.Token));
        }
    }
}
