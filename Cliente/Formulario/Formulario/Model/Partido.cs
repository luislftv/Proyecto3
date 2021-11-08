using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Formulario.Model
{

    public class Id
    {
        public int participante { get; set; }
        public int participante1 { get; set; }
        public int mesa { get; set; }
    }
    class Partido
    {

        public Id id { get; set; }
        public DateTime fecha_programada { get; set; }
        public int ganador { get; set; }
        public DateTime hora_fin { get; set; }
        public DateTime hora_inicio { get; set; }
        public int ronda { get; set; }
        public String torneo { get; set; }
    }
}
