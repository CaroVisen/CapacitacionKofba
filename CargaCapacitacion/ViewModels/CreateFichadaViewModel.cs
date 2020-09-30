using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CargaCapacitacion.ViewModels
{
    public class CreateFichadaViewModel
    {
        [Key]
        public int Curso { get; set; }
        public string Fecha { get; set; }
        public List<string> Usuarios { get; set; }
    }
}
