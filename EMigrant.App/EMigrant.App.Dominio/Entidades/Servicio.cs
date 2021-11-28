using System.ComponentModel.DataAnnotations;

namespace EMigrant.App.Dominio
{
    public class Servicio
    {
        public int id {get; set;}
        [Required]
        public string Tipo { get; set; }
        public string Descripcion { get; set; }
        public bool Habilitado{ get; set; }
        public EntidadColaboradora Entidad{get; set;}
        public int EntidadId {get; set;} 

    }
}