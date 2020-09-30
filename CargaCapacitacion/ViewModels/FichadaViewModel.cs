using System;
using System.Collections.Generic;

namespace CargaCapacitacion.ViewModels
{
    public class FichadaViewModel
    {
        public FichadaViewModel()
        {
            Cursos = new List<CursoViewModel>();
            Empleados = new List<EmpleadoViewModel>();
        }
        public string Usuario { get; set; }
        public int Curso{ get; set; }
        public List<CursoViewModel> Cursos { get; set; }
        public DateTime Fecha { get; set; }
        public List<EmpleadoViewModel> Empleados { get; set; }
    }
}
