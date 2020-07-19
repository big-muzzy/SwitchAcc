using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SwitchAcc.Models;

namespace SwitchAcc.ViewModels
{
    public class SwitchEditViewModel
    {
        public Switch Item { get; set; }
        public IEnumerable<SwModel> ModelsList { get; set; }
        public IEnumerable<VLAN> VLANsList { get; set; }
    }
}
