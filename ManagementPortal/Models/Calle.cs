using System.ComponentModel.DataAnnotations;

namespace CumbreAllegro2.Models
{
    public class Calle
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        [Display(Name = "Colonia")]
        public int ColoniaId { get; set; }
        public Colonia Colonia { get; set; }
        public string Referencia { get; set; }
    }
}
