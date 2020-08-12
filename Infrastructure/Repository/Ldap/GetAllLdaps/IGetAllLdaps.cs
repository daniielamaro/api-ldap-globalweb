using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Repository.Ldap.GetAllLdaps
{
    public interface IGetAllLdaps
    {
        Task<List<Domain.Entities.Ldap>> Execute();
    }
}
