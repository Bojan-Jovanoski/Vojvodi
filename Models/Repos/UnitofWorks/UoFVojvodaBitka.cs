using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Repos.UnitofWorks
{

        public class UoFVojvodaBitka : IDisposable
        {
            private WebAppContext context = new WebAppContext();
            private GenericRepo<VojvodaBitkas> vojvodaBitkaRepo;
            private GenericRepo<Bitka> bitkaRepo;
            private GenericRepo<Vojvoda> vojvodaRepo;

            public GenericRepo<VojvodaBitkas> VojvodaBitkasRepo
            {
                get
                {

                    if (this.vojvodaBitkaRepo == null)
                    {
                        this.vojvodaBitkaRepo = new GenericRepo<VojvodaBitkas>(context);
                    }
                    return vojvodaBitkaRepo;
                }
            }

            public GenericRepo<Bitka> BitkaRepo
            {
                get
                {

                    if (this.bitkaRepo == null)
                    {
                        this.bitkaRepo = new GenericRepo<Bitka>(context);
                    }
                    return bitkaRepo;
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
