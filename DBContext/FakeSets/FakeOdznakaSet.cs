using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GOT.Models;

namespace GoTestsN.FakeSets
{
    internal class FakeOdznakaSet : FakeDbSet<Odznaka>
    {
        public override Odznaka Find(params object[] keyValues)
        {
            return this.SingleOrDefault(d => d.ID == (int)keyValues.Single());
        }
    }
}