using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Repository.Role
{
    public interface IRoleRepository
    {
        Task<List<Domain.Entities.Role>> GetAllRole();
    }
}
