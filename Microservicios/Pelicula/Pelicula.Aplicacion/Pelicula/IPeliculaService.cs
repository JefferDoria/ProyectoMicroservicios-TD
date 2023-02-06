using System.Collections.Generic;
using dominio = Pelicula.Dominio.Entidades;

namespace Pelicula.Aplicacion.Pelicula
{
    public interface IPeliculaService
    {
        List<dominio.Pelicula> ListarPeliculas();
        bool RegistrarPelicula(dominio.Pelicula pelicula);
        dominio.Pelicula BuscarPelicula(double _id);
        bool ModificarPelicula(dominio.Pelicula pelicula);
        void EliminarPelicula(double _id);
    }
}
