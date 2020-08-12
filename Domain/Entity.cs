using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public abstract class Entity
    {
        public int Id { get; set; }
        public bool Ativo { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime? DataAtualizacao { get; set; }
    }
}
