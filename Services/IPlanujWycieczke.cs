using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GOT.Models;

namespace GOT.Services
{
    public interface IPlanujWycieczkeService
    {
        Dictionary<Wycieczka, string> GetSharedWycieczki();
        IEnumerable<PunktTrasy> GetPoints();
        List<Trasa> GetTrailsFromPoint(string pointID);
        Wycieczka GetTrip(int id);
        Trasa GetTrail(int id);
    }
}