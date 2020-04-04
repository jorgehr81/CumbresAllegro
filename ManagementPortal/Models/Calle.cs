using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CumbreAllegro2.Models
{
    public class Calle
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        public int ColoniaId { get; set; }
        public Colonia Colonia { get; set; }
        public string Referencia { get; set; }
    }
}
