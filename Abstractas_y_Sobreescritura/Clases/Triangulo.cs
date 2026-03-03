using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstractas_y_Sobreescritura.Clases
{
    internal class Triangulo: Figura
    {

        public double CatetoA { get; }
        public double CatetoB { get; }

        public Triangulo(string color, double catetoA, double catetoB) : base(color)
        {
            CatetoA = catetoA;
            CatetoB = catetoB;
        }

       
        public Triangulo(double bbase, double altura, double ladoA, double ladoB, double ladoC, string color) : base(color)
        {
            CatetoA = bbase;
            CatetoB = altura;
        }

        private double Hipotenusa => Math.Sqrt(CatetoA * CatetoA + CatetoB * CatetoB);

        public override double CalcularArea() => (CatetoA * CatetoB) / 2.0;

        public override double CalcularPerimetro() => CatetoA + CatetoB + Hipotenusa;
    }
}
