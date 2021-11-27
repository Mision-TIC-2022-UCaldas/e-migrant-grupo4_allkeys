using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EMigrant.App.Dominio{
    public class GrupoFamiliar{
        public int id { get; set; }
        public IEnumerable<Amigos> amigos { get; set; }
        public IEnumerable<Parientes> Parientes { get; set; }
        
        
    }

}