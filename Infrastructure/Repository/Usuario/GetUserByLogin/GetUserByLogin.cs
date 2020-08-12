using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Repository.Usuario.GetUserByLogin
{
    public class GetUserByLogin : IGetUserByLogin
    {
        public async Task<Domain.Entities.Usuario> Execute(string login)
        {
            using var context = new ApiContext();

            var user = await context.Usuarios
                .Include(x => x.Role)
                .AsNoTracking()
                .Where(x => x.Ativo && x.Login.ToLower() == login.ToLower())
                .SingleOrDefaultAsync();

            return user;
        }
    }
}
