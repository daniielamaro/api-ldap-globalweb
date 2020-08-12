using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository.SolicitacaoCadastro.DeleteSolicitacao
{
    public interface IDeleteSolicitacao
    {
        Task<Domain.Entities.SolicitacaoCadastro> Execute(int id);
    }
}
