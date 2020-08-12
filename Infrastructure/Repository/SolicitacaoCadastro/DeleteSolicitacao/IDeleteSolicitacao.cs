using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository.SolicitacaoCadastro.DeleteSolicitacao
{
    public interface IDeleteSolicitacao
    {
        Task Execute(Domain.Entities.SolicitacaoCadastro solicitacao);
    }
}
