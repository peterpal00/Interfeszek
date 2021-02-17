using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfeszek
{
    class Program
    {
        static void Main(string[] args)
        {
            SzamKitalaloJatek test1 = new SzamKitalaloJatek(5, 50);

            ITippelo veletlenTipper = new VeletlenTippelo();
            ITippelo bejaroTipper = new BejaroTippelo();


        }
    }
}
