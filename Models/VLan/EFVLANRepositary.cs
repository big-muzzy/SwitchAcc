using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SwitchAcc.Models
{
    public class EFVLANRepositary: IVLANRepositary
    {
        private AppDBContext context;

        public EFVLANRepositary(AppDBContext ctx)
        {
            context = ctx;
        }

        public IEnumerable<VLAN> VLANRepositary
        {
            get { return context.VLANs.ToList(); }
        }

        public void Delete(int id)
        {
            context.VLANs.Remove(context.VLANs.FirstOrDefault(n => n.ID == id));
            context.SaveChanges();
        }

        public int Save(VLAN item)
        {
            if (item.ID == null)
            {
                context.VLANs.Add(item);
            }
            else
            {
                context.VLANs.SingleOrDefault(n => n.ID == item.ID).Name = item.Name;
            }
            context.SaveChanges();
            return (int)item.ID;
        }
    }
}
