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

        public void Nyert()
        {
            nyertDB++;
        }

        public void Veszitett()
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
            int tipp = (alsoHatar + felsoHatar) / 2;
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
}
