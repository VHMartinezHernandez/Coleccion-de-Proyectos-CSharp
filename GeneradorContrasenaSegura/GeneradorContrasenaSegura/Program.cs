using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneradorContrasenaSegura
{
    class Program
    {
        static void Main(string[] args)
        {
            string nombreUsuario, opcion, contrasena;
            (bool contrasenaValida, string mensajeError) verificarContrasena;

            Console.WriteLine("\t\tRegistro\n\n");

            Console.WriteLine("Ingrese un nombre de usuario: ");
            nombreUsuario = Console.ReadLine();

            Console.WriteLine("Desea que le generemos una contraseña segura? (si/no): ");
            opcion = Console.ReadLine();

            opcion = opcion.ToLower();

            switch (opcion)
            {
                case "si":
                    Contrasena contrasena1 = new Contrasena();

                    contrasena = contrasena1.GenerarContrasena();

                    Console.WriteLine($"Esta es la contraseña que generamos paara ti, guardala en un lugar seguro: {contrasena}");

                    Console.WriteLine("\nPresiona cualquier tecla para terminar tu registro ");
                    Console.ReadKey();
                    Console.Clear();

                    Console.WriteLine($"\nTus datos de acceso son los siguientes: \n\tusuario: {nombreUsuario}\n\tcontraseña: {contrasena}");

                break;

                case "no":
                    Console.WriteLine("\nIngrese una contraseña segura (La contraseña debe contener entre 8-20 caracteres, incluido un numero, una mayuscula, una minuscula y uno de los siguientes caracteres especiales: $%#&!? ): ");
                    contrasena = Console.ReadLine();

                    Contrasena contrasena2 = new Contrasena();

                    verificarContrasena = contrasena2.ComprobarContrasena(contrasena);

                    if (verificarContrasena.contrasenaValida)
                    {
                        Console.WriteLine("\nPresiona cualquier tecla para terminar tu registro ");
                        Console.ReadKey();
                        Console.Clear();

                        Console.WriteLine($"\nTus datos de acceso son los siguientes: \n\tusuario: {nombreUsuario}\n\tcontraseña: {contrasena}");
                    }
                    else
                    {
                        Console.WriteLine(verificarContrasena.mensajeError+". Ingresa una contraseña valida");
                    }
                break;
            }
        }
    }

    class Contrasena
    {
        string numeros = "0123456789";
        string letrasMin = "abcdefghijklmnopqrstuvwxyz";
        string letrasMay = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        string caracterEspecial = "$%#&!?";

        int numContiene = 0, minContiene = 0, mayContiene = 0, espContiene = 0;

        public string GenerarContrasena()
        {
            string contrasenaGenerada = "";
            Random random = new Random();

            int longitudContrasena = random.Next(8, 21);

            double numTener = longitudContrasena * .15;
            double minTener = longitudContrasena * .35;
            double mayTener = longitudContrasena * .35;
            double espTener = longitudContrasena * .15;

            char caracterEscogido;

            while (contrasenaGenerada.Length < longitudContrasena)
            {
                switch (random.Next(0, 4))
                {
                    case 0:
                        if (numContiene < numTener)
                        {
                            caracterEscogido = numeros[random.Next(numeros.Length)];
                            contrasenaGenerada += caracterEscogido;
                            numContiene++;
                        }
                        break;

                    case 1:
                        if (minContiene < minTener)
                        {
                            caracterEscogido = letrasMin[random.Next(letrasMin.Length)];
                            contrasenaGenerada += caracterEscogido;
                            minContiene++;
                        }
                        break;

                    case 2:
                        if (mayContiene < mayTener)
                        {
                            caracterEscogido = letrasMay[random.Next(letrasMay.Length)];
                            contrasenaGenerada += caracterEscogido;
                            mayContiene++;

                        }
                        break;

                    case 3:
                        if (espContiene < espTener)
                        {
                            caracterEscogido = caracterEspecial[random.Next(caracterEspecial.Length)];
                            contrasenaGenerada += caracterEscogido;
                            espContiene++;
                        }
                        break;

                }
            }

            return contrasenaGenerada;

        }

        public (bool, string) ComprobarContrasena(string contrasenaPa)
        {
            bool contrasenaValida = false;
            bool hayNumero = false, hayMinuscula = false, hayMayuscula = false, hayEspecial = false;

            string mesajeError = "";

            if (contrasenaPa.Length >= 8 && contrasenaPa.Length <= 20)
            {
                foreach (char elemento in numeros)
                {
                    if (contrasenaPa.IndexOf(elemento) >= 0)
                    {
                        hayNumero = true;
                        break;
                    }
                    else
                    {
                        hayNumero = false;
                        mesajeError = "La contraseña debe contener al menos un numero";
                    }
                }
                if (hayNumero)
                {
                    foreach (char elemento in letrasMin)
                    {
                        if (contrasenaPa.IndexOf(elemento) >= 0)
                        {
                            hayMinuscula = true;
                            break;
                        }
                        else
                        {
                            hayMinuscula = false;
                            mesajeError = "La contraseña debe contener al menos una letra minuscula";
                        }
                    }

                    if (hayMinuscula) 
                    {
                        foreach (char elemento in letrasMay)
                        {
                            if (contrasenaPa.IndexOf(elemento) >= 0)
                            {
                                hayMayuscula = true;
                                break;
                            }
                            else
                            {
                                hayMayuscula = false;
                                mesajeError = "La contraseña debe contener al menos una letra mayuscula";
                            }
                        }

                        if (hayMayuscula)
                        {
                            foreach (char elemento in caracterEspecial)
                            {
                                if (contrasenaPa.IndexOf(elemento) >= 0)
                                {
                                    hayEspecial = true;
                                    break;
                                }
                                else
                                {
                                    hayEspecial = false;
                                    mesajeError = "La contraseña debe contener al menos uncaracter especial ($%#&!?)";
                                }
                            }
                        }
                    }
                      
                }

                if (hayNumero && hayMinuscula && hayMayuscula && hayEspecial)
                {
                    contrasenaValida = true;
                }
                else
                {
                    contrasenaValida = false;
                }
            }
            else
            {
                mesajeError = "La contraseña debe contener entre 8-20 caracteres";
                contrasenaValida = false;
            }
            return(contrasenaValida,mesajeError);
        }

    }
}
