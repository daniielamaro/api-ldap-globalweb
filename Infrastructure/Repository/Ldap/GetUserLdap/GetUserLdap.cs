using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Novell.Directory.Ldap;
using System.Threading.Tasks;

namespace Infrastructure.Repository.Ldap.GetUserLdap
{
    public class GetUserLdap : IGetUserLdap
    {
        private readonly ApiContext context;

        public GetUserLdap()
        {
            context = new ApiContext();
        }

        public async Task<UserLdap> Execute(string username, string password, string userTarget)
        {
            var configs = await context.Ldaps.ToListAsync();
            var connection = new LdapConnection();

            foreach (var ldap in configs)
            {
                try
                {
                    connection.Connect(ldap.Host, 389);
                    connection.Bind($@"{ldap.Dominio}\{username}", password);

                    var searchFilter = $@"(mail={userTarget})";
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
                        if (connection.Bound)
                        {
                            return new UserLdap
                            {
                                Login = user.GetAttribute("samaccountname").StringValue,
                                Email = user.GetAttribute("mail").StringValue,
                                Name = user.GetAttribute("name").StringValue
                            };
                        }
                    }
                }
                catch { }
            }

            connection.Disconnect();
            return null;
        }
    }
}
