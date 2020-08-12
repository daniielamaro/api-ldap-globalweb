using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Repository.SolicitacaoCadastro.Create
{
    public class CreateSolicitacao : ICreateSolicitacao
    {
        public async Task<Domain.Entities.SolicitacaoCadastro> Execute(string nome, string email, string motivo)
        {
            using var context = new ApiContext();

            var verify = await context.SolicitacoesCadastros.AsNoTracking().Where(x => x.Email == email).FirstOrDefaultAsync();
            if (verify != null)
                return null;

            var solicitacao = new Domain.Entities.SolicitacaoCadastro
            {
                Name = nome,
                Email = email,
                Motivo = motivo,
                Ativo = true,
                DataCriacao = DateTime.Now,
                DataAtualizacao = DateTime.Now
            };

            await context.SolicitacoesCadastros.AddAsync(solicitacao);
            await context.SaveChangesAsync();

            return solicitacao;
        }
    }
}
