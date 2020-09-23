using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CargaCapacitacion.Models
{
    public class Curso
    {
        public int Id { get; set; }
        public String Codigo { get; set; }
        public String Titulo { get; set; }
        public int Institucion { get; set; }
        public String Instructor { get; set; }
        public DateTime FechaInicio{ get; set; }
        public DateTime FechaFin { get; set; }
        public String Lugar { get; set; }
        public int CargaHoraria { get; set; }
        public int CargaDiaria { get; set; }
        public int MinimoAprobar { get; set; }
        public int CupoMaximo { get; set; }
        public int CupoMinimo { get; set; }
        public decimal Costo { get; set; }
        public decimal CostoIndirecto { get; set; }
        public String Logistica{ get; set; }
        public bool PreTest{ get; set; }
        public bool PostTest{ get; set; }
        public bool Certifica{ get; set; }
        public bool Habilitado{ get; set; }
        public bool Cancelado { get; set; }
        public String CreadoPor{ get; set; }

    }
}
