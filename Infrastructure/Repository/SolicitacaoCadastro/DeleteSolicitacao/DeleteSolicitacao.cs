using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository.SolicitacaoCadastro.DeleteSolicitacao
{
    public class DeleteSolicitacao : IDeleteSolicitacao
    {
        public async Task<Domain.Entities.SolicitacaoCadastro> Execute(int id)
        {
            using var context = new ApiContext();

            var solicitacao = await context.SolicitacoesCadastros.FindAsync(id);

            context.SolicitacoesCadastros.Remove(solicitacao);
            await context.SaveChangesAsync();

            return solicitacao;
        }
    }
}
