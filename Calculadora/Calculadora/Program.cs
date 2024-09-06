using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculadora
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int opcion;
            decimal result;
            decimal num1Ar, num2Ar;

            do
            {
                Console.WriteLine("1. Suma");
                Console.WriteLine("2. Resta");
                Console.WriteLine("3. Multiplicacion");
                Console.WriteLine("4. Division");

                Console.WriteLine("Escoge una opcion: ");
                opcion = Convert.ToInt32(Console.ReadLine());

            }
            while ((opcion < 1) || (opcion > 4));


            switch (opcion)
            {
                case 1:
                    Sumar();
                    break;
                case 2:
                    result = Restar();

                    Console.WriteLine("El resultado de la resta es: {0}", result);
                    break;
                case 3:
                    num1Ar = IngresarNumero("Ingresa el primer numero: ");
                    num2Ar = IngresarNumero("Ingresa el segundo numero: ");
                    Multiplicar(num1Ar, num2Ar);
                    break;
                case 4:
                    num1Ar = IngresarNumero("Ingresa el primer numero: ");
                    num2Ar = IngresarNumero("Ingresa el segundo numero: ");
                    result = Dividir(num1Ar, num2Ar);
                    Console.WriteLine("El resultado de la división es: {0}", result);
                    break;
            }
        }

        static void Sumar()
        {
            decimal num1, num2, resultado;
            Console.Write("Ingresa el primer número:");
            num1 = Convert.ToDecimal(Console.ReadLine());

            Console.Write("Ingresa el segundo número:");
            num2 = Convert.ToDecimal(Console.ReadLine());

            resultado = num1 + num2;
            Console.WriteLine("{0} + {1} = {2}", num1, num2, resultado);
        }

        static decimal Restar()
        {
            decimal num1, num2, resultado;
            Console.Write("Ingresa el primer número:");
            num1 = Convert.ToDecimal(Console.ReadLine());

            Console.Write("Ingresa el segundo número:");
            num2 = Convert.ToDecimal(Console.ReadLine());

            resultado = num1 - num2;
            return resultado;
        }

        static void Multiplicar(decimal num1Pa, decimal num2Pa)
        {
            decimal resultado;
            resultado = num1Pa * num2Pa;
            Console.WriteLine("{0} * {1} = {2}", num1Pa, num2Pa, resultado);
        }

        static decimal Dividir(decimal num1Pa, decimal num2Pa)
        {
            decimal resultado;
            if (num2Pa != 0)
            {
                resultado = num1Pa / num2Pa;
            }
            else
            {
                Console.WriteLine("No es posible dividir entre cero");
                resultado = 0;
            }

            return resultado;
        }

        static decimal IngresarNumero(string peticion)
        {
            decimal numero;
            Console.WriteLine(peticion);
            numero = Convert.ToDecimal(Console.ReadLine());
            return numero;
        }

    }
}
