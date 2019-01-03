using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary2;

namespace AdventurWorks
{
    public class Data
    {
        public void Main()
        {
            AdventureWorks2014Entities e = new AdventureWorks2014Entities();
            foreach (var item in e.Addresses)
            {
               
            }

        }

        public List<Address> Addresses()
        {
            List<Address> list = new List<Address>();
            AdventureWorks2014Entities e = new AdventureWorks2014Entities();
            foreach (var item in e.Addresses)
            {
                list.Add(item);
            }
            return list;
        }
       
    }
}
