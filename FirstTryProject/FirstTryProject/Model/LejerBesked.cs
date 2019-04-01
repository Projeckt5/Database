using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FirstTryProject.Model
{
    public class LejerBesked 
    {
        [Key]
        public int LejerBeskedid { get; set; }
        public string Kontaktinformation { get; set; }
        public bool ErBlevetSet { get; set; }
        public string Kommentar { get; set; }
        public string BilId { get; set; }
        public string UdlejetStartSlut { get; set; }

        public Lejer Lejer { get; set; }
    }
}
