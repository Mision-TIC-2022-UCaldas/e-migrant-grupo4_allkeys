using System.Collections.Generic;
using EMigrant.App.Dominio;
using System.Linq;
using System;
namespace EMigrant.App.Persistencia.AppRepositorios
{
    public class RepositorioAmigos
    {
        private readonly AppContext _appContext;

        public RepositorioAmigos(AppContext appContext){
            
            this._appContext= appContext;

        }

        public IEnumerable<Amigos> GetAll()
        {
            return _appContext.Amigos;
        }
        
        public Amigos Update(Amigos newAmigos)
        {
            var encom = _appContext.Amigos.SingleOrDefault(b => b.id == newAmigos.id);
            if (encom != null)
            {
                encom.id = newAmigos.id;
                encom.AmigoId = newAmigos.AmigoId;

                
                _appContext.SaveChanges();
            }
            return encom;
        }
        public Amigos Create(Amigos newAmigos)
        {
            var addAmigos = _appContext.Amigos.Add(newAmigos);
            _appContext.SaveChanges();
            return addAmigos.Entity;
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

        public Amigos GetWithId(int id)
        {
            return _appContext.Amigos.Find(id);
        }
        // public Amigos GetWithDoc(string numeroDocumento)
        // {
        //     return _appContext.Amigos.FirstOrDefault(
        //         e=>e.numeroDocumento == numeroDocumento);
        // }
    }


}