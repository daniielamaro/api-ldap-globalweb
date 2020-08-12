using System.Threading.Tasks;

namespace Infrastructure.Repository.Ldap.LoginLdap
{
    public interface ILoginLdap
    {
        Task<bool> Execute(string username, string password);
    }
}
