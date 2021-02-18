using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfeszek
{
    class SzamKitalaloJatek
    {
        const byte MAX_VERSENYZO = 5;                                           // a versenyzok maximalis szama
        protected GepiJatekos[] versenyzok = new GepiJatekos[MAX_VERSENYZO];          // a versenyzok tombje
        protected byte versenyzoN = 0;                                          // szamolja hanz versenyzot vettunk fel


        // felvesz egy versenyzo tipust a tombbe
        public void VersenyzoFelvetele(GepiJatekos versenyzo)
        {
            versenyzok[versenyzoN++] = versenyzo;
        }


        protected int alsoHatar;                                                // a tippeles also hatara
        protected int felsoHatar;                                               // a tippeles felso hatara


        // konstruktor amely erteket ad a tippelesi hataroknak
        public SzamKitalaloJatek(int a_hatar, int f_hatar)
        {
            this.alsoHatar = a_hatar;
            this.felsoHatar = f_hatar;
        }

        protected int cel;                                                      // az a szam amit ki kell talalni

        // kisorsolja a tippelendo szamot
        // majd beallitja a jatekosoknak a hatarokat(JatekIndul)
        protected void VersenyIndul()
        {
            Console.WriteLine("Verseny indul");

            Random r = new Random();
            cel = r.Next(alsoHatar, felsoHatar);
            System.Threading.Thread.Sleep(1);                                 // muszaj varni mert a cel random es a tippelo random mindig azonos erteket hoz ki
            Console.WriteLine("Cel: {0}", cel);

            for(int i = 0; i < versenyzoN; i++)
            {
                versenyzok[i].JatekIndul(alsoHatar, felsoHatar);
            }
        }

        // minden jatekos tippel es eldonti, hogz jo-e a tipp
        protected bool MindenkiTippel()
        {
            Console.WriteLine("Mindenki tippel");
            bool[] isThereWinner = new bool[versenyzoN+1];                      // a tomb utolso elemeben van eltarolva az hogz volt-e nzertes a korben
            for(int i = 0; i < versenyzoN+1; i++)
            {
                isThereWinner[i] = false;
            }

            for(int i = 0; i < versenyzoN; i++)
            {
                int tipp = versenyzok[i].KovetkezoTipp();

                if(cel == tipp)
                {
                    Console.WriteLine("Valaki nyert!!!");
                    versenyzok[i].Nyert();
                    isThereWinner[i] = true;
                    isThereWinner[versenyzoN] = true;                           // beallitja a tomb utolso elemet, mivel volt nyertes
                }
                else if (versenyzok[i] is IOkosTippelo)                   // ha logaritmikus a tippelo, akkor megvalositja az IOkosTippelo interfacet
                {
                    if(cel < tipp)
                    {
                        (versenyzok[i] as IOkosTippelo).Kisebb();
                    }
                    else
                    {
                        (versenyzok[i] as IOkosTippelo).Nagyobb();
                    }
                }
            }


            if (isThereWinner[versenyzoN])
            {
                for (int i = 0; i < versenyzoN; i++)
                {
                    if(!isThereWinner[i])
                    {
                        versenyzok[i].Veszitett();
                    }
                }
            }
            
            if(isThereWinner[versenyzoN])
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Jatek()
        {
            Console.WriteLine("!Jatek KEZDODIK!!");
            this.VersenyIndul();
            while (!MindenkiTippel());
        }

        public void Statisztika(int korokSzama)
        {
            for(int i = 0; i < korokSzama; i++)
            {
                Jatek();
            }

            Console.WriteLine("\n S T A T I SZ T I K A \n");

            for(int i = 0; i < versenyzoN; i++)
            {
                Console.WriteLine("{0}. jatekos ({1}), NY:{2}  V:{3}", i, versenyzok[i].ToString(), versenyzok[i].HanyszorNyert(), versenyzok[i].HanyszorVesztett());               
            }

        }
    }
}
