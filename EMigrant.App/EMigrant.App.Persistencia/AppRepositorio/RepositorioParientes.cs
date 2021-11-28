using System.Reflection;
using System.Net.Mail;
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
            this._repositorioMigrante = new RepositorioMigrante(new AppContext());
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
        public void Delete(int id)
        {
            var persona_encontrada = _appContext.Parientes.FirstOrDefault(p => p.FamiliarId == id);
            if(persona_encontrada == null)
                return;
            _appContext.Parientes.Remove(persona_encontrada);
            _appContext.SaveChanges();
        }

        public Parientes GetWithId(int id)
        {
            return _appContext.Parientes.Find(id);
        }

        public List<Migrante> GetAllGrupo(int id)
        {
            IEnumerable<Parientes> allParientes = _appContext.Parientes.Where(e => e.GrupoFamiliarId==id).ToList();
            List<Migrante> migrantesFamiliares = new List<Migrante>();
            foreach (var f in allParientes)
            {
                Migrante m = _repositorioMigrante.GetWithId(f.FamiliarId);
                migrantesFamiliares.Add(m);
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