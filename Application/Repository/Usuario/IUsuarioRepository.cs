using System.Threading.Tasks;

namespace Application.Repository.Usuario
{
    public interface IUsuarioRepository
    {
        Task<bool> AuthenticateUser(string login, string senha);
        Task<Domain.Entities.Usuario> GetUserByLogin(string login);
        Task<Domain.Entities.Usuario> GetUserByEmail(string email);
        Task<Domain.Entities.Usuario> CreateUser(string nome, string login, string email, int roleId);
        Task<Domain.Entities.Usuario> RecreateUser(int id, string nome, string login, string email, int roleId, string token);
    }
}
