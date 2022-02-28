using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GOT.DBContext;
using GOT.Models;
using GOT.Services;

namespace GOT.Controllers
{
    public class OdznakiController : Controller
    {
        private readonly IOdznakiService _service;

        public OdznakiController(IOdznakiService service)
        {
            _service = service;
        }

        // GET: Odznaki
        public async Task<IActionResult> Index()
        {
            var odznaki = _service.GetOdznaki(1);
            return View(odznaki);
        }

        // GET: Odznaki/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var odznakaResultView = _service.GetOdznakaResultView(id.Value);

            if (odznakaResultView == null)
            {
                return NotFound();
            }

            return View(odznakaResultView);
        }

        // private bool OdznakaExists(int id)
        // {
        //     return _.Odznaki.Any(e => e.ID == id);
        // }
    }
}
