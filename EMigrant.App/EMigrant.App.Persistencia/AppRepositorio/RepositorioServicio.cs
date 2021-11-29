using System.Collections.Generic;
using System.Linq;
using EMigrant.App.Dominio;

namespace EMigrant.App.Persistencia.AppRepositorios
{
    public class RepositorioServicio
    {
        private readonly AppContext _appContext;

        public RepositorioServicio(AppContext appContext)
        {
            this._appContext = appContext;
        }

        public IEnumerable<Servicio> GetAll()
        {
            return _appContext.Servicios;
        }

        public IEnumerable<Servicio> GetAllEntidad(int id)
        {
            return _appContext.Servicios.Where(s => s.EntidadId==id).ToList();
        }

        public Servicio Create(Servicio nuevoServicio)
        {
            var Servicio = _appContext.Servicios.Add(nuevoServicio);
            _appContext.SaveChanges();
            return Servicio.Entity;
        }

        public Servicio GetWithId(int id)
        {
            return _appContext.Servicios.Find(id);
        }

        public Servicio Update(Servicio servicio)
        {
            var ServicioEncontrado = _appContext.Servicios.FirstOrDefault(e=>e.id == servicio.id);
            if(ServicioEncontrado != null){
                ServicioEncontrado.Nombre = servicio.Nombre;
                ServicioEncontrado.MaximoNumMigrantes = servicio.MaximoNumMigrantes;
                ServicioEncontrado.FechaInicio = servicio.FechaInicio;
                ServicioEncontrado.FechaFinalizacion = servicio.FechaFinalizacion;
                ServicioEncontrado.Estado = servicio.Estado;
                ServicioEncontrado.Habilitado = servicio.Habilitado;
                _appContext.SaveChanges();
            }
            return ServicioEncontrado;
        }

    }
}