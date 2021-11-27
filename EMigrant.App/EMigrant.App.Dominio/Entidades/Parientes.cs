using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EMigrant.App.Dominio{
    public class Parientes{
        public int id { get; set; }
        public int FamiliarId { get; set; }
        public GrupoFamiliar grupoFamiliar { get; set; }
        public int GrupoFamiliarId { get; set; }
        
        
        
    }

}