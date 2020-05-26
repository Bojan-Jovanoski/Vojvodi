using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Repos.BitkaRepo
{
    public interface IBitkaRepository : IDisposable
    {
        IEnumerable<Bitka> GetBitkas();
        Bitka GetBitkasByID(int BitkaID);
        void InsertBitkas(Bitka bitka);
        void DeleteBitkas(int BitkaID);
        void UpdateBitkas(Bitka bitka);
        void Save();
    }
}
