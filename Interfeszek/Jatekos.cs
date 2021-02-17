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
            return r.Next(alsoHatar, felsoHatar);
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
            return aktualis++;
        }
    }
}
