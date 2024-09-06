using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AreasFigurasGeometricas
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double radioAr, baseAr, alturaAr, ladoAr, area;
            byte opcion;

           Console.WriteLine("1. Círculo");
            Console.WriteLine("2. Triangulo");
            Console.WriteLine("3. Cuadrado");

            Console.Write("Escoge una opción y calcularé su área: ");
            opcion = Convert.ToByte(Console.ReadLine());

            switch (opcion)
            {
                case 1:
                    Console.Write("Dame el valor del radio de tu círculo: ");
                    radioAr = Convert.ToDouble(Console.ReadLine());

                    area = Circulo(radioAr);

                    Console.WriteLine("El área es: {0}", area);
                    break;
                case 2:
                    Console.Write("Dame el valor de la base de tu triangulo: ");
                    baseAr = Convert.ToDouble(Console.ReadLine());

                    Console.Write("Dame el valor de la altura de tu triangulo: ");
                    alturaAr = Convert.ToDouble(Console.ReadLine());

                    area = Triangulo(baseAr, alturaAr);

                    Console.WriteLine("El área es: {0}", area);
                    break;
                case 3:
                    Console.Write("Dame el valor de uno de los lados de tu cuadrado: ");
                    ladoAr = Convert.ToDouble(Console.ReadLine());

                    area = Cuadrado(ladoAr);

                    Console.WriteLine("El área es: {0}", area);
                    break;
            }
        }

        static double Circulo(double radioPa)
        {
            double area;

            area = Math.PI * (radioPa * radioPa);

            return area;
        }

        static double Triangulo(double basePa, double alturaPa)
        {
            double area;

            area = (basePa * alturaPa) / 2;

            return area;
        }

        static double Cuadrado(double ladoPa)
        {
            double area;

            area = ladoPa * ladoPa;

            return area;
        }

    }
}

