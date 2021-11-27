using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EMigrant.App.Dominio{
    public class Amigos{
        public int id { get; set; }
        public int AmigoId { get; set; }
        
        public GrupoFamiliar grupoFamiliar { get; set; }
        public int GrupoFamiliarId { get; set; }
    }

}