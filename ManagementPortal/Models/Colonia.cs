using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CumbreAllegro2.Models
{
    public class Colonia
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Sector { get; set; }

        [Display(Name = "Código Postal")]
        public int CodigoPostal { get; set; }

        [Display(Name = "Cargo Mensual")]
        [Column(TypeName = "money")]
        public decimal CargoMensual { get; set; }
    }
}