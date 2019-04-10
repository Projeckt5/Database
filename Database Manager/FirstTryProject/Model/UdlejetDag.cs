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
        [Required]
        public Lejer Lejer { get; set; }
        [Required]
        public Bil Bil { get; set; }
    }
}
