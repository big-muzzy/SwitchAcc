using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SwitchAcc.Models;
using SwitchAcc.ViewModels;

namespace SwitchAcc.Controllers
{
    public class VLANsController : Controller
    {
        private IVLANRepositary repositary;


        public VLANsController(IVLANRepositary repo)
        {
            repositary = repo;
        }

        public int PageSize = 5;

        public IActionResult Index(int page = 1)
        {
            return View(new VLANsViewModel
            {
                VLANs = repositary.VLANRepositary
                    .Skip((page - 1) * PageSize)
                    .Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    Currentpage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = repositary.VLANRepositary.Count()
                }
            });
        }

        [HttpGet]
        public IActionResult EditVlan(int? vlanid = null)
        {
            return View(repositary.VLANRepositary.SingleOrDefault(item => item.ID == vlanid));
        }

        [HttpPost]
        public IActionResult Delete(int vlanid)
        {
            repositary.Delete(vlanid);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult EditVlan(Models.VLAN item)
        {
            item.ID = repositary.Save(item);
            ModelState.Clear();
            return RedirectToAction("EditVlan", new { vlanid = item.ID });
        }
    }
}