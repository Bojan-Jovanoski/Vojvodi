using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class WebAppContext : DbContext
    {
        public DbSet<Vojvoda> Vojvodas { get; set; }
        public DbSet<Bitka> Bitkas { get; set; }
        public DbSet<SecretName> SecretNames { get; set; }
        public DbSet<VojvodaBitkas> VojvodaBitkas { get; set; }

        public WebAppContext() : base("Connection"){ }
        public static WebAppContext Create()
        {
            return new WebAppContext();
        }

    }
}
