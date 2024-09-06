using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Palindromo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string palabraUsuario, palabraInvertida = "";
            
            Console.Write("Ingresa una palabra y veamos si es un palíndromo: ");
            palabraUsuario = Console.ReadLine();

            foreach (char letra in palabraUsuario)
            {
                palabraInvertida = letra + palabraInvertida;
            }

            if (palabraUsuario.Equals(palabraInvertida, StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine($"\"{palabraUsuario}\" es una palabra palíndroma");
            }
            else
            {
                Console.WriteLine($"\"{palabraUsuario}\" No es una palabra palíndroma");
            }

        }
    }
}
