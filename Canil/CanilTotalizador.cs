using System;
using System.Collections.Generic;
using System.Text;

namespace Canil
{
    class CanilTotalizador
    {
        public CanilTotalizador(string canil, double distancia, double total)
        {
            Canil = canil;
            Distancia = distancia;
            Total = total;
        }

        public string Canil { get; set; }
        public double Distancia { get; set; }
        public double Total { get; set; }
    }
}

