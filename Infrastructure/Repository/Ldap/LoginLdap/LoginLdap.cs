using Microsoft.EntityFrameworkCore;
using Novell.Directory.Ldap;
using System.Threading.Tasks;

namespace Infrastructure.Repository.Ldap.LoginLdap
{
    public class LoginLdap : ILoginLdap
    {
        private readonly ApiContext context;

        public LoginLdap()
        {
            context = new ApiContext();
        }

        public async Task<bool> Execute(string username, string password)
        {
            var configs = await context.Ldaps.ToListAsync();
            var connection = new LdapConnection();

            foreach (var ldap in configs)
            {
                try
                {
                    connection.Connect(ldap.Host, 389);
                    connection.Bind($@"{ldap.Dominio}\{username}", password);

                    var searchFilter = $@"(samaccountname={username})";
                    var result = connection.Search(
                        ldap.BaseDn,
                        LdapConnection.ScopeSub,
                        searchFilter,
                        new[] { "name", "mail", "samaccountname" },
                        false
                    );

                    var user = result.Next();
                    if (user != null)
                    {
                        connection.Bind(user.Dn, password);
                        if (connection.Bound)
                        {
                            return true;
                        }
                    }
                }
                catch { }
            }

            connection.Disconnect();
            return false;
        }
    }
}
