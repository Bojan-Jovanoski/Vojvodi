using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Repos.BitkaRepo
{
    public class BitkaRepository : IBitkaRepository, IDisposable
    {
        private WebAppContext db;

        public BitkaRepository(WebAppContext db)
        {
            this.db = db;
        }
        public void DeleteBitkas(int BitkaID)
        {
            Bitka bitka = db.Bitkas.Find(BitkaID);
            db.Bitkas.Remove(bitka);
        }

        public IEnumerable<Bitka> GetBitkas()
        {
            return db.Bitkas.ToList();
        }

        public Bitka GetBitkasByID(int BitkaID)
        {
            return db.Bitkas.Find(BitkaID);
        }

        public void InsertBitkas(Bitka bitka)
        {
            db.Bitkas.Add(bitka);
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public void UpdateBitkas(Bitka bitka)
        {
            db.Entry(bitka).State = EntityState.Modified;
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
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
