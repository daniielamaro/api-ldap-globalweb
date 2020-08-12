using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Repository.Role.GetAllRole
{
    public interface IGetAllRole
    {
        Task<List<Domain.Entities.Role>> Execute();
    }
}
