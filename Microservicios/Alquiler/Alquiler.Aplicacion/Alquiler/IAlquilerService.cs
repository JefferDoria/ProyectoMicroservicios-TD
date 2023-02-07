using System.Collections.Generic;
using dominio = Alquiler.Dominio.Entidades;

namespace Alquiler.Aplicacion.Usuario
{
    public interface IAlquilerService
    {
        List<dominio.Alquiler> ListarAlquiler();
        bool RegistrarAlquiler(dominio.Alquiler alquiler);
        dominio.Alquiler BuscarAlquiler(double _id);
        bool ModificarAlquiler(dominio.Alquiler alquiler);
        void EliminarAlquiler(double _id);
    }
}
