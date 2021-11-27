using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EMigrant.App.Dominio
{
    

    public class Migrante
    {

        public int id { get; set; }
        [Required]
        public string nombre { get; set; }
        [Required]
        public string apellidos { get; set; }
        [Required]
        public string tipoIdentificacion { get; set; }
        [Required]
        //[Index(IsUnique = true)]
        public string numeroDocumento { get; set; }
        [Required]
        public string paisOrigen { get; set; }
        [Required]
        public DateTime fechaNacimiento { get; set; }

        [Required(ErrorMessage = "El telefono es necesario")]

        public string telefono { get; set; }
        [DataType(DataType.EmailAddress)]
        public string direccionElectronica { get; set; }
        public string direccionActual { get; set; }
        public string ciudad { get; set; }
        public string situacionLaboral { get; set; }
        public GrupoFamiliar GrupoFamiliar { get; set; }
        public int GrupoFamiliarId { get; set; }
    }

}