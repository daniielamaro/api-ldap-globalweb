using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository.SolicitacaoCadastro.Create
{
    public interface ICreateSolicitacao
    {
        Task<Domain.Entities.SolicitacaoCadastro> Execute(string nome, string email, string motivo);
    }
}
