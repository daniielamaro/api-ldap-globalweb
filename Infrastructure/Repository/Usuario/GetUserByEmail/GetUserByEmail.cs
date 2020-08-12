using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Repository.Usuario.GetUserByEmail
{
    public class GetUserByEmail : IGetUserByEmail
    {
        public async Task<Domain.Entities.Usuario> Execute(string email)
        {
            using var context = new ApiContext();

            var user = await context.Usuarios
                .Include(x => x.Role)
                .Where(x => x.Email.ToLower() == email.ToLower())
                .SingleOrDefaultAsync();

            return user;
        }
    }
}
