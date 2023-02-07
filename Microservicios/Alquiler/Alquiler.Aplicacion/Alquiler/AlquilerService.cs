using Alquiler.Aplicacion.Usuario;
using MongoDB.Driver;
using Release.MongoDB.Repository;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using dominio = Alquiler.Dominio.Entidades;

namespace Alquiler.Aplicacion.Alquiler
{

    public class AlquilerService : IAlquilerService
    {
        private readonly ICollectionContext<dominio.Alquiler> _alquiler;
        private readonly IBaseRepository<dominio.Alquiler> _alquilerR;

        public AlquilerService(ICollectionContext<dominio.Alquiler> alquiler,
                                IBaseRepository<dominio.Alquiler> alquilerR)
        {
            _alquiler = alquiler;
            _alquilerR = alquilerR;
        }

        public List<dominio.Alquiler> ListarAlquiler()
        {
            Expression<Func<dominio.Alquiler, bool>> filter = s => s.esEliminado == false;
            var items = (_alquiler.Context().FindAsync(filter, null).Result).ToList();

            return items;
        }

        public bool RegistrarAlquiler(dominio.Alquiler alquiler)
        {
            alquiler.esEliminado = false;
            alquiler.fechaCreacion = DateTime.Now;
            alquiler.esActivo = true;
            _alquilerR.InsertOne(alquiler);

            return true;
        }

        public dominio.Alquiler BuscarAlquiler(double _id)
        {
            Expression<Func<dominio.Alquiler, bool>> filter = s => s.esEliminado == false && s.IdAlquiler == _id;
            var item = (_alquiler.Context().FindAsync(filter, null).Result).FirstOrDefault();
            return item;
        }

        public bool ModificarAlquiler(dominio.Alquiler alquiler)
        {
            Expression<Func<dominio.Alquiler, bool>> filter = s => s.esEliminado == false && s.IdAlquiler == alquiler.IdAlquiler;
            var alquilerActual = (_alquiler.Context().FindAsync(filter, null).Result).FirstOrDefault();
            return true;
        }

        public void EliminarAlquiler(double _id)
        {
            Expression<Func<dominio.Alquiler, bool>> filter = s => s.esEliminado == false && s.IdAlquiler == _id;
            var item = (_alquiler.Context().FindOneAndDelete(filter, null));

        }
    }
}

