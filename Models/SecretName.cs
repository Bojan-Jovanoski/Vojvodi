using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class SecretName
    {
        [Key, ForeignKey("Vojvoda")]
        public int SnameID { get; set; }

        public string Sname { get; set; }

        public virtual Vojvoda Vojvoda { get; set; }
    }
}
