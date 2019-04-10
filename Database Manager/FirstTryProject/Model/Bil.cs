using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FirstTryProject.Model
{
    
    public class Bil
    {
        [Key]
        public string Nummerplade { get; set; }
        public string Billede { get; set; }
        public bool Anhænger { get; set; }
        [Required]
        public string Tilstand { get; set; }
        [Required]
        public bool Reserveret { get; set; }
        [Required]
        public int Vægt { get; set; }
        [Required]
        public int Højde { get; set; }
        [Required]
        public int Bredte { get; set; }
        [Required]
        public string Type { get; set; }
        public string Område { get; set; }
        
        public List<KanUdlejesDato> KanUdlejesDatoer { get; set; }
        public List<UdlejetDag> UdlejetDage { get; set; }

        public Lejer Lejer { get; set; }
        [Required]
        public Udlejer Udlejer { get; set; }
    }
    
} 