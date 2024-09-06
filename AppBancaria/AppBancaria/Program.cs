using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppBancaria
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int opcion;
            float gasto;

            Stack<float> gastos = new Stack<float>();

            do
            {
                Console.Clear();
                Console.WriteLine("1. Agregar gasto");
                Console.WriteLine("2. Mostrar gastos del mes");
                Console.WriteLine("3. Pago para no generar intereses");
                Console.WriteLine("4. Salir");

                Console.WriteLine("\nEscoge una opcion: ");
                opcion = Convert.ToInt32(Console.ReadLine());

                Console.Clear();

                switch (opcion)
                {
                    case 1:
                        Console.WriteLine("Monto: $");
                        gasto = Convert.ToSingle(Console.ReadLine());

                        gastos.Push(gasto);
                        break;

                    case 2:
                        Console.WriteLine("Gastos del mes: \n");

                        foreach (float elemento in gastos)
                        {
                            Console.WriteLine("{0}", elemento);
                        }
                        Console.WriteLine("\n Presiona cualquier tecla para continuar...");
                        Console.ReadKey();
                        break;
                    case 3:
                        float total = 0;
                        foreach (float elemento in gastos)
                        {
                            total += elemento;
                        }
                        Console.WriteLine("Pago para no generar intereses: ${0}", total);

                        Console.WriteLine("\n Presiona cualquier tecla para continuar...");
                        Console.ReadKey();
                        break;
                }

            } while (opcion >= 1 && opcion <= 3);
        }
    }
}
