using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicioRecordatorio
{
    public class Persona
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string email { get; set; }
        // public string fCreacion { get; set; }
       // public string fRecuerdo { get; set; }
        public string envioEmail { get; set; }
    }
}
