using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oefTV
{
    class Warmwaterkoker: ElektronischToestel
    {
        private decimal _inhoud;

        public Warmwaterkoker(string merk, string type,string afbeelding, decimal inhoud): base(afbeelding, merk, type)
        {
            Inhoud = inhoud;
        }

        public decimal Inhoud { get => _inhoud; set => _inhoud = value; }

        public override string ToString()
        {
            return string.Format("{0}\nInhoud: {1}", base.ToString(), Inhoud);
        }
    }
}
