using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CargaCapacitacion.Models
{
    public class Fichada
    {
        public int Curso { get; set; }

        public int Tarjeta { get; set; }

        public int Documento { get; set; }

        public DateTime Fecha { get; set; }

        public bool FichadaManual { get; set; }

    }
}
