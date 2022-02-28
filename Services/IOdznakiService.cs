using System.Collections.Generic;
using System.Threading.Tasks;
using GOT.Models;

namespace GOT.Services
{
    public interface IOdznakiService
    {
        IEnumerable<Odznaka> GetOdznaki(int id);
        OdznakaResultView GetOdznakaResultView(int id);
    }
}
