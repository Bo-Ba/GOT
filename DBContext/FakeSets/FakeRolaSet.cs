using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GOT.Models;

namespace GoTestsN.FakeSets
{
    internal class FakeRoleSet : FakeDbSet<Rola>
    {
        public override Rola Find(params object[] keyValues)
        {
            return this.SingleOrDefault(d => d.ID == (int)keyValues.Single());
        }
    }
}