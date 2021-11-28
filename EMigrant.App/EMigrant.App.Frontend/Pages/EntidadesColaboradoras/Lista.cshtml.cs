using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EMigrant.App.Dominio;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using EMigrant.App.Persistencia.AppRepositorios;

namespace EMigrant.App.Frontend.EntidadesColaboradoras
{
    public class ListaModel : PageModel
    {
        private readonly RepositorioEntidades _repoEntidades;
        public IEnumerable<EntidadColaboradora> Entidades {get; set;}

        public ListaModel(RepositorioEntidades repoEntidades)
        {
            this._repoEntidades = repoEntidades;
        }
        public void OnGet()
        {
            Entidades = _repoEntidades.GetAll();
        }
    }
}
