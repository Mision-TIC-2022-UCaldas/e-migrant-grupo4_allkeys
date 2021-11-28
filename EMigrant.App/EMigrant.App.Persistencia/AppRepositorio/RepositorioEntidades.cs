using System.Collections.Generic;
using EMigrant.App.Dominio;
using System.Linq;

namespace EMigrant.App.Persistencia.AppRepositorios
{
    public class RepositorioEntidades
    {
        private readonly AppContext _appContext;

        public RepositorioEntidades(AppContext appContext)
        {
            this._appContext = appContext;
        }

        public IEnumerable<EntidadColaboradora> GetAll()
        {
            return _appContext.Entidades;
        }

        public EntidadColaboradora Create(EntidadColaboradora nuevaEntidad)
        {
            var Entidad = _appContext.Entidades.Add(nuevaEntidad);
            _appContext.SaveChanges();
            return Entidad.Entity;
        }
        public EntidadColaboradora GetWithId(int id)
        {
            return _appContext.Entidades.Find(id);
        }

        public EntidadColaboradora Update(EntidadColaboradora entidad)
        {
            var entidadEncontrado = _appContext.Entidades.FirstOrDefault(e=>e.id == entidad.id);
            if(entidadEncontrado != null){
                entidadEncontrado.RazonSocial = entidad.RazonSocial;
                entidadEncontrado.Nit = entidad.Nit;
                entidadEncontrado.Direccion = entidad.Direccion;
                entidadEncontrado.Ciudad = entidad.Ciudad;
                entidadEncontrado.Telefono = entidad.Telefono;
                entidadEncontrado.DireccionElectronica = entidad.DireccionElectronica;
                entidadEncontrado.PaginaWeb = entidad.PaginaWeb;
                entidadEncontrado.Sector = entidad.Sector;
                _appContext.SaveChanges();
            }
            return entidadEncontrado;
        }

    }
}