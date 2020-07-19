using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SwitchAcc.Models
{
    public class EFSwModelRepositary : ISwModelRepositary
    {
        private AppDBContext context;

        public EFSwModelRepositary(AppDBContext ctx)
        {
            context = ctx;
        }

        public IEnumerable<SwModel> SwModelRepositary
        {
            get { return context.SwModels.ToList(); }
        }

        public void Delete(int id)
        {
            context.SwModels.Remove(context.SwModels.FirstOrDefault(n => n.ID == id));
            context.SaveChanges();
        }

        public int Save(SwModel item)
        {
            if (item.ID == null)
            {
                context.SwModels.Add(item);
            }
            else
            {
                context.SwModels.SingleOrDefault(n => n.ID == item.ID).Name = item.Name;
            }
            context.SaveChanges();
            return (int)item.ID;
        }
    }
}
