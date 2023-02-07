using MongoDB.Driver;
using Release.MongoDB.Repository;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using dominio = Usuario.Dominio.Entidades;

namespace Usuario.Aplicacion.Usuario
{

    public class UsuarioService : IUsuarioService
    {
        private readonly ICollectionContext<dominio.Usuario> _usuario;
        private readonly IBaseRepository<dominio.Usuario> _usuarioR;

        public UsuarioService(ICollectionContext<dominio.Usuario> usuario,
                                IBaseRepository<dominio.Usuario> usuarioR)
        {
            _usuario = usuario;
            _usuarioR = usuarioR;
        }

        public List<dominio.Usuario> ListarUsuarios()
        {
            Expression<Func<dominio.Usuario, bool>> filter = s => s.esEliminado == false;
            var items = (_usuario.Context().FindAsync(filter, null).Result).ToList();

            return items;
        }

        public bool RegistrarUsuario(dominio.Usuario usuario)
        {
            usuario.esEliminado = false;
            usuario.fechaCreacion = DateTime.Now;
            usuario.esActivo = true;
            _usuarioR.InsertOne(usuario);

            return true;
        }

        public dominio.Usuario BuscarUsuario(double _id)
        {
            Expression<Func<dominio.Usuario, bool>> filter = s => s.esEliminado == false && s.IdUsuario == _id;
            var item = (_usuario.Context().FindAsync(filter, null).Result).FirstOrDefault();
            return item;
        }

        public bool ModificarUsuario(dominio.Usuario usuario)
        {
            Expression<Func<dominio.Usuario, bool>> filter = s => s.esEliminado == false && s.IdUsuario == usuario.IdUsuario;
            var usuarioActual = (_usuario.Context().FindAsync(filter, null).Result).FirstOrDefault();
            return true;
        }

        public void EliminarUsuario(double _id)
        {
            Expression<Func<dominio.Usuario, bool>> filter = s => s.esEliminado == false && s.IdUsuario == _id;
            var item = (_usuario.Context().FindOneAndDelete(filter, null));

        }
    }
}

       