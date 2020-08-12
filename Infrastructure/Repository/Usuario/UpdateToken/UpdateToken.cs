using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository.Usuario.UpdateToken
{
    public class UpdateToken : IUpdateToken
    {
        public async Task<Domain.Entities.Usuario> Execute(Domain.Entities.Usuario user, string token)
        {
            using var context = new ApiContext(); 

            user.Token = token;
            user.DataAtualizacao = DateTime.Now;
            context.Usuarios.Update(user);
            await context.SaveChangesAsync();

            return user;
        }
    }
}
