using Infrastructure.Repository.SolicitacaoCadastro.Create;
using Infrastructure.Repository.SolicitacaoCadastro.DeleteSolicitacao;
using Infrastructure.Repository.SolicitacaoCadastro.GetAllSolicitacao;
using Infrastructure.Repository.SolicitacaoCadastro.GetByIdSolicitacao;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Repository.SolicitacaoCadastro
{
    public class SolicitacaoCadastroRepository : ISolicitacaoCadastroRespository
    {
        private readonly ICreateSolicitacao create;
        private readonly IGetAllSolicitacao getAll;
        private readonly IGetByIdSolicitacao getById;
        private readonly IDeleteSolicitacao delete;

        public SolicitacaoCadastroRepository(
            ICreateSolicitacao create,
            IGetAllSolicitacao getAll,
            IGetByIdSolicitacao getById,
            IDeleteSolicitacao delete
        )
        {
            this.create = create;
            this.getAll = getAll;
            this.getById = getById;
            this.delete = delete;
        }

        public async Task<Domain.Entities.SolicitacaoCadastro> CreateSolicitacao(string nome, string email, string motivo) => await create.Execute(nome, email, motivo);
        public async Task<List<Domain.Entities.SolicitacaoCadastro>> GetAll() => await getAll.Execute();
        public async Task<Domain.Entities.SolicitacaoCadastro> GetById(int id) => await getById.Execute(id);
        public async Task<Domain.Entities.SolicitacaoCadastro> Delete(int id) => await delete.Execute(id);

    }
}
