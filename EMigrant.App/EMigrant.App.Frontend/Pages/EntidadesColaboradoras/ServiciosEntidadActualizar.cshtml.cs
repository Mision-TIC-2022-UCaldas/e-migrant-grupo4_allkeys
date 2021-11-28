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
    public class ServiciosEntidadActualizarModel : PageModel
    {
         private readonly RepositorioServicio _repoServicios;
        private readonly RepositorioEntidades _repoEntidades;
        [BindProperty]
        public Servicio Servicio {get; set;}
        public EntidadColaboradora Entidad {get; set;}
        public ServiciosEntidadActualizarModel(RepositorioServicio _repoServicios, RepositorioEntidades _repoEntidades)
        {
            this._repoServicios = _repoServicios;
            this._repoEntidades = _repoEntidades;
        }

        public void OnGet(int id, int idEntidad)
        {
            Entidad = _repoEntidades.GetWithId(idEntidad);
            Servicio = _repoServicios.GetWithId(id);
        }

        public IActionResult OnPost(int id)
        {
            if(ModelState.IsValid)
            {
                Servicio.EntidadId = id;
                Servicio = _repoServicios.Update(Servicio);
                return RedirectToPage("./ServiciosEntidad", new {id = id});
            }
            return Page();
        }
    }
}
