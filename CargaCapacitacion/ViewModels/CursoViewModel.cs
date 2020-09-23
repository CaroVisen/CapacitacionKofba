using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CargaCapacitacion.ViewModels
{
    public class CursoViewModel
    {
        public int Id { get; set; }
        public String Curso { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
    }
}
