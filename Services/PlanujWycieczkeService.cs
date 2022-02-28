using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using GOT.DBContext;
using GOT.Models;
using GoTestsN;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace GOT.Services
{
    public class PlanujWycieczkeService : IPlanujWycieczkeService
    {
        private readonly IGotContext _context;

        public PlanujWycieczkeService()
        {
            _context = new GOTContext();
        }
        public PlanujWycieczkeService(FakeGotContext context)
        {
            _context = context;
        }

        public Dictionary<Wycieczka, string> GetSharedWycieczki()
        {
            var result = _context.Wycieczki.Where(w => w.CzyPubliczna)
                .Include(w => w.Trasy)
                .Include(w => w.Zgloszenia
                    .OrderBy(z => z.Status)
                    .ThenBy(z => z.DataZmianyStatusu))
                .Select(w => new { Wycieczka = w, Zgloszenie = w.Zgloszenia.First() });
                    // .ToDictionary(w=> w.Wycieczka, w => w.Zgloszenie.Status == 0 ? w.Zgloszenie.Punkty.ToString() : " - ");
            
            return new Dictionary<Wycieczka, string>();
        }
        public IEnumerable<PunktTrasy> GetPoints()
        {
            var result = _context.PunktyTrasy.ToList();
            
            return result;
        }

        public List<Trasa> GetTrailsFromPoint(string pointName)
        {
            var result = _context.Trasy
                                                .Where(t => t.PunktStartowy.Nazwa == pointName)
                                                .Include(t => t.PunktStartowy)
                                                .Include(t => t.PunktKoncowy)
                                                .ToList();

            return result;

        }
        public Wycieczka GetTrip(int id)
        {
            var result = _context.Wycieczki
                                                        .Where(w => w.ID == id)
                                                        .First();

            return result;

        }
        public Trasa GetTrail(int id)
        {
            var result = _context.Trasy
                                                        .Where(w => w.ID == id)
                                                        .Include(t => t.PunktKoncowy)
                                                        .Include(t => t.PunktStartowy)
                                                        .First();

            return result;

        }
    }
}