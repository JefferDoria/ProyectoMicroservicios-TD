using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static Gateway.Api.Routes.ApiRoutes;
using System.Collections.Generic;
using Usuarios = Gateway.Aplicacion.UsuariosClient;
using System.Threading.Tasks;
using Gateway.Aplicacion.UsuariosClient;
using System;
using Serilog;

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

        [HttpGet(RouteUsuario.GetAll)]
        public Task<ICollection<Usuarios.Usuario>> ListarUsuario()
        {
            try
            {
                var listaUsuario = _usuariosClient.ApiV1UsuarioAllAsync();
                return listaUsuario;
            }
            catch (Exception ex)
            {
                Log.Error("Exception: " + ex);
            }
            return null;
        }

        [HttpGet(RouteUsuario.GetById)]
        public Task<Usuarios.Usuario> BuscarUsuario(double id)
        {
            try
            {
                var objUsuario = _usuariosClient.ApiV1UsuarioAsync(id);
                return objUsuario;
            }
            catch (Exception ex)
            {
                Log.Error("Exception: " + ex);
            }
            return null;
        }

        [HttpPost(RouteUsuario.Create)]
        public void CrearUsuario(Usuarios.Usuario usuario)
        {
            try
            {
                _usuariosClient.ApiV1UsuarioCreateAsync(usuario);
            } catch (Exception ex)
            {
                Log.Information("Exception: " + ex);
            }
            
        }

        [HttpDelete(RouteUsuario.Delete)]
        public void EliminarUsuario(double id)
        {
            try
            {
                _usuariosClient.ApiV1UsuarioDeleteAsync(id);
            }
            catch (Exception ex)
            {
                Log.Warning("Exception: " + ex);
            }
                        
        }
    }
}
