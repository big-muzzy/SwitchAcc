using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SwitchAcc.Models
{
    public interface IVLANRepositary
    {
        IEnumerable<VLAN> VLANRepositary { get; }

        void Delete(int id);
        int Save(VLAN item);
    }
}
