using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Vojvoda
    {
        [Key]
        public int VojvodaID { get; set; }
        public string Name { get; set; }
        public string DateOfBirth { get; set; }
        public virtual ICollection<VojvodaBitkas> VojvodaBitkas{ get; set; }
        public virtual SecretName SecretName { get; set; }
    }
}
