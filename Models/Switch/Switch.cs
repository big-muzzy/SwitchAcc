using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace SwitchAcc.Models
{
    [Table("Switches")]
    public class Switch
    {
        [Key]
        public int? ID { get; set; }

        [ForeignKey("SwModel")]
        public SwModel Model { get; set; }

        [Remote(action: "CheckValidIP", controller: "Home")]
        public string IP { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Обязательный параметр")]
        [Remote(action: "CheckValidMAC", controller: "Home")]
        public string MAC { get; set; }

        [ForeignKey("VLAN")]
        public VLAN ManageVLAN { get; set; }
        
        [Required(AllowEmptyStrings = false, ErrorMessage = "Обязательный параметр")]
        public string SerialNumber { get; set; }
        public string InventoryNumber { get; set; }
        
        [Required(AllowEmptyStrings = false, ErrorMessage = "Обязательный параметр")]
        public DateTime BuyDate { get; set; }
        public DateTime? InstallDate { get; set; }
        public int? Floor { get; set; }
        public string Comment { get; set; }

        public override string ToString()
        {
            return Comment;
        }

    }
}
