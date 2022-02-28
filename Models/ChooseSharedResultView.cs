using System.Collections.Generic;

namespace GOT.Models
{
    public class ChooseSharedResultView
    {
        public Odznaka Odznaka { get; set; }
        public List<int> punkty { get; set; }
        public int Punkty { get; set;  }
        public int PunktyNaNastepnyStopien { get; set;  }
        public decimal sumaPodejsc { get; set;  }
    }
}
