using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIWar
{
    class Tools
    {
        static public List<T> RamdomListPick<T>(List<T> list,int n)
        {
            List<T> list2 = new List<T>(list);
            List<T> list3 = new List<T>();
            Random rand = new Random();
            for (int i=0; i<n;++i)
            {
                T elem = list2[rand.Next(list2.Count)];
                list3.Add(elem);
                list2.Remove(elem);
            }
            return list3;
        }
    }
}
