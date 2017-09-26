using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oefTV
{ 
    class TV
    {
        private string _afbeelding;
        private int _beeldgrootte;
        private int _kanaal;
        private int _herz;
        private string _merk;
        private bool _power;
        private bool _teletekst;
        private string _type;
        private int _volume;

        public TV(string merk, string type, int herz, int beeldgrootte, string afbeelding)
        {
            Afbeelding = afbeelding;
            Beeldgrootte = beeldgrootte;
            Herz = herz;
            Merk = merk;
            Type = type;
        }

        public TV() : this("", "", 0, 0, "") { }

        public string Afbeelding { get => _afbeelding; set => _afbeelding = value; }
        public int Beeldgrootte { get => _beeldgrootte; set => _beeldgrootte = value; }
        public int Herz { get => _herz; set => _herz = value; }
        public string Merk { get => _merk; set => _merk = value; }
        public bool Power { get => _power; set => _power = value; }
        public bool Teletekst { get => _teletekst; set => _teletekst = value; }
        public string Type { get => _type; set => _type = value; }
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
            return string.Format("Merk: {0}\nType: {1}\nHerz: {2}\nBeeldgrootte: {3}", Merk, Type, Herz, Beeldgrootte);
        }
    }
}
