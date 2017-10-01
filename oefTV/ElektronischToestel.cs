using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oefTV
{
    class ElektronischToestel
    {
        private string _afbeelding;
        private string _merk;
        private bool _power;
        private string _type;

        public ElektronischToestel(string afbeelding, string merk, string type)
        {
            Afbeelding = afbeelding;
            Merk = merk;
            Type = type;
            Power = false;
        }

        public string Afbeelding { get => _afbeelding; set => _afbeelding = value; }
        public string Merk { get => _merk; set => _merk = value; }
        public string Type { get => _type; set => _type = value; }
        public bool Power { get => _power; set => _power = value; }

        public override string ToString()
        {
            return string.Format("Merk: {0}\nType: {1}\nPower: {2}", Merk, Type, Power);
        }

    }
}
