using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Repository.SolicitacaoCadastro
{
    public interface ISolicitacaoCadastroRespository
    {
        Task<Domain.Entities.SolicitacaoCadastro> CreateSolicitacao(string nome, string email, string motivo);
        Task<List<Domain.Entities.SolicitacaoCadastro>> GetAll();
        Task<Domain.Entities.SolicitacaoCadastro> GetById(int id);
        Task Delete(Domain.Entities.SolicitacaoCadastro solicitacao);
    }
}
