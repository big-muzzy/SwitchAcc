using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SwitchAcc.Models
{
    [Table("VLANs")]
    public class VLAN
    {
        [Key]
        public int? ID { get; set; }

        private string name;
        [Required(AllowEmptyStrings = false, ErrorMessage = "Не задано имя VLAN")]
        public String Name
        {
            get => name;
            set
            {
                if (string.IsNullOrWhiteSpace(value)) { throw new ArgumentException("Неверно задано имя VLAN"); }
                name = value;
            }
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
