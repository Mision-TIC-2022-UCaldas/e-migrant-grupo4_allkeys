using System.Collections.Generic;
using EMigrant.App.Dominio;
using System.Linq;
using System;
namespace EMigrant.App.Persistencia.AppRepositorios
{
    public class RepositorioParientes
    {
        private readonly AppContext _appContext;
        private readonly RepositorioMigrante _repositorioMigrante;

        public RepositorioParientes(AppContext appContext){
            
            this._appContext= appContext;
            this._repositorioMigrante = new RepositorioMigrante(appContext);
        }

        public IEnumerable<Parientes> GetAll()
        {
            return _appContext.Parientes;
        }
        
        public Parientes Update(Parientes newParientes)
        {
            var encom = _appContext.Parientes.SingleOrDefault(b => b.id == newParientes.id);
            if (encom != null)
            {
                encom.id = newParientes.id;
                encom.FamiliarId = newParientes.FamiliarId;
                
                _appContext.SaveChanges();
            }
            return encom;
        }
        public Parientes Create(Parientes newParientes)
        {
            var addParientes = _appContext.Parientes.Add(newParientes);
            _appContext.SaveChanges();
            return addParientes.Entity;
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

        public Parientes GetWithId(int id)
        {
            return _appContext.Parientes.Find(id);
        }

        public IEnumerable<Migrante> GetAllGrupo(int id)
        {
            IEnumerable<Parientes> allParientes = _appContext.Parientes;
            IEnumerable<Migrante> migrantesFamiliares = Enumerable.Empty<Migrante>();
            foreach (var f in allParientes)
            {
                if(f.GrupoFamiliarId==id){
                    migrantesFamiliares.Append(_repositorioMigrante.GetWithId(f.FamiliarId));
                }
            }
            return migrantesFamiliares;
        } 


        // public Parientes GetWithDoc(string numeroDocumento)
        // {
        //     return _appContext.Parientes.FirstOrDefault(
        //         e=>e.numeroDocumento == numeroDocumento);
        // }
    }


}