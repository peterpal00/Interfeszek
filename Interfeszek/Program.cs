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

            GepiJatekos veletlenTipper = new VeletlenTippelo();
            GepiJatekos bejaroTipper = new BejaroTippelo();

            test1.VersenyzoFelvetele(veletlenTipper);
            test1.VersenyzoFelvetele(bejaroTipper);

            test1.Jatek();
            Console.ReadLine();

        }
    }
}
