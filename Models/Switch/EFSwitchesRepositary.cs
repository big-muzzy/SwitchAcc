using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SwitchAcc.Models
{
    public class EFSwitchesRepositary: ISwitchesRepositary
    {
        private AppDBContext context;

        public EFSwitchesRepositary(AppDBContext ctx)
        {
            context = ctx;
        }

        public IEnumerable<Switch> SwitchesRepositary
        {
            get { return context.Switches.Include(m => m.Model).Include(v => v.ManageVLAN).ToList(); }
        }

        public void Delete(int id)
        {
            context.Switches.Remove(context.Switches.FirstOrDefault(n => n.ID == id));
            context.SaveChanges();
        }

        public int Save(Switch item)
        {
            if (item.ID == null)
            {
                context.Switches.Add(item);
            }
            else
            {
                context.Switches.SingleOrDefault(n => n.ID == item.ID).IP = item.IP;
                context.Switches.SingleOrDefault(n => n.ID == item.ID).MAC = item.MAC;
                context.Switches.SingleOrDefault(n => n.ID == item.ID).SerialNumber = item.SerialNumber;
                context.Switches.SingleOrDefault(n => n.ID == item.ID).InventoryNumber = item.InventoryNumber;
                context.Switches.SingleOrDefault(n => n.ID == item.ID).BuyDate = item.BuyDate;
                context.Switches.SingleOrDefault(n => n.ID == item.ID).InstallDate = item.InstallDate;
                context.Switches.SingleOrDefault(n => n.ID == item.ID).Floor = item.Floor;
                context.Switches.SingleOrDefault(n => n.ID == item.ID).Comment = item.Comment;
                context.Switches.SingleOrDefault(n => n.ID == item.ID).Model = item.Model;
                context.Switches.SingleOrDefault(n => n.ID == item.ID).ManageVLAN = item.ManageVLAN;

                //public SwModel Model { get; set; }            +
                //public string IP { get; set; }                +
                //public string MAC { get; set; }               +
                //public VLAN ManageVLAN { get; set; }          +
                //public string SerialNumber { get; set; }      +
                //public string InventoryNumber { get; set; }   +  
                //public DateTime BuyDate { get; set; }         +
                //public DateTime InstallDate { get; set; }     +
                //public int Floor { get; set; }                +
                //public string Comment { get; set; }           +
            }
            context.SaveChanges();
            return (int)item.ID;
        }

    }
}
