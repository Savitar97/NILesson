using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CollectionGyak
{
    class Car
    {
        public string Rendszam{get;}
        public Car(string rendszam)
        {
            if (rendszam!=null)
            {
                this.Rendszam = rendszam;
            }
            else if (string.IsNullOrWhiteSpace(rendszam))
            {
                throw new ArgumentException("A rendszám nem lehet üres!");
            }
            else
            {
                throw new ArgumentNullException($"{nameof(rendszam)} Hibás megadott rendszám!");
            }
        }
    }
}
