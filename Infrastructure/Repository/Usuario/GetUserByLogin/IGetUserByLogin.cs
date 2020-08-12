using System.Threading.Tasks;

namespace Infrastructure.Repository.Usuario.GetUserByLogin
{
    public interface IGetUserByLogin
    {
        Task<Domain.Entities.Usuario> Execute(string login);
    }
}
