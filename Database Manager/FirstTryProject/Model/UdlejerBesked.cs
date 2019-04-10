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
        public bool ErBlevetSet { get; set; }
        public string Kommentar { get; set; }
        public Bil Bil { get; set; }
        public string UdlejetStartSlut { get; set; }
        
        public Udlejer Udlejer { get; set; }
    }
}
