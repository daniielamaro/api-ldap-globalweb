using Infrastructure.Repository.Role.GetAllRole;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Repository.Role
{
    public class RoleRepository : IRoleRepository
    {
        private readonly IGetAllRole getAllRole;

        public RoleRepository(IGetAllRole getAllRole)
        {
            this.getAllRole = getAllRole;
        }

        public async Task<List<Domain.Entities.Role>> GetAllRole()
        {
            return await getAllRole.Execute();
        }
    }
}
