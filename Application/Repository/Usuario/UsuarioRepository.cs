using Application.Repository.Ldap;
using Application.Services;
using Infrastructure.Repository.Usuario.CreateUser;
using Infrastructure.Repository.Usuario.GetUserByEmail;
using Infrastructure.Repository.Usuario.GetUserByLogin;
using Infrastructure.Repository.Usuario.RecreateUser;
using Infrastructure.Repository.Usuario.UpdateToken;
using System.Threading.Tasks;

namespace Application.Repository.Usuario
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly IGetUserByLogin getUserByLogin;
        private readonly IGetUserByEmail getUserByEmail;
        private readonly ILdapRepository ldapRepository;
        private readonly ICreateUser createUser;
        private readonly IRecreateUser recreateUser;
        private readonly IUpdateToken updateToken;

        public UsuarioRepository(
            IGetUserByLogin getUserByLogin,
            IGetUserByEmail getUserByEmail,
            ILdapRepository ldapRepository,
            ICreateUser createUser,
            IUpdateToken updateToken,
            IRecreateUser recreateUser
        )
        {
            this.getUserByLogin = getUserByLogin;
            this.getUserByEmail = getUserByEmail;
            this.createUser = createUser;
            this.ldapRepository = ldapRepository;
            this.updateToken = updateToken;
            this.recreateUser = recreateUser;
        }

        public async Task<Domain.Entities.Usuario> GetUserByLogin(string login)
        {
            var user = await getUserByLogin.Execute(login);

            if (user == null)
                return null;

            if (!TokenService.ValidateToken(user.Token))
                return await updateToken.Execute(user, TokenService.GenerateToken(user));

            return user;
        }

        public async Task<Domain.Entities.Usuario> GetUserByEmail(string email)
        {
            var user = await getUserByEmail.Execute(email);

            if (user == null)
                return null;

            return user;
        }

        public async Task<bool> AuthenticateUser(string login, string senha)
        {
            return await ldapRepository.Login(login, senha);
        }

        public async Task<Domain.Entities.Usuario> CreateUser(string nome, string login, string email, int roleId)
        {
            return await createUser.Execute(nome, login, email, roleId);
        }

        public async Task<Domain.Entities.Usuario> RecreateUser(int id, string nome, string login, string email, int roleId, string token)
        {
            return await recreateUser.Execute(id, nome, login, email, roleId, token);
        }
    }
}
