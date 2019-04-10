using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FirstTryProject.Model
{
    public class UdlejerBesked
    {
        [Key]
        public int UdlejerBeskedid { get; set; }
        public bool ErBlevetAfvist { get; set; }
        [Required]
        public bool ErBlevetSet { get; set; }
        public string Kommentar { get; set; }
        public Bil Bil { get; set; }
        [Required]
        public string UdlejetStartSlut { get; set; }
        [Required]
        public Udlejer Udlejer { get; set; }
    }
}
