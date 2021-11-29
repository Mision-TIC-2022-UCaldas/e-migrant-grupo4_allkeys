using System.ComponentModel.DataAnnotations;

namespace EMigrant.App.Dominio
{
    public class EntidadColaboradora
    {
        public int id { get; set; }
        [Required]
        public string RazonSocial { get; set; }
        [Required]
        public string Nit { get; set; }
        [Required]
        public string Direccion { get; set; }
        [Required]
        public string Ciudad { get; set; }
        [Required]
        public string Telefono { get; set; }
        [Required]
        public string Sector { get; set; }
        [Required]
        public string Tipo { get; set; }
        public string DireccionElectronica { get; set; }
        public string PaginaWeb { get; set; }
    }
}