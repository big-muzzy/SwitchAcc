using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SwitchAcc.Models;
using System.Text.RegularExpressions;
using SwitchAcc.ViewModels;

namespace SwitchAcc.Controllers
{
    public class HomeController : Controller
    {
        private ISwitchesRepositary repositary;
        private ISwModelRepositary modelsRepositary;
        private IVLANRepositary vlansRepositary;

        public HomeController(ISwitchesRepositary repo, ISwModelRepositary swRepo, IVLANRepositary vlanRepo)
        {
            repositary = repo;
            modelsRepositary = swRepo;
            vlansRepositary = vlanRepo;
        }

        public int PageSize = 5;

        public IActionResult Index(int page = 1)
        {
            return View(new SwitchesListViewModel
            {
                Switches = repositary.SwitchesRepositary
                    .Skip((page - 1) * PageSize)
                    .Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    Currentpage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = repositary.SwitchesRepositary.Count()
                }
            }); 
        }

        [HttpGet]
        public IActionResult EditSwitch(int? switchid = null)
        {
            //return View(repositary.SwitchesRepositary.SingleOrDefault(item => item.ID == switchid));
            return View(new SwitchEditViewModel()
            {
                Item = repositary.SwitchesRepositary.SingleOrDefault(item => item.ID == switchid),
                ModelsList = modelsRepositary.SwModelRepositary,
                VLANsList = vlansRepositary.VLANRepositary
            });
        }

        [HttpPost]
        public IActionResult Delete(int switchid)
        {
            repositary.Delete(switchid);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult EditSwitch(Models.Switch item)
        {
            ModelState.Remove("item.ManageVLAN.Name");
            ModelState.Remove("item.Model.Name");

            item.Model = modelsRepositary.SwModelRepositary.SingleOrDefault(model => model.ID == item.Model.ID);
            item.ManageVLAN = vlansRepositary.VLANRepositary.SingleOrDefault(vlan => vlan.ID == item.ManageVLAN.ID);

            if (item.Model is null) ModelState.AddModelError("Model", "Некорректная можель коммутатора");
            if (!isValidIp(item.IP)) ModelState.AddModelError("IP", "Некорректный IP адрес");
            if (!isValidMac(item.MAC)) ModelState.AddModelError("MAC", "Некорректный MAC адрес");
            if (string.IsNullOrWhiteSpace(item.SerialNumber)) ModelState.AddModelError("SerialNumber", "Некорректный серийный номер");

            if (ModelState.IsValid) item.ID = repositary.Save(item);
            
            ModelState.Clear();
            return RedirectToAction("EditSwitch", new { switchid = item.ID });
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Contacts()
        {
            return View();
        }

        private bool isValidIp(string ipAddress)
        {
            if (string.IsNullOrEmpty(ipAddress)) return true; //на случай, если еще не установлен.

            if (ipAddress.Count(c => c == '.') != 3) return false;
            System.Net.IPAddress address;
            bool isValid = System.Net.IPAddress.TryParse(ipAddress, out address);
            if (!isValid) return false;

            return true;
        }

        [AcceptVerbs("GET", "POST")]
        public IActionResult CheckValidIP([Bind(Prefix = "Item.IP")]string ipAddress)
        {
            if (!isValidIp(ipAddress)) return Json("Некорректный IP адрес");
            return Json(true);
        }


        private bool isValidMac(string macAddress)
        {
            Regex rx = new Regex(@"^([0-9A-Fa-f]{2}[:-]){5}([0-9A-Fa-f]{2})$");
            if (!rx.IsMatch(macAddress)) return false;
            return true;
        }

        [AcceptVerbs("GET", "POST")]
        public IActionResult CheckValidMAC([Bind(Prefix = "Item.MAC")] string macAddress)
        {
            if (!isValidMac(macAddress)) Json("Некорректный MAC адрес");
            return Json(true);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
