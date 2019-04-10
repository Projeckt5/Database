using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FirstTryProject.Model
{
    public class Lejer
    {
        [Key]
        public string Kontaktinformation { get; set; }
        [Required]
        public string Navn { get; set; }
        [Required]
        public string Kørekortnummer { get; set; }
        
        public List<Bil> Biler { get; set; }
        public List<LejerBesked> LejerBeskeder { get; set; }
    }  
}
