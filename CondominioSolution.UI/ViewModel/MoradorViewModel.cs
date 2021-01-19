using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CondominioSolution.UI.ViewModel
{
    public class MoradorViewModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "A Família do morador é requerida")]
        public int Id_Familia { get; set; }

        [Required(ErrorMessage ="O Nome do morador é requerido")]
        public string Nome { get; set; }

        [Display(Name ="Qtde de Bichos de Estimação")]
        public int QuantidadeBichosEstimacao { get; set; }
        public  string Familia { get; set; }

        [Display(Name = "Condomínio")]
        public string Condominio { get; set; }
        public string Bairro { get; set; }

    }
}
