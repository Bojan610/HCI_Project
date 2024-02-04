using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace pz1
{
    public class Automobili
    {
        public string Model { get; set; }
        public string Godina { get; set; }
        public int Snaga { get; set; }
        public ImageSource Slika { get; set; }
        public string Tekst { get; set; }
        public string Boja { get; set; }

        public Automobili()
        {

        }

        public Automobili(string model, string godina, int snaga, ImageSource sl, string t, string b)
        {
            Model = model;
            Godina = godina;
            Snaga = snaga;
            Slika = sl;
            Tekst = t;
            Boja = b;
        }

    }
}
