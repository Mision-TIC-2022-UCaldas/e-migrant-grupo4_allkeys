using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EMigrant.App.Dominio;
using EMigrant.App.Persistencia.AppRepositorios;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EMigrant.App.Frontend.EntidadesColaboradoras
{
    public class ActualizarModel : PageModel
    {
        private readonly RepositorioEntidades _repositorioEntidades;
        [BindProperty]
        public EntidadColaboradora Entidad { get; set; }

        public ActualizarModel(RepositorioEntidades repositorioEntidades)
        {

            this._repositorioEntidades = repositorioEntidades;
        }

        public IActionResult OnGet(int id)
        {
            Entidad = _repositorioEntidades.GetWithId(id);
            return Page();

        }
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            if (Entidad.id > 0)
            {
                Entidad = _repositorioEntidades.Update(Entidad);
            }
            return RedirectToPage("./Lista");
        }
    }
}
