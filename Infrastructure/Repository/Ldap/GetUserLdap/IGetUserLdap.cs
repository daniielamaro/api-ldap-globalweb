using Domain.Entities;
using System.Threading.Tasks;

namespace Infrastructure.Repository.Ldap.GetUserLdap
{
    public interface IGetUserLdap
    {
        Task<UserLdap> Execute(string username, string password, string userTarget);
    }
}
