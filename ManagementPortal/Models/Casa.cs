using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CumbreAllegro2.Models
{
    public class Casa
    {
        public int Id { get; set; }
        public int Numero { get; set; }
        //public List<string> Tags { get; set; }

        public string NombrePropietario { get; set; }
        public string Correo { get; set; }
        public string Telefono1 { get; set; }
        public string Telefono2 { get; set; }
        public string Telefono3 { get; set; }
        public string AccesoCamaras { get; set; }
    }
}
