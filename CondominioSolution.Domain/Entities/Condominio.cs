using System;
using System.Collections.Generic;
using System.Text;

namespace CondominioSolution.Domain.Entities
{
    public class Condominio : AggregateRoot
    {
        public string Nome { get; set; }
        public string Bairro { get; set; }

        public virtual ICollection<Familia> Familias { get; set; }
    }
}
