using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class SolicitacaoCadastro : Entity
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Motivo { get; set; }
    }
}
