using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Formulario.Model
{
    class Participante
    {


        public int id { get; set; }
        public string apodo { get; set; }
        public DateTime fecha_inscripcion { get; set; }
        public DateTime fecha_caducidad { get; set; }

        
    }
}
