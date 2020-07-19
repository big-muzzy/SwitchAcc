using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SwitchAcc.Models
{
    public interface ISwModelRepositary
    {
        IEnumerable<SwModel> SwModelRepositary { get; }

        void Delete(int id);
        int Save(SwModel item);
    }
}
