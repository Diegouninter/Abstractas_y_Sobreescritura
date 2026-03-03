using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstractas_y_Sobreescritura.Clases
{
    internal class Rectangulo: Figura
    {
        public double Base { get; }
        public double Altura { get; }

        public Rectangulo(string color, double @base, double altura) : base(color)
        {
            Base = @base;
            Altura = altura;
        }

        public Rectangulo(double @base, double altura, string color) : base(color)
        {
            Base = @base;
            Altura = altura;
        }

        public override double CalcularArea() => Base * Altura;

        public override double CalcularPerimetro() => 2 * (Base + Altura);
    }
}
