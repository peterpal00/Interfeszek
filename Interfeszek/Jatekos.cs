using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfeszek
{
    public abstract  class GepiJatekos : ITippelo
    {
        protected int alsoHatar;                                        // tippeles also hatara
        protected int felsoHatar;                                       // tippeles felso hatara

        public virtual void JatekIndul(int alsoHatar, int felsoHatar)
        {
            this.alsoHatar = alsoHatar;
            this.felsoHatar = felsoHatar;
        }

        protected int nyertDB = 0;
        protected int veszitettDB = 0;

        public virtual void Nyert()
        {
            nyertDB++;
        }

        public virtual void Veszitett()
        {
            veszitettDB++;
        }

        abstract public int KovetkezoTipp();
    }

    class VeletlenTippelo : GepiJatekos
    {
        public override int KovetkezoTipp()
        {
            Random r = new Random();
            int tipp = r.Next(alsoHatar, felsoHatar);
            System.Threading.Thread.Sleep(10);                              // varni kell, hogy ne dobjon egymas utan a random azonos szamokat
            Console.WriteLine("Veletlentippelo tippel : {0}", tipp);
            return tipp;
        }
    }

    class BejaroTippelo : GepiJatekos
    {
        protected int aktualis;

        public override void JatekIndul(int alsoHatar, int felsoHatar)
        {
            base.JatekIndul(alsoHatar, felsoHatar);
            aktualis = this.alsoHatar;
        }

        public override int KovetkezoTipp()
        {
            Console.WriteLine("Bejarotippelo tippel : {0}", aktualis);
            return aktualis++;
        }
    }

    class LogaritmikusKereso : GepiJatekos, IOkosTippelo
    {
        public override int KovetkezoTipp()
        {
            int tipp =(alsoHatar + felsoHatar) / 2;
            Console.WriteLine("Logaritmikustippelo tippel: {0}", tipp);
            return tipp;
        }

        public void Kisebb()
        {
            felsoHatar--;
        }

        public void Nagyobb()
        {
            alsoHatar++;
        }
    }

    // Az EmberiJatekos-t a GepiJatekos leszarmazottjakent adtam meg, mert a jatekban GepiJatekos-ra van megirva a kod
    class EmberiJatkos : GepiJatekos, IOkosTippelo
    {
        public override void JatekIndul(int alsoHatar, int felsoHatar)
        {
            Console.WriteLine("A jatek elindult a kovetkezo hatarok kozott: {0}-{1}", alsoHatar, felsoHatar);
        }

        public void Kisebb()
        {
            Console.WriteLine("*Az elozo tippnel kisebb a keresett szam!");
        }

        public void Nagyobb()
        {
            Console.WriteLine("*Az elozo tippnel nagyobb a keresett szam!");
        }

        public override int KovetkezoTipp()
        {
            Console.WriteLine("Add meg a kovetkezo tippet:");
            string input = Console.ReadLine();
            int inputNum = 0;
            
            while(!(CheckInput(input, ref inputNum)))
            {
                Console.WriteLine("*Egesz szamot adj meg!");
                input = Console.ReadLine();
                CheckInput(input, ref inputNum);
            }
            Console.WriteLine("*Emberi tipp: {0}", inputNum);

            return inputNum;
        }       

        public override void Nyert()
        {
            Console.WriteLine("*Nyertel!");
        }

        public override void Veszitett()
        {
            Console.WriteLine("*Veszitettel!");
        }

        // ellenorzi, hogy a megadott szam egesz szam-e
        public bool CheckInput(string input, ref int num)
        {
            return int.TryParse(input, out num);
        }

    }
}
