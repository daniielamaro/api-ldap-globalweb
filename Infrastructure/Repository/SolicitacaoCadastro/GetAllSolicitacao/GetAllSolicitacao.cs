using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository.SolicitacaoCadastro.GetAllSolicitacao
{
    public class GetAllSolicitacao : IGetAllSolicitacao
    {
        public async Task<List<Domain.Entities.SolicitacaoCadastro>> Execute()
        {
            using var context = new ApiContext();

            return await context.SolicitacoesCadastros.AsNoTracking().ToListAsync();
        }
    }
}
