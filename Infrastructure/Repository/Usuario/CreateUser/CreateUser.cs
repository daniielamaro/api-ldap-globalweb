using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Repository.Usuario.CreateUser
{
    public class CreateUser : ICreateUser
    {
        public async Task<Domain.Entities.Usuario> Execute(string nome, string login, string email, int roleId)
        {
            using var context = new ApiContext();

            var usuarioNew = new Domain.Entities.Usuario
{
                Nome = nome.ToUpper(),
                Login = login.ToLower(),
                Email = email.ToLower(),
                Role = await context.Roles.Where(x => x.Id == roleId).SingleOrDefaultAsync(),
                Token = "",
                Ativo = true,
                DataCriacao = DateTime.Now
            };

            context.Usuarios.Add(usuarioNew);
            await context.SaveChangesAsync();

            return usuarioNew;
        }
    }
}
