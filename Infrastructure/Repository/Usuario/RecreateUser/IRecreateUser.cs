using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository.Usuario.RecreateUser
{
    public interface IRecreateUser
    {
        Task<Domain.Entities.Usuario> Execute(int id, string nome, string login, string email, int roleId, string token);
    }
}
