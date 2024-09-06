using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuentaBancaria
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double montoAr, saldoInicialAr;
            int opcion;
            string nombreAr, apellidosAr, direccionAr, rfcAr;

            Console.Write("Está a punto de crear una cuenta nueva, por favor presione cualquier tecla para continuar: ");
            Console.ReadKey();

            Console.WriteLine("\nIngrese la información que se le solicita a continuación: ");

            Console.Write("\nNombre: ");
            nombreAr = Console.ReadLine();

            Console.Write("Apellidos: ");
            apellidosAr = Console.ReadLine();

            Console.Write("Dirección: ");
            direccionAr = Console.ReadLine();

            Console.Write("RFC: ");
            rfcAr = Console.ReadLine();

            Console.Write("Ingrese su deposito inicial: $");
            saldoInicialAr = Convert.ToDouble(Console.ReadLine());

            CuentaBancaria cliente1 = new CuentaBancaria(nombreAr, apellidosAr, saldoInicialAr, direccionAr, rfcAr);

            Console.WriteLine("Felicidades, su cuenta ha sido creada con exito, presione  cualquier tecla para continuar");
            Console.ReadKey();

            //Menú
            do
            {
                Console.WriteLine("\n1. Deposito");
                Console.WriteLine("2. Retiro");
                Console.WriteLine("3. Consultar Saldo");
                Console.WriteLine("4. Mostrar Información de la cuenta");
                Console.WriteLine("5. Salir");

                Console.Write("\nElija una opción: ");
                opcion = Convert.ToInt32(Console.ReadLine());

                switch (opcion)
                {
                    case 1:
                        Console.Write("Ingrese el monto a depositar: $");
                        montoAr = Convert.ToDouble(Console.ReadLine());

                        cliente1.Deposito(montoAr);
                        break;
                    case 2:
                        Console.Write("Ingrese el monto a retirar: $");
                        montoAr = Convert.ToDouble(Console.ReadLine());

                        cliente1.Retiro(montoAr);
                        break;
                    case 3:
                        cliente1.ConsultaSaldo();
                        break;
                    case 4:
                        Console.WriteLine(cliente1.ToString());
                        break;
                }


            } while (opcion >= 1 && opcion <= 4);
        }
    }

    class CuentaBancaria
    {
        //Campos
        private string nombre, apellidos, direccion, rfc;
        private double saldo;

        //Constructor
        public CuentaBancaria(string nombrePa, string apellidosPa, double saldoPa, string direccionPa, string rfcPa)
        {
            nombre = nombrePa;
            apellidos = apellidosPa;
            saldo = saldoPa;
            direccion = direccionPa;
            rfc = rfcPa;
        }

        //Métodos
        public double Deposito(double montoPa)
        {
            saldo += montoPa;
            return saldo;
        }

        public double Retiro(double montoPa)
        {
            if (saldo >= montoPa)
            {
                saldo -= montoPa;
            }
            else
            {
                Console.WriteLine("¡Saldo insuficiente!");
            }
            return saldo;
        }

        public void ConsultaSaldo()
        {
            Console.WriteLine("Su saldo es: ${0}", saldo);
        }

        public override string ToString()
        {
            string mensaje;
            mensaje = "\nTitular: " + nombre + " " + apellidos + "\nRFC:" + rfc + "\nDirección: " + direccion + "\nSaldo: $" + saldo;

            return mensaje;

        }
    }
}
