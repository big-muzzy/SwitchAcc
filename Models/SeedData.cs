using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SwitchAcc.Models
{
    public static class SeedData
    {

        public static void EnsurePopulated(AppDBContext context)
        {
            context.Database.EnsureCreated();

            if (!context.SwModels.Any())
            {
                var model1 = new SwModel() { Name = "Model 1" };
                var model2 = new SwModel() { Name = "Model 2" };
                var model3 = new SwModel() { Name = "Model 3" };
                var model4 = new SwModel() { Name = "Model 4" };
                var model5 = new SwModel() { Name = "Model 5" };
                var vlan1 = new VLAN() { Name = "VLAN 1" };
                var vlan2 = new VLAN() { Name = "VLAN 2" };
                var vlan3 = new VLAN() { Name = "VLAN 3" };
                var vlan4 = new VLAN() { Name = "VLAN 4" };
                var vlan5 = new VLAN() { Name = "VLAN 5" };
                context.AddRange(
                    model1, model2, model3, model4, model5,
                    vlan1, vlan2, vlan3, vlan4, vlan5,
                    new Switch()
                    {
                        IP = "192.168.0.2",
                        MAC = "03:A8:E2:D0:9B:08",
                        SerialNumber = "0001",
                        InventoryNumber = "000/001",
                        BuyDate = new DateTime(2020, 01, 01),
                        InstallDate = new DateTime(2020, 02, 01),
                        Floor = 1,
                        Comment = "Comment 1",
                        Model = model1,
                        ManageVLAN = vlan1
                    },
                    new Switch()
                    {
                        IP = "192.168.0.3",
                        MAC = "0D:ED:2D:D9:1B:3E",
                        SerialNumber = "0002",
                        InventoryNumber = "000/002",
                        BuyDate = new DateTime(2020, 01, 02),
                        InstallDate = new DateTime(2020, 02, 02),
                        Floor = 2,
                        Comment = "Comment 2",
                        Model = model2,
                        ManageVLAN = vlan1
                    }, 
                    new Switch()
                    {
                        IP = "192.168.0.4",
                        MAC = "6D:1C:58:67:FA:35",
                        SerialNumber = "0003",
                        InventoryNumber = "000/003",
                        BuyDate = new DateTime(2020, 01, 03),
                        InstallDate = new DateTime(2020, 02, 03),
                        Floor = 1,
                        Comment = "Comment 3",
                        Model = model3,
                        ManageVLAN = vlan1
                    },
                    new Switch()
                    {
                        IP = "192.168.0.5",
                        MAC = "A6:FE:43:F6:B7:34",
                        SerialNumber = "0004",
                        InventoryNumber = "000/004",
                        BuyDate = new DateTime(2020, 01, 04),
                        InstallDate = new DateTime(2020, 02, 04),
                        Floor = 2,
                        Comment = "Comment 4",
                        Model = model4,
                        ManageVLAN = vlan1
                    },
                    new Switch()
                    {
                        IP = "192.168.0.6",
                        MAC = "B7:21:CA:2D:23:1B",
                        SerialNumber = "0005",
                        InventoryNumber = "000/005",
                        BuyDate = new DateTime(2020, 01, 05),
                        InstallDate = new DateTime(2020, 02, 05),
                        Floor = 1,
                        Comment = "Comment 5",
                        Model = model5,
                        ManageVLAN = vlan1
                    },
                    new Switch()
                    {
                        IP = "192.168.0.7",
                        MAC = "C3:FD:6F:B6:F9:0F",
                        SerialNumber = "0006",
                        InventoryNumber = "000/006",
                        BuyDate = new DateTime(2020, 01, 06),
                        InstallDate = new DateTime(2020, 02, 06),
                        Floor = 2,
                        Comment = "Comment 6",
                        Model = model1,
                        ManageVLAN = vlan2
                    },
                    new Switch()
                    {
                        IP = "192.168.0.8",
                        MAC = "CD:AC:3F:AD:A4:9D",
                        SerialNumber = "0007",
                        InventoryNumber = "000/007",
                        BuyDate = new DateTime(2020, 01, 07),
                        InstallDate = new DateTime(2020, 02, 07),
                        Floor = 1,
                        Comment = "Comment 7",
                        Model = model2,
                        ManageVLAN = vlan2
                    },
                    new Switch()
                    {
                        IP = "192.168.0.9",
                        MAC = "3F:79:8E:88:5D:15",
                        SerialNumber = "0008",
                        InventoryNumber = "000/008",
                        BuyDate = new DateTime(2020, 01, 08),
                        InstallDate = new DateTime(2020, 02, 08),
                        Floor = 2,
                        Comment = "Comment 8",
                        Model = model3,
                        ManageVLAN = vlan2
                    },
                    new Switch()
                    {
                        IP = "192.168.0.10",
                        MAC = "A8:78:C2:6E:5F:0C",
                        SerialNumber = "0009",
                        InventoryNumber = "000/009",
                        BuyDate = new DateTime(2020, 01, 09),
                        InstallDate = new DateTime(2020, 02, 09),
                        Floor = 1,
                        Comment = "Comment 9",
                        Model = model4,
                        ManageVLAN = vlan2
                    },
                    new Switch()
                    {
                        IP = "192.168.0.11",
                        MAC = "A8:78:C2:6E:5F:0C",
                        SerialNumber = "0010",
                        InventoryNumber = "000/010",
                        BuyDate = new DateTime(2020, 01, 10),
                        InstallDate = new DateTime(2020, 02, 10),
                        Floor = 2,
                        Comment = "Comment 10",
                        Model = model5,
                        ManageVLAN = vlan2
                    },
                    new Switch()
                    {
                        IP = "192.168.0.12",
                        MAC = "C3:F6:EA:4F:43:D2",
                        SerialNumber = "0011",
                        InventoryNumber = "000/011",
                        BuyDate = new DateTime(2020, 01, 11),
                        InstallDate = new DateTime(2020, 02, 11),
                        Floor = 1,
                        Comment = "Comment 11",
                        Model = model1,
                        ManageVLAN = vlan3
                    },
                    new Switch()
                    {
                        IP = "192.168.0.13",
                        MAC = "77:BE:A5:22:A1:F5",
                        SerialNumber = "0012",
                        InventoryNumber = "000/012",
                        BuyDate = new DateTime(2020, 01, 12),
                        InstallDate = new DateTime(2020, 02, 12),
                        Floor = 2,
                        Comment = "Comment 12",
                        Model = model2,
                        ManageVLAN = vlan3
                    },
                    new Switch()
                    {
                        IP = "192.168.0.14",
                        MAC = "4B:30:54:3B:9F:1D",
                        SerialNumber = "0013",
                        InventoryNumber = "000/013",
                        BuyDate = new DateTime(2020, 01, 13),
                        InstallDate = new DateTime(2020, 02, 13),
                        Floor = 1,
                        Comment = "Comment 13",
                        Model = model3,
                        ManageVLAN = vlan3
                    },
                    new Switch()
                    {
                        IP = "192.168.0.15",
                        MAC = "51:95:FE:09:18:3E",
                        SerialNumber = "0014",
                        InventoryNumber = "000/014",
                        BuyDate = new DateTime(2020, 01, 14),
                        InstallDate = new DateTime(2020, 02, 14),
                        Floor = 2,
                        Comment = "Comment 14",
                        Model = model4,
                        ManageVLAN = vlan3
                    },
                    new Switch()
                    {
                        IP = "192.168.0.16",
                        MAC = "14:2B:AA:16:9C:F0",
                        SerialNumber = "0015",
                        InventoryNumber = "000/015",
                        BuyDate = new DateTime(2020, 01, 15),
                        InstallDate = new DateTime(2020, 02, 15),
                        Floor = 1,
                        Comment = "Comment 15",
                        Model = model5,
                        ManageVLAN = vlan3
                    },
                    new Switch()
                    {
                        IP = "192.168.0.17",
                        MAC = "E8:86:11:C1:CC:7A",
                        SerialNumber = "0016",
                        InventoryNumber = "000/016",
                        BuyDate = new DateTime(2020, 01, 16),
                        InstallDate = new DateTime(2020, 02, 16),
                        Floor = 2,
                        Comment = "Comment 16",
                        Model = model1,
                        ManageVLAN = vlan4
                    },
                    new Switch()
                    {
                        IP = "192.168.0.18",
                        MAC = "E8:86:11:C1:CC:7A",
                        SerialNumber = "0017",
                        InventoryNumber = "000/017",
                        BuyDate = new DateTime(2020, 01, 17),
                        InstallDate = new DateTime(2020, 02, 17),
                        Floor = 1,
                        Comment = "Comment 17",
                        Model = model2,
                        ManageVLAN = vlan4
                    },
                    new Switch()
                    {
                        IP = "192.168.0.19",
                        MAC = "57:24:18:1F:F8:25",
                        SerialNumber = "0018",
                        InventoryNumber = "000/018",
                        BuyDate = new DateTime(2020, 01, 18),
                        InstallDate = new DateTime(2020, 02, 18),
                        Floor = 2,
                        Comment = "Comment 18",
                        Model = model3,
                        ManageVLAN = vlan4
                    },
                    new Switch()
                    {
                        IP = "192.168.0.20",
                        MAC = "C1:32:43:4D:29:7A",
                        SerialNumber = "0019",
                        InventoryNumber = "000/019",
                        BuyDate = new DateTime(2020, 01, 19),
                        InstallDate = new DateTime(2020, 02, 19),
                        Floor = 1,
                        Comment = "Comment 19",
                        Model = model4,
                        ManageVLAN = vlan4
                    },
                    new Switch()
                    {
                        IP = "192.168.0.21",
                        MAC = "93:B2:E0:CA:F6:DD",
                        SerialNumber = "0020",
                        InventoryNumber = "000/020",
                        BuyDate = new DateTime(2020, 01, 20),
                        InstallDate = new DateTime(2020, 02, 20),
                        Floor = 2,
                        Comment = "Comment 20",
                        Model = model5,
                        ManageVLAN = vlan4
                    },
                    new Switch()
                    {
                        IP = "192.168.0.22",
                        MAC = "60:35:7B:A9:90:4E",
                        SerialNumber = "0021",
                        InventoryNumber = "000/021",
                        BuyDate = new DateTime(2020, 01, 21),
                        InstallDate = new DateTime(2020, 02, 21),
                        Floor = 1,
                        Comment = "Comment 21",
                        Model = model1,
                        ManageVLAN = vlan5
                    },
                    new Switch()
                    {
                        IP = "192.168.0.23",
                        MAC = "AE:F8:39:F0:46:1D",
                        SerialNumber = "0022",
                        InventoryNumber = "000/022",
                        BuyDate = new DateTime(2020, 01, 22),
                        InstallDate = new DateTime(2020, 02, 22),
                        Floor = 2,
                        Comment = "Comment 22",
                        Model = model2,
                        ManageVLAN = vlan5
                    },
                    new Switch()
                    {
                        IP = "192.168.0.24",
                        MAC = "E4:2F:DE:A6:E8:F7",
                        SerialNumber = "0023",
                        InventoryNumber = "000/023",
                        BuyDate = new DateTime(2020, 01, 23),
                        InstallDate = new DateTime(2020, 02, 23),
                        Floor = 1,
                        Comment = "Comment 23",
                        Model = model3,
                        ManageVLAN = vlan5
                    },
                    new Switch()
                    {
                        IP = "192.168.0.25",
                        MAC = "B3:EC:B7:33:76:57",
                        SerialNumber = "0024",
                        InventoryNumber = "000/024",
                        BuyDate = new DateTime(2020, 01, 24),
                        InstallDate = new DateTime(2020, 02, 24),
                        Floor = 2,
                        Comment = "Comment 24",
                        Model = model4,
                        ManageVLAN = vlan5
                    },
                    new Switch()
                    {
                        IP = "192.168.0.26",
                        MAC = "B3:EC:B7:33:76:57",
                        SerialNumber = "0025",
                        InventoryNumber = "000/025",
                        BuyDate = new DateTime(2020, 01, 25),
                        InstallDate = new DateTime(2020, 02, 25),
                        Floor = 1,
                        Comment = "Comment 25",
                        Model = model5,
                        ManageVLAN = vlan5
                    }
                    );

                context.SaveChanges();

            }
        }
    }
}
