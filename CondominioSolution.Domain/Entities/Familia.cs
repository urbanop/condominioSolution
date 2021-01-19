using System;
using System.Collections.Generic;
using System.Text;

namespace CondominioSolution.Domain.Entities
{
    public class Familia :AggregateRoot
    {
        public string Nome { get;  set; }
        public int Id_Condominio { get;  set; }
        public string Apto { get;  set; }

        public virtual Condominio Condominio { get; set; }
        public virtual ICollection<Morador> Moradores { get; set; }

    }
}
