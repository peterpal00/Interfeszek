using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfeszek
{
    interface IJatekos
    {
        void Nyert();
        void Veszitett();
    }

    interface ITippelo : IJatekos
    {
        void JatekIndul(int alsoHatar, int felsoHatar);
        int KovetkezoTipp();
    }
}
