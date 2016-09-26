using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionsTest
{
    class FruttaStore
    {
        ArrayList store = new ArrayList();
        
        public void AddRange(params string[] frutti)
        {
            store.AddRange(frutti);
        } 

        public void Add(string frutto)
        {
            store.Add(frutto);
        }

        public void Sort()
        {
            store.Sort();
        }

        public string[] ToArray()
        {
            return (string[])store.ToArray(typeof(string));
        }
    }
}
