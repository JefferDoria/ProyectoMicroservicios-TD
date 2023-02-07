using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gateway.Aplicacion.Alquileres.Request
{
    public class RegistrarAlquilerRequest
    {
        public int IdAlquiler { get; set; }
        public int IdPelicula { get; set; }
        public int IdUsuario{ get; set; }
        public string FecInicio { get; set; }
        public string FecFin { get; set; }
    }
}
