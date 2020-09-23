using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CargaCapacitacion.ViewModels
{
    public class FichadaPantallaViewModel
    {
        public FichadaPantallaViewModel()
        {
            Cursos = new List<CursoViewModel>();
            Empleados = new List<EmpleadoViewModel>();
        }
        public String Usuario { get; set; }
        public int Curso{ get; set; }
        public List<CursoViewModel> Cursos { get; set; }
        public DateTime Fecha { get; set; }
        public List<EmpleadoViewModel> Empleados { get; set; }
    }
}
