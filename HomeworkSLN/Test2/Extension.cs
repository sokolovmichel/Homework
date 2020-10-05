using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test2
{
    public static class Extension
    {
        public static string GetElement(this List<string> list, int i)
        {
            string myString = list.ElementAt(i);
            return myString;

        }
    }
}
