using System.Collections.Generic;
using EMigrant.App.Dominio;
using System.Linq;
using System;
namespace EMigrant.App.Persistencia.AppRepositorios
{
    public class RepositorioFamilias
    {
        private readonly AppContext _appContext;

        public RepositorioFamilias(AppContext appContext){
            
            this._appContext= appContext;

        }

        public IEnumerable<Familias> GetAll()
        {
            return _appContext.Familias;
        }
        
        public Familias Update(Familias newFamilias)
        {
            var encom = _appContext.Familias.SingleOrDefault(b => b.id == newFamilias.id);
            if (encom != null)
            {
                encom.id = newFamilias.id;
                encom.FamiliarId = newFamilias.FamiliarId;
                
                _appContext.SaveChanges();
            }
            return encom;
        }
        public Familias Create(Familias newFamilias)
        {
            var addFamilias = _appContext.Familias.Add(newFamilias);
            _appContext.SaveChanges();
            return addFamilias.Entity;
        }
        /*public void Delete(int id)
        {
        var encom= _appContext.Encomiendas.Find(id);
        if(encom != null){
                return;
            }
        _appContext.Encomiendas.Remove(encom);
        _appContext.SaveChanges();
        }*/

        public Familias GetWithId(int id)
        {
            return _appContext.Familias.Find(id);
        }

        public IEnumerable<Migrante>GetAllGrupo(int id)
        {
            

        } 


        // public Familias GetWithDoc(string numeroDocumento)
        // {
        //     return _appContext.Familias.FirstOrDefault(
        //         e=>e.numeroDocumento == numeroDocumento);
        // }
    }


}