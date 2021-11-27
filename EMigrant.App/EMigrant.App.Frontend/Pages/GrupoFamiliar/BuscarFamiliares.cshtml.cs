using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using EMigrant.App.Persistencia.AppRepositorios;
using EMigrant.App.Dominio;
using System.ComponentModel.DataAnnotations;

namespace MyApp.Namespace
{
    public class BuscarFamiliaresModel : PageModel
    {
        private readonly RepositorioMigrante _repositorioMigrante;
        private readonly RepositorioFamiliares _repositorioFamiliares;
        private readonly RepositorioParientes _repositorioParientes;
        private readonly RepositorioAmigos _repositorioAmigos;
        public Migrante Migrante { get; set; }
        public Parientes Parientes { get; set; }
        public Amigos Amigos { get; set; }
        public bool familiarEncontrado { get; set; }
        public string textoFiltro { get; set; }
        public int idMigranteUsuario { get; set; }
        public int idGrupo { get; set; }
        [Required(ErrorMessage = "La relacion con el migrante es necesaria.")]
        [BindProperty]
        public string Relacion { get; set; }

        public BuscarFamiliaresModel(RepositorioFamiliares repositorioFamiliares, RepositorioMigrante repositorioMigrante, RepositorioParientes repositorioParientes, RepositorioAmigos repositorioAmigos)
        {
            this._repositorioMigrante = repositorioMigrante;
            this._repositorioFamiliares = repositorioFamiliares;
            this._repositorioAmigos = repositorioAmigos;
            this._repositorioParientes = repositorioParientes;
            familiarEncontrado=false;
        }
        public IActionResult OnGet(String? textoFiltro, String? Id, String? IdGrupo){
            if(!String.IsNullOrEmpty(textoFiltro)){
                Console.WriteLine(textoFiltro);
                Migrante=_repositorioMigrante.GetWithDoc(textoFiltro);
                if(Migrante != null){
                    //Migrante usuario = _repositorioMigrante.GetWithId(idMigranteUsuario);
                    Console.WriteLine(familiarEncontrado);
                    familiarEncontrado=true;
                    //return Page();
                }else{
                    familiarEncontrado=false;
                }
            }
            if(!String.IsNullOrEmpty(Id)&&!String.IsNullOrEmpty(IdGrupo))
            {
                try
                {
                    idMigranteUsuario=Int32.Parse(Id);
                    idGrupo=Int32.Parse(IdGrupo);
                    Console.WriteLine(idMigranteUsuario);
                }
                catch (System.Exception ex)
                {
                    idMigranteUsuario=0;
                    idGrupo = 0;
                }
                Console.WriteLine("idGrupo get");
                Console.WriteLine(idGrupo);
            }
            return Page();
        }
        

        public IActionResult OnPostCrear(String IdGrupo, String Id){
            if (!ModelState.IsValid)
            {
                return Page();
            }
            Console.WriteLine("idGrupo post");
            Console.WriteLine(IdGrupo);
            try
            {
                idMigranteUsuario=Int32.Parse(Id);
                idGrupo=Int32.Parse(IdGrupo);
                //Console.WriteLine(idMigranteUsuario);
                Console.WriteLine("idGrupo post int");
                Console.WriteLine(IdGrupo);
            }
            catch (System.Exception ex)
            {
                idMigranteUsuario=0;
                idGrupo = 0;
            }
            if(Relacion=="Familiar")
            {
                Parientes = new Parientes();
                Parientes.FamiliarId = idMigranteUsuario;
                Parientes.GrupoFamiliarId = idGrupo;
                Parientes=_repositorioParientes.Create(Parientes);
            }
            else
            {
                Amigos = new Amigos();
                Amigos.AmigoId = idMigranteUsuario;
                Amigos.GrupoFamiliarId = idGrupo;
                Amigos=_repositorioAmigos.Create(Amigos);
            }
            return RedirectToPage("./ListarGrupo?id="+Migrante.id);
        }

    }
}
