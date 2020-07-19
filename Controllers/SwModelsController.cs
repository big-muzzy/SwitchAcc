using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SwitchAcc.Models;

using SwitchAcc.ViewModels;

namespace SwitchAcc.Controllers
{
    public class SwModelsController : Controller
    {
        private ISwModelRepositary repositary;


        public SwModelsController(ISwModelRepositary repo)
        {
            repositary = repo;
        }

        public int PageSize = 5;

        public IActionResult Index(int page = 1)
        {
            return View(new SwModelsViewModel
            {
                SwModels = repositary.SwModelRepositary
                    .Skip((page - 1) * PageSize)
                    .Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    Currentpage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = repositary.SwModelRepositary.Count()
                }
            });
        }

        [HttpGet]
        public IActionResult EditModel(int? modelid = null)
        {
            return View(repositary.SwModelRepositary.SingleOrDefault(item => item.ID == modelid));
        }

        [HttpPost]
        public IActionResult Delete(int modelid)
        {
            repositary.Delete(modelid);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult EditModel(Models.SwModel item)
        {
            item.ID = repositary.Save(item);
            ModelState.Clear();
            return RedirectToAction("EditModel", new { modelid = item.ID });
        }

    }
}