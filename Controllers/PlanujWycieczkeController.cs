using System;
using System.Collections;
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
    public class PlanujWycieczkeController : Controller
    {
        private readonly IPlanujWycieczkeService _service;
        private static Wycieczka wycieczka = new Wycieczka(){Trasy = new List<Trasa>()};

        public PlanujWycieczkeController(IPlanujWycieczkeService service)
        {
            _service = service;
        }

        // GET: PlanujWycieczke
        public IActionResult ChooseShared()
        {
            var sharedWycieczki = _service.GetSharedWycieczki();
            return View(sharedWycieczki);
        }
        
        public IActionResult Start()
        {
            return View();
        }

        public IActionResult CreateTrip(int? id)
        {
            if (id != null) wycieczka =  _service.GetTrip(id.Value);
            var pointsList =  _service.GetPoints();
            return View(pointsList);
            
        }

        public IActionResult GetPartial(string? pointId, int? trasaId)
        {
            if (trasaId != null)
            {
                PlanujWycieczkeController.wycieczka.Trasy.Add( _service.GetTrail(trasaId.Value));
            }
            var trasy =  Enumerable.Empty<Trasa>();
            if (pointId != null)
            {
                trasy = _service.GetTrailsFromPoint(pointId);
            }
            
            return PartialView("_TrasyPartial", (wycieczka, trasy));
        }
    }
}
