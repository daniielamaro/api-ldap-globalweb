using System.Threading.Tasks;

namespace Infrastructure.Repository.Usuario.GetUserByEmail
{
    public interface IGetUserByEmail
    {
        Task<Domain.Entities.Usuario> Execute(string email);
    }
}
