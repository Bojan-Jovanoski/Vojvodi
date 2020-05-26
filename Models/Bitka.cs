using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Bitka
    {
        [Key]
        public int BitkaId { get; set; }

        public string Lokacija { get; set; }

        public string Datum { get; set; }

        public virtual ICollection<VojvodaBitkas> VojvodaBitkas { get; set; }
    }
}
