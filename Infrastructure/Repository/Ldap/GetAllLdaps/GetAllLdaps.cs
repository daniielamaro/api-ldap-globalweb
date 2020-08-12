using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Repository.Ldap.GetAllLdaps
{
    public class GetAllLdaps : IGetAllLdaps
    {
        public async Task<List<Domain.Entities.Ldap>> Execute()
        {
            using var context = new ApiContext();

            return await context.Ldaps.AsNoTracking().Where(x => x.Ativo).ToListAsync();
        }
    }
}
