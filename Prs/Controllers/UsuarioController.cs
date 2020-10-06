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

        [HttpPost("TesteBuild1")]
        [AllowAnonymous]
        public async Task<IActionResult> TesteBuild1(string login, string senha)
        {
            if (!await usuarioRepository.AuthenticateUser(login, senha))
                return Unauthorized("Usuario ou senha invalidos");

            var user = await usuarioRepository.GetUserByLogin(login);

            if (user == null)
                return NotFound("Usuario não cadastrado na Cental de Licitações.");

            return Ok(user);
        }

    }
}
