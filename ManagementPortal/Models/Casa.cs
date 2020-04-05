using System.ComponentModel.DataAnnotations;

namespace CumbreAllegro2.Models
{
    public class Casa
    {
        public int Id { get; set; }

        [Display(Name = "Calle")]
        public int CalleId { get; set; }
        public Calle Calle { get; set; }
        public int Numero { get; set; }
        //public List<string> Tags { get; set; }

        [Display(Name = "Nombre Propietario")]
        public string NombrePropietario { get; set; }
        public string Correo { get; set; }

        [Display(Name = "Teléfono #1")]
        public string Telefono1 { get; set; }

        [Display(Name = "Teléfono #2")]
        public string Telefono2 { get; set; }

        [Display(Name = "Teléfono #3")]
        public string Telefono3 { get; set; }

        [Display(Name = "Acceso a cámaras")]
        public string AccesoCamaras { get; set; }
    }
}
