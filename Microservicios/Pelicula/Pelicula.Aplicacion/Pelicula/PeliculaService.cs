using MongoDB.Driver;
using Release.MongoDB.Repository;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using dominio = Pelicula.Dominio.Entidades;

namespace Pelicula.Aplicacion.Pelicula
{

    public class PeliculaService : IPeliculaService
    {
        private readonly ICollectionContext<dominio.Pelicula> _pelicula;
        private readonly IBaseRepository<dominio.Pelicula> _peliculaR;

        public PeliculaService(ICollectionContext<dominio.Pelicula> pelicula, 
                                IBaseRepository<dominio.Pelicula> peliculaR)
        {
            _pelicula = pelicula;
            _peliculaR = peliculaR;
        }

        public List<dominio.Pelicula> ListarPeliculas()
        {
            Expression<Func<dominio.Pelicula, bool>> filter = s => s.esEliminado == false;
            var items = (_pelicula.Context().FindAsync(filter, null).Result).ToList();

            return items;
        }

        public bool RegistrarPelicula(dominio.Pelicula pelicula)
        {
            pelicula.esEliminado = false;
            pelicula.fechaCreacion =DateTime.Now;
            pelicula.esActivo = true;
            _peliculaR.InsertOne(pelicula);

            return true;
        }

        public dominio.Pelicula BuscarPelicula(double _id)
        {
            Expression<Func<dominio.Pelicula, bool>> filter = s => s.esEliminado == false && s.IdPelicula == _id;
            var item = (_pelicula.Context().FindAsync(filter, null).Result).FirstOrDefault();
            return item;
        }

        public bool ModificarPelicula(dominio.Pelicula pelicula)
        {
            Expression<Func<dominio.Pelicula, bool>> filter = s => s.esEliminado == false && s.IdPelicula == pelicula.IdPelicula;
            var peliculaActual = (_pelicula.Context().FindAsync(filter, null).Result).FirstOrDefault();
            return true;
        }

        public void EliminarPelicula(double _id)
        {
            Expression<Func<dominio.Pelicula, bool>> filter = s => s.esEliminado == false && s.IdPelicula == _id;
            var item = (_pelicula.Context().FindOneAndDelete(filter, null));
            
        }
    }
}
