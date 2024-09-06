using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FechaNacimiento
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string cadenaFechaNacimiento;
            DateTime dateTimeFechaNacimiento;

            Console.WriteLine("Dime la fecha de tu nacimiento (dia mes y año) y te dire que dia de la semana era: ");
            cadenaFechaNacimiento = Console.ReadLine();

            dateTimeFechaNacimiento = DateTime.Parse(cadenaFechaNacimiento);

            Console.WriteLine($"Naciste un {dateTimeFechaNacimiento.ToString("dddd")}");
        }
    }
}
