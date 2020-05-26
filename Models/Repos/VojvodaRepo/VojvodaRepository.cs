using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Repos
{
    public class VojvodaRepository : IVojvodaRepository, IDisposable
    {
        private WebAppContext db;

        public VojvodaRepository(WebAppContext db)
        {
            this.db = db;
        }

        public IEnumerable<Vojvoda> GetVojvodas()
        {
            return db.Vojvodas.ToList();
        }

        public Vojvoda GetVojvodaByID(int id)
        {
            return db.Vojvodas.Find(id);

        }

        public void InsertVojvoda(Vojvoda vojvoda)
        {
            db.Vojvodas.Add(vojvoda);
        }

        public void DeleteVojvoda(int VojvodaID)
        {
            Vojvoda vojvoda = db.Vojvodas.Find(VojvodaID);
            db.Vojvodas.Remove(vojvoda);
        }

        public void UpdateVojvoda(Vojvoda vojvoda)
        {
            db.Entry(vojvoda).State = EntityState.Modified;
        }

        public void Save()
        {
            db.SaveChanges();
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
