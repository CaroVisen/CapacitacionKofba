using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CargaCapacitacion.ViewModels
{
    public class LoginViewModel
    {
        public LoginViewModel()
        {
            Zonas = new List<ZonasViewModel>();
        }
        public String? Usuario { get; set; }
        public String? Zona { get; set; }
        public List<ZonasViewModel> Zonas { get; set; }
    }
}
