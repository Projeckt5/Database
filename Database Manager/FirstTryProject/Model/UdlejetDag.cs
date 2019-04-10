using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FirstTryProject.Model
{
    public class UdlejetDag 
    {
        [Key]
        public DateTime Dato { get; set; }
        public Lejer Lejer { get; set; }

        public Bil Bil { get; set; }
    }
}
