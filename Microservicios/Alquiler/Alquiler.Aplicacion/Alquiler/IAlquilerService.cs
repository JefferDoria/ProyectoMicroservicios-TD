using System.Collections.Generic;
using dominio = Usuario.Dominio.Entidades;

namespace Usuario.Aplicacion.Usuario
{
    public interface IUsuarioService
    {
        List<dominio.Usuario> ListarUsuarios();
        bool RegistrarUsuario(dominio.Usuario usuario);
        dominio.Usuario BuscarUsuario(double _id);
        bool ModificarUsuario(dominio.Usuario usuario);
        void EliminarUsuario(double _id);
    }
}
