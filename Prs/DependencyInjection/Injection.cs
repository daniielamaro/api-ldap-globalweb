using Application.Repository.Ldap;
using Application.Repository.Role;
using Application.Repository.SolicitacaoCadastro;
using Application.Repository.Usuario;
using Infrastructure.Repository.Ldap.GetAllLdaps;
using Infrastructure.Repository.Ldap.GetUserLdap;
using Infrastructure.Repository.Ldap.LoginLdap;
using Infrastructure.Repository.Role.GetAllRole;
using Infrastructure.Repository.SolicitacaoCadastro.Create;
using Infrastructure.Repository.SolicitacaoCadastro.DeleteSolicitacao;
using Infrastructure.Repository.SolicitacaoCadastro.GetAllSolicitacao;
using Infrastructure.Repository.SolicitacaoCadastro.GetByIdSolicitacao;
using Infrastructure.Repository.Usuario.CreateUser;
using Infrastructure.Repository.Usuario.GetUserByEmail;
using Infrastructure.Repository.Usuario.GetUserByLogin;
using Infrastructure.Repository.Usuario.RecreateUser;
using Infrastructure.Repository.Usuario.UpdateToken;
using Microsoft.Extensions.DependencyInjection;

namespace Prs.DependencyInjection
{
    public static class Injection
    {
        public static void Execute(IServiceCollection services)
        {
            Infrastructure(services);
            Application(services);
        }

        public static void Application(IServiceCollection services)
        {
            services.AddSingleton<ILdapRepository, LdapRepository>();
            services.AddSingleton<IUsuarioRepository, UsuarioRepository>();
            services.AddSingleton<IRoleRepository, RoleRepository>();
            services.AddSingleton<ISolicitacaoCadastroRespository, SolicitacaoCadastroRepository>();
        }

        public static void Infrastructure(IServiceCollection services)
        {
            services.AddSingleton<IGetUserByLogin, GetUserByLogin>();
            services.AddSingleton<IGetUserByEmail, GetUserByEmail>();
            services.AddSingleton<IUpdateToken, UpdateToken>();
            services.AddSingleton<IRecreateUser, RecreateUser>();
            services.AddSingleton<ICreateUser, CreateUser>();

            services.AddSingleton<IGetAllRole, GetAllRole>();

            services.AddSingleton<ILoginLdap, LoginLdap>();
            services.AddSingleton<IGetUserLdap, GetUserLdap>();
            services.AddSingleton<IGetAllLdaps, GetAllLdaps>();

            services.AddSingleton<ICreateSolicitacao, CreateSolicitacao>();
            services.AddSingleton<IGetAllSolicitacao, GetAllSolicitacao>();
            services.AddSingleton<IGetByIdSolicitacao, GetByIdSolicitacao>();
            services.AddSingleton<IDeleteSolicitacao, DeleteSolicitacao>();
        }
        
    }
}
