using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EMigrant.App.Dominio;
using EMigrant.App.Persistencia.AppRepositorios;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MyApp.Namespace
{
    public class ServicioHabilitarModel : PageModel
    {
        private readonly RepositorioServicio _repoServicios;
        public Servicio Servicio {get; set;}
        public ServicioHabilitarModel(RepositorioServicio _repoServicios)
        {
            this._repoServicios = _repoServicios;
        }
        public IActionResult OnGet(int id, int idEntidad)
        {
            Servicio = _repoServicios.GetWithId(id);
            Servicio.Habilitado = !Servicio.Habilitado;
            Servicio = _repoServicios.Update(Servicio);
            return RedirectToPage("./ServiciosEntidad", new {id = idEntidad});
        }
    }
}
