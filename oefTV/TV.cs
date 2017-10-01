using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oefTV
{ 
    class TV: ElektronischToestel
    {
        
        private int _beeldgrootte;
        private int _kanaal;
        private int _herz;

        private bool _teletekst;

        private int _volume;

        public TV(string merk, string type, int herz, int beeldgrootte, string afbeelding): base(afbeelding, merk, type)
        {
            Beeldgrootte = beeldgrootte;
            Herz = herz;
        }

        public TV() : this("", "", 0, 0, "") { }

        public int Beeldgrootte { get => _beeldgrootte; set => _beeldgrootte = value; }
        public int Herz { get => _herz; set => _herz = value; }
        public bool Teletekst { get => _teletekst; set => _teletekst = value; }
        public int Volume
        {
            get => _volume; set
            {
                if (Power)
                {
                    _volume = value;
                }
            }
        }

        public int Kanaal
        {
            get => _kanaal; set
            {
                if (Power)
                {
                    _kanaal = value;
                }
            }
        }
        public override string ToString()
        {
            return string.Format("{0}\nHerz: {1}\nBeeldgrootte: {2}\nKanaal: {3}\nVolume: {4}", base.ToString(), Herz, Beeldgrootte, Kanaal, Volume);
        }
    }
}
