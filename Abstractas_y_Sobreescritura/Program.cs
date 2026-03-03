using Abstractas_y_Sobreescritura.Clases;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace Abstractas_y_Sobreescritura
{
    class Program
    {
        /// <summary>
        /// DEGM
        /// 03/03/2026
        /// Esta aplicación captura un círculo, un rectángulo y un triángulo,
        /// luego muestra la información de cada figura y calcula los totales.
        /// </summary>
        static void Main()
        {
            CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;

            var figuras = new List<Figura>();

            Console.Clear();

            // 1) Capturar CÍRCULO
            Console.WriteLine("\n--- Círculo ---");
            double radio = LeerDoublePositivo("Radio: ");
            string colorCirculo = LeerTextoNoVacio("Color: ");
            figuras.Add(new Circulo(radio, colorCirculo));

            // 2) Capturar RECTÁNGULO
            Console.WriteLine("\n--- Rectángulo ---");
            double @baseR = LeerDoublePositivo("Base: ");
            double alturaR = LeerDoublePositivo("Altura: ");
            string colorRect = LeerTextoNoVacio("Color: ");
            figuras.Add(new Rectangulo(@baseR, alturaR, colorRect));

            // 3) Capturar TRIÁNGULO (con lados A,B,C)
            Console.WriteLine("\n--- Triángulo ---");
            double @baseT = LeerDoublePositivo("Base: ");
            double alturaT = LeerDoublePositivo("Altura: ");

            // Lados para el perímetro
            double ladoA = LeerDoublePositivo("Lado A: ");
            double ladoB = LeerDoublePositivo("Lado B: ");
            double ladoC = LeerDoublePositivo("Lado C: ");

            // Validación simple de desigualdad triangular
            while (!EsTrianguloValido(ladoA, ladoB, ladoC))
            {
                Console.WriteLine("Los lados no forman un triángulo válido. Vuelve a introducirlos.");
                ladoA = LeerDoublePositivo("Lado A: ");
                ladoB = LeerDoublePositivo("Lado B: ");
                ladoC = LeerDoublePositivo("Lado C: ");
            }

            string colorTri = LeerTextoNoVacio("Color: ");
            figuras.Add(new Triangulo(@baseT, alturaT, ladoA, ladoB, ladoC, colorTri));

            // 4) Mostrar TODAS las figuras
            Console.WriteLine("\n==============================");
            Console.WriteLine("=== Información de figuras ===");
            Console.WriteLine("==============================");
            for (int i = 0; i < figuras.Count; i++)
            {
                Console.WriteLine($"\n[{i}] ------------------------");
                figuras[i].MostrarInformacion();
            }

            // 5) Cálculos de totales (área y perímetro)
            double areaTotal = 0;
            double perimetroTotal = 0;
            foreach (var f in figuras)
            {
                areaTotal += f.CalcularArea();
                perimetroTotal += f.CalcularPerimetro();
            }

           

            // 6) (Opcional) Cambiar color de UNA figura y mostrar su info actualizada
            Console.Write("\n¿Deseas cambiar el color de alguna figura? (s/n): ");
            var resp = Console.ReadLine()?.Trim().ToLowerInvariant();
            if (resp == "s" || resp == "si" || resp == "sí")
            {
                int indice = LeerIndice($"Ingresa el índice (0 - {figuras.Count - 1}): ", 0, figuras.Count - 1);
                string nuevoColor = LeerTextoNoVacio("Nuevo color: ");
                figuras[indice].CambiarColor(nuevoColor);

                Console.WriteLine("\n=== Figura actualizada ===");
                figuras[indice].MostrarInformacion();
            }

            Console.WriteLine("\nProceso terminado. Presiona una tecla para salir...");
            Console.ReadKey(true);
        }
        static double LeerDoublePositivo(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                var txt = Console.ReadLine();
                if (double.TryParse(txt, NumberStyles.Float, CultureInfo.InvariantCulture, out double v) && v > 0)
                    return v;
                Console.WriteLine("Debe ser un número positivo (usa punto para decimales, ej: 3.5).");
            }
        }

        static int LeerIndice(string prompt, int min, int max)
        {
            while (true)
            {
                Console.Write(prompt);
                var txt = Console.ReadLine();
                if (int.TryParse(txt, out int i) && i >= min && i <= max)
                    return i;
                Console.WriteLine($"Índice inválido. Debe estar entre {min} y {max}.");
            }
        }

        static string LeerTextoNoVacio(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                var txt = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(txt))
                    return txt.Trim();
                Console.WriteLine("El texto no puede estar vacío.");
            }
        }

        static bool EsTrianguloValido(double a, double b, double c)
        {
            return a + b > c && a + c > b && b + c > a;
        }
    }
}