using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SwitchAcc.Models;

namespace SwitchAcc.ViewModels
{
    public class VLANsViewModel
    {
        public IEnumerable<VLAN> VLANs { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }
}
