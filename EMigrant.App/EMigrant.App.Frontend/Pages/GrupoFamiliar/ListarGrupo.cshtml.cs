using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using EMigrant.App.Persistencia.AppRepositorios;
using EMigrant.App.Dominio;

namespace MyApp.Namespace
{
    public class ListarGrupoModel : PageModel
    {
        private readonly RepositorioMigrante _repositorioMigrante;
        private readonly RepositorioFamiliares _repoGrupo;
        private readonly RepositorioParientes _repoParientes;
        private readonly RepositorioAmigos _repoAmigos;
        public Migrante Migrante { get; set; }
        public GrupoFamiliar grupo {get; set;}
        public IEnumerable<Migrante> Parientes { get; set; }
        public IEnumerable<Migrante> Amigos { get; set; }

        public ListarGrupoModel(RepositorioFamiliares repositorioFamiliares, RepositorioMigrante repositorioMigrante, RepositorioParientes repoParientes, RepositorioAmigos repoAmigos)
        {
            this._repositorioMigrante = repositorioMigrante;
            this._repoGrupo = repositorioFamiliares;
            this._repoParientes = repoParientes;
            this._repoAmigos = repoAmigos;
        }

        public IActionResult OnGet(int id)
        {
            if (id > 0)
            {
                Migrante = _repositorioMigrante.GetWithId(id);
                grupo = _repoGrupo.GetWithId(Migrante.GrupoFamiliarId);
                Parientes = _repoParientes.GetAllGrupo(Migrante.GrupoFamiliarId);
                Amigos = _repoAmigos.GetAllGrupo(Migrante.GrupoFamiliarId);
                return Page();
            }
            return RedirectToPage("../Migrante/Listar");


        }
    }
}
