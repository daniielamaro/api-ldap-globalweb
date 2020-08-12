using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository.SolicitacaoCadastro.DeleteSolicitacao
{
    public class DeleteSolicitacao : IDeleteSolicitacao
    {
        public async Task Execute(Domain.Entities.SolicitacaoCadastro solicitacao)
        {
            using var context = new ApiContext();

            context.SolicitacoesCadastros.Remove(solicitacao);
            await context.SaveChangesAsync();
        }
    }
}
