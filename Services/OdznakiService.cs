using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GOT.DBContext;
using GOT.Migrations;
using GOT.Models;
using GoTestsN;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;

namespace GOT.Services
{
    public class OdznakiService : IOdznakiService
    {
        private readonly IGotContext _context;

        public OdznakiService()
        {
            _context = new GOTContext();
        }
        public OdznakiService(FakeGotContext context)
        {
            _context = context;
        }

        public IEnumerable<Odznaka> GetOdznaki(int id)
        {
            var odznakiUzytkownika =  _context.Odznaki
                .Where(o => o.UzytkownikID == id)
                .OrderBy(odznaka => odznaka.Rodzaj)
                .ThenBy(odznaka => odznaka.Stopien)
                .ToList();

            var result =  CountPointsForNextLevel(odznakiUzytkownika);
            return result;
        }

        public OdznakaResultView GetOdznakaResultView(int id)
        {
            var result = new OdznakaResultView();
            result.ZgloszeniaDoOdznaki =  _context.ZgloszeniaWycieczek
                .Where(z => z.OdznakaID == id)
                .Include(z => z.Wycieczka)
                .OrderByDescending(z => z.DataOdbyciaWycieczki)
                .ToList();

            result.Odznaka = _context.Odznaki.Single(o => o.ID == id);

            int punkty = result.ZgloszeniaDoOdznaki.Sum(z => z.Punkty) + (result.Odznaka.PunktyPrzeniesione == null ? 0 : result.Odznaka.PunktyPrzeniesione.Value);

            result.Punkty = Math.Min(punkty, result.Odznaka.WymaganePunkty);

            result.PunktyNaNastepnyStopien = Math.Max(0, punkty - result.Odznaka.WymaganePunkty);

            return result;
        }

        private IEnumerable<Odznaka> CountPointsForNextLevel(List<Odznaka> odznaki)
        {
            for (int i = 0; i < odznaki.Count; i++)
            {
                var odznaka = odznaki[i];
                if (odznaka.PunktyPrzeniesione == null)
                {
                    int punkty = _context.ZgloszeniaWycieczek
                        .Where(z => z.OdznakaID == odznaka.ID)
                        .Include(z => z.Wycieczka)
                        .OrderByDescending(z => z.DataOdbyciaWycieczki)
                        .Sum(z => z.Punkty);

                    if (punkty > odznaka.WymaganePunkty)
                    {
                        if (Enumerable.Range(0, 3).Contains(odznaka.Stopien))
                        {
                            odznaki[i + 1].PunktyPrzeniesione = punkty - odznaka.WymaganePunkty;
                            _context.SaveChanges();
                        }
                    }
                }
            }

            return odznaki;
        }
    }
}