using System.Collections.Generic;
using EMigrant.App.Dominio;
using System.Linq;
using System;
namespace EMigrant.App.Persistencia.AppRepositorios
{
    public class RepositorioAmigos
    {
        private readonly AppContext _appContext;
        private readonly RepositorioMigrante _repositorioMigrante;
        public RepositorioAmigos(AppContext appContext){
            
            this._appContext= appContext;
            this._repositorioMigrante = new RepositorioMigrante(new AppContext());
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
        public void Delete(int id)
        {
            Console.WriteLine(id);
            var persona_encontrada = _appContext.Amigos.FirstOrDefault(p => p.AmigoId == id);
            Console.WriteLine(persona_encontrada);
            if(persona_encontrada == null)
                return;
            _appContext.Amigos.Remove(persona_encontrada);
            _appContext.SaveChanges();
        }

        public Amigos GetWithId(int id)
        {
            return _appContext.Amigos.Find(id);
        }
        // public Amigos GetWithDoc(string numeroDocumento)
        // {
        //     return _appContext.Amigos.FirstOrDefault(
        //         e=>e.numeroDocumento == numeroDocumento);
        // }
        public List<Migrante> GetAllGrupo(int id)
        {
            IEnumerable<Amigos> allAmigos = _appContext.Amigos.Where(e => e.GrupoFamiliarId==id).ToList();
            List<Migrante> migrantesAmigos = new List<Migrante>();
            foreach (var f in allAmigos)
            {
                Migrante m = _repositorioMigrante.GetWithId(f.AmigoId);
                migrantesAmigos.Add(m);
            }
            return migrantesAmigos;
        } 
    }


}