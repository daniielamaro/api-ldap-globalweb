using System.Threading.Tasks;

namespace Infrastructure.Repository.Usuario.CreateUser
{
    public interface ICreateUser
    {
        Task<Domain.Entities.Usuario> Execute(string nome, string login, string email, int roleId);
    }
}
