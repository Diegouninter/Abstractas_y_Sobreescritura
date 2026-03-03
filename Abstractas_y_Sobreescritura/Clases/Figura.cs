using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstractas_y_Sobreescritura.Clases
{
        public abstract class Figura
        {
            public string Color { get; private set; }

            protected Figura(string color)
            {
                Color = color;
            }

            public abstract double CalcularArea();
            public abstract double CalcularPerimetro();

            public virtual void MostrarInformacion()
            {
                Console.WriteLine($"Tipo: {GetType().Name}");
                Console.WriteLine($"Color: {Color}");
                Console.WriteLine($"Área: {CalcularArea():0.###}");
                Console.WriteLine($"Perímetro: {CalcularPerimetro():0.###}");
            }

            public void CambiarColor(string nuevoColor)
            {
                if (string.IsNullOrWhiteSpace(nuevoColor))
                    throw new ArgumentException("El color no puede ser vacío.", nameof(nuevoColor));
                Color = nuevoColor;
            }
        }
}



