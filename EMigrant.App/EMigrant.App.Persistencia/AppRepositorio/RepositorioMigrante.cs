using System.Collections.Generic;
using EMigrant.App.Dominio;
using System.Linq;
using System;
namespace EMigrant.App.Persistencia.AppRepositorios
{
    public class RepositorioMigrante
    {
        private readonly AppContext _appContext = new AppContext();

        public IEnumerable<Migrante> GetAll()
        {
            return _appContext.Migrantes;
        }
        /*public Migrante Update(Migrante newEncomienda){
            var encom= _appContext.Encomiendas.SingleOrDefault(b => b.id == newEncomienda.id);
            if(encom != null){
                encom.id= newEncomienda.id;
                encom.descripcion= newEncomienda.descripcion;
                encom.peso= newEncomienda.peso;
                encom.tipo= newEncomienda.tipo;
                encom.presentacion= newEncomienda.presentacion;
                _appContext.SaveChanges();
            }
        return encom;
        }*/
        public Migrante Create(Migrante newMigrante)
        {
            var addMigrante = _appContext.Migrantes.Add(newMigrante);
            _appContext.SaveChanges();
            return addMigrante.Entity;
        }
        /*public void Delete(int id)
        {
        var encom= _appContext.Encomiendas.Find(id);
        if(encom != null){
                return;
            }
        _appContext.Encomiendas.Remove(encom);
        _appContext.SaveChanges();
        }

        public Encomienda GetEncomWithId(int encomiendaid){
            return _appContext.Encomiendas.Find(encomiendaid);
        }*/
    }

    
}