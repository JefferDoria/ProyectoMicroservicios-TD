using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gateway.Aplicacion.Alquileres.Request
{
    public class RegistrarAlquilerRequest
    {
        public double IdAlquiler { get; set; }
        public double IdPelicula { get; set; }
        public double IdUsuario{ get; set; }
        public string FecInicio { get; set; }
        public string FecFin { get; set; }
    }
}
