using System.Collections.Generic;

namespace GOT.Models
{
    public class OdznakaResultView
    {
        public Odznaka Odznaka { get; set; }
        public List<ZgloszenieWycieczki> ZgloszeniaDoOdznaki { get; set; }
        public int Punkty { get; set;  }
        public int PunktyNaNastepnyStopien { get; set;  }
        public decimal sumaPodejsc { get; set;  }
    }
}
