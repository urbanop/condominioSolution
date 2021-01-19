using System;
using System.Collections.Generic;
using System.Text;

namespace CondominioSolution.Domain.Entities
{
    public class Morador :AggregateRoot
    {
        public int Id_Familia { get; set; }
        public string Nome { get; set; }
        public int QuantidadeBichosEstimacao { get; set; }
        public virtual Familia Familia { get; set; }
    }
}
