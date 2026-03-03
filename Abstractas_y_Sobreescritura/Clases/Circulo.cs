using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstractas_y_Sobreescritura.Clases
{
    internal class Circulo: Figura
    {
        public double Radio { get; }

        public Circulo(string color, double radio) : base(color)
        {
            Radio = radio;
        }

        public Circulo(double radio, string color) : base(color)
        {
            Radio = radio;
        }

        public override double CalcularArea() => Math.PI * Radio * Radio;

        public override double CalcularPerimetro() => 2 * Math.PI * Radio;

    }
}
