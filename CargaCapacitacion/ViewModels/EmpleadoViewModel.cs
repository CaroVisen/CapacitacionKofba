using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CargaCapacitacion.ViewModels
{
    public class EmpleadoViewModel
    {
        public string Legajo { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public bool IsChecked { get; set; }
    }
}
