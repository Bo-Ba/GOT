using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GOT.Models;

namespace GoTestsN.FakeSets
{
    internal class FakeWycieczkaSet : FakeDbSet<Wycieczka>
    {
        public override Wycieczka Find(params object[] keyValues)
        {
            return this.SingleOrDefault(d => d.ID == (int)keyValues.Single());
        }

        public IQueryable<Wycieczka> Where (Func<Wycieczka, bool> predicate)
        {
            return this.Where(predicate);
        }   
    }
}