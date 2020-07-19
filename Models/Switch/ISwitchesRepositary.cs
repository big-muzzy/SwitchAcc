using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SwitchAcc.Models
{
    public interface ISwitchesRepositary
    {
        IEnumerable<Switch> SwitchesRepositary { get; }

        void Delete(int id);
        int Save(Switch item);
    }
}
