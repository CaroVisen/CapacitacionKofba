using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CargaCapacitacion.Models
{
    public class trans
    {
        [Key]
        public int curso { get; set; }
        public List<int> usuarios { get; set; }
        public string fecha { get; set; }

    }
}
