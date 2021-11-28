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
    public class ServiciosEntidadModel : PageModel
    {
        private readonly RepositorioServicio _repoServicios;
        private readonly RepositorioEntidades _repoEntidad;
        public IEnumerable<Servicio> Servicios {get; set;}
        public EntidadColaboradora Entidad {get; set;}

        public ServiciosEntidadModel(RepositorioServicio _repoServicios, RepositorioEntidades _repoEntidad)
        {
            this._repoServicios = _repoServicios;
            this._repoEntidad = _repoEntidad;
        }
        public void OnGet(int Id)
        {
            Servicios = _repoServicios.GetAllEntidad(Id);
            Entidad = _repoEntidad.GetWithId(Id);
        }
    }
}
