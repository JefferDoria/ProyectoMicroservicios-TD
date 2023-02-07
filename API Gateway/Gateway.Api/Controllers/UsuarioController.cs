using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static Gateway.Api.Routes.ApiRoutes;
using System.Collections.Generic;
using Usuarios = Gateway.Aplicacion.UsuariosClient;
using System.Threading.Tasks;
using Gateway.Aplicacion.UsuariosClient;

namespace Gateway.Api.Controllers
{
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly Usuarios.IClient _usuariosClient;

        public UsuarioController(Usuarios.IClient usuariosClient)
        {
            _usuariosClient = usuariosClient;
        }

        [HttpGet(RoutePelicula.GetAll)]
        public Task<ICollection<Usuarios.Usuario>> ListarUsuario()
        {
            var listaUsuario = _usuariosClient.ApiV1UsuarioAllAsync();
            return listaUsuario;
        }

        [HttpGet(RouteUsuario.GetById)]
        public Task<Usuarios.Usuario> BuscarUsuario(double id)
        {
            var objPelicula = _usuariosClient.ApiV1UsuarioAsync(id);
            return objPelicula;
        }

        [HttpPost(RoutePelicula.Create)]
        public ActionResult<Task<Usuarios.Usuario>> CrearPelicula(Usuarios.Usuario usuario)
        {
            _usuariosClient.ApiV1UsuarioCreateAsync(usuario);

            return Ok();
        }

        [HttpDelete(RouteUsuario.Delete)]
        public ActionResult<Task<Usuarios.Usuario>> EliminarUsuario(double id)
        {
            _usuariosClient.ApiV1UsuarioDeleteAsync(id);
            return Ok(id);
        }
    }
}
