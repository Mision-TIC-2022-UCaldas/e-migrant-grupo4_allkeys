using System;
using System.ComponentModel.DataAnnotations;

namespace EMigrant.App.Dominio
{
    public class Servicio
    {
        public int id {get; set;}
        [Required]
        public string Nombre { get; set; }
        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Debe ser un numero entero positivo")]
        public int MaximoNumMigrantes { get; set; }
        [Required]
        public DateTime FechaInicio {get; set;}
        [Required]
        public DateTime FechaFinalizacion {get; set;}
        [Required]
        public string Estado { get; set; }
        public bool Habilitado{ get; set; }
        public EntidadColaboradora Entidad{get; set;}
        public int EntidadId {get; set;} 

    }
}