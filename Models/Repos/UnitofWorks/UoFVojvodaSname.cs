using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Repos
{
    public class UoFVojvodaSname : IDisposable
    {
        private WebAppContext context = new WebAppContext();
        private GenericRepo<SecretName> snameRepo;
        private GenericRepo<Vojvoda> vojvodaRepo;

        public GenericRepo<SecretName> SnameRepo
        {
            get
            {

                if (this.snameRepo == null)
                {
                    this.snameRepo = new GenericRepo<SecretName>(context);
                }
                return snameRepo;
            }
        }

        public GenericRepo<Vojvoda> VojvodaRepo
        {
            get
            {
                if (this.vojvodaRepo == null)
                {
                    this.vojvodaRepo = new GenericRepo<Vojvoda>(context);
                }
                return vojvodaRepo;
            }
        }

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
