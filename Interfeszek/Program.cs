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
            SzamKitalaloJatek test1 = new SzamKitalaloJatek(5, 51);

            GepiJatekos veletlenTipper = new VeletlenTippelo();
            GepiJatekos bejaroTipper = new BejaroTippelo();
            GepiJatekos logtipper = new LogaritmikusKereso();
            EmberiJatkos ember = new EmberiJatkos();


            test1.VersenyzoFelvetele(veletlenTipper);
            test1.VersenyzoFelvetele(bejaroTipper);
            test1.VersenyzoFelvetele(logtipper);
            //test1.VersenyzoFelvetele(ember);                      //for test 3

            // test 1 - 3
            //test1.Jatek();

            test1.Statisztika(1000);
            Console.ReadLine();

        }
    }
}
