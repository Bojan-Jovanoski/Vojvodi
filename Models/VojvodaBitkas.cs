using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class VojvodaBitkas
    {
        [Key, Column(Order = 1)]
        public int VojvodaID { get; set; }

        [Key, Column(Order = 2)]
        public int BitkaID { get; set; }

        public virtual Vojvoda Vojvoda { get; set; }
        public virtual Bitka Bitka { get; set; }


    }
}
