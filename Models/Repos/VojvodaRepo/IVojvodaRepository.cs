using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Repos
{
    public interface IVojvodaRepository : IDisposable
    {
        IEnumerable<Vojvoda> GetVojvodas();
        Vojvoda GetVojvodaByID(int VojvodaID);
        void InsertVojvoda(Vojvoda vojvoda);
        void DeleteVojvoda(int VojvodaID);
        void UpdateVojvoda(Vojvoda vojvoda);
        void Save();
    }
}
