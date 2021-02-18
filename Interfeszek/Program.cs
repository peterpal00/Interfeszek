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
            test1.VersenyzoFelvetele(ember);

            test1.Jatek();
            Console.ReadLine();

        }
    }
}
