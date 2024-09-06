using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Seccion_11
{
    class Program
    {
        static void Main(string[] args)
        {
            string directorio;

            do
            {
                Console.Write("Por favor, ingrese la ruta del directorio: ");
                directorio = Console.ReadLine();

                if (!Directory.Exists(directorio))
                {
                    Console.WriteLine("La ruta especificada no existe. Por favor, ingrese una ruta válida.");
                }

            } while (!Directory.Exists(directorio)); 

            ExplorarDirectorio(directorio);
        }

        static void ExplorarDirectorio(string directorioPa)
        {
            bool continuar = true;

            while (continuar)
            {
                Console.Clear();
                Console.WriteLine($"Contenido de: {directorioPa}\n");

                string[] archivosSubdirectorios = Directory.GetFileSystemEntries(directorioPa);

                MostrarTabla(archivosSubdirectorios);
              
                Console.Write("Ingresa el número de la opción que deseas explorar (o 'a' para ir hacia atrás en la ruta, 'n' para ingresar una nueva ruta, o 's' para salir): ");
                string opcion = Console.ReadLine();


                if (opcion.ToLower() == "s") 
                {
                    
                    continuar = false;
                }
                else if (opcion.ToLower() == "a") 
                {
                    directorioPa = Path.GetDirectoryName(directorioPa);
                }
                else if (opcion.ToLower() == "n") 
                {
                    Console.Clear();

                    Console.Write("Ingresa la nueva ruta: ");
                    string nuevaRuta = Console.ReadLine();

                    if (Directory.Exists(nuevaRuta))
                    {
                        directorioPa = nuevaRuta;
                    }
                    else
                    {
                        Console.WriteLine("Ingresa una ruta válida");
                        Console.WriteLine("Presiona cualquier tecla para continuar...");
                        Console.ReadKey();
                    }
                }
                else if (Convert.ToInt32(opcion) >= 0 && Convert.ToInt32(opcion) < archivosSubdirectorios.Length) 
                {
                    int opcionEscogida = Convert.ToInt32(opcion);

                    if (Directory.Exists(archivosSubdirectorios[opcionEscogida]))
                    {
                        directorioPa = archivosSubdirectorios[opcionEscogida];
                    }
                    else
                    {
                        OperacionesArchivos(archivosSubdirectorios[opcionEscogida]);
                    }
                }
                else
                {
                    Console.WriteLine("¡Ingresa un número válido o 'a' para regresar, 's' para salir! o ' n' para una nueva ruta");
                }
            }
        }

        static void MostrarTabla(string[] archivosSubdirectoriosPa)
        {
            Console.WriteLine($"{"Índice",-8}{"Nombre",-50}{"Tipo",-13}");

          
            String guiones = new string('-', 71);

            Console.WriteLine(guiones);

            string nombre, tipo;


            for (int i = 0; i < archivosSubdirectoriosPa.Length; i++)
            {
                nombre = Path.GetFileName(archivosSubdirectoriosPa[i]);

                if (Directory.Exists(archivosSubdirectoriosPa[i]))
                {
                    tipo = "Subdirectorio";
                }
                else
                {
                    tipo = Path.GetExtension(archivosSubdirectoriosPa[i]);
                }

                Console.WriteLine($"{i,-8}{nombre,-50}{tipo,-13}");
            }

            Console.WriteLine();
        }

        static void OperacionesArchivos(string rutaArchivoPa)
        {
            string rutaCopiarArchivo, rutaMoverArchivo, destinoArchivo, respuestaReemplazo, respuestaEliminar, respuestaRenombrar, nuevoNombreArchivo, rutaArchivoRenombrado;

            string nombreArchivo = Path.GetFileName(rutaArchivoPa);

            Console.WriteLine($"\n\n¿Qué quieres hacer con el archivo [{nombreArchivo}]?");

            Console.WriteLine("1. Copiar");
            Console.WriteLine("2. Mover");
            Console.WriteLine("3. Eliminar");
            Console.WriteLine("4. Renombrar");

            Console.Write("Selecciona una opción: ");
            int opcionArchivo = Convert.ToInt32(Console.ReadLine());

            switch(opcionArchivo)
            {
                case 1:

                    Console.Write("\nIngrese la ruta en donde quiere copiar el archivo: ");
                    rutaCopiarArchivo = Console.ReadLine();

                    if (Directory.Exists(rutaCopiarArchivo))
                    {
                        destinoArchivo = Path.Combine(rutaCopiarArchivo, nombreArchivo);

                        if (!File.Exists(destinoArchivo))
                        {
                            File.Copy(rutaArchivoPa, destinoArchivo);

                            MensajeRealizadoConExito("copiado");
                        }
                        else
                        {
                            Console.Write($"\nEl archivo [{nombreArchivo}] ya existe en la ruta de destino. ¿Desea reemplazarlo? (s/n): ");
                            respuestaReemplazo = Console.ReadLine();

                            if (respuestaReemplazo.ToLower() == "s")
                            {
                                File.Copy(rutaArchivoPa, destinoArchivo, true);

                                MensajeRealizadoConExito("copiado");
                            }
                            else
                            {
                                MensajeOperacionCancelada();
                            }
                        }
                    }
                    else
                    {
                        MensajeRutaNoValida();
                    }
                    break;
                case 2:

                    Console.Write("\nIngrese la ruta en donde quiere mover el archivo: ");
                    rutaMoverArchivo = Console.ReadLine();

                    if (Directory.Exists(rutaMoverArchivo))
                    {
                        destinoArchivo = Path.Combine(rutaMoverArchivo, nombreArchivo);

                        if (!File.Exists(destinoArchivo))
                        {
                            File.Move(rutaArchivoPa, destinoArchivo);

                            MensajeRealizadoConExito("movido");
                        }
                        else
                        {
                            Console.Write($"\nEl archivo [{nombreArchivo}] ya existe en la ruta de destino. ¿Desea reemplazarlo? (s/n): ");
                            respuestaReemplazo = Console.ReadLine();

                            if (respuestaReemplazo.ToLower() == "s")
                            {
                                File.Delete(rutaArchivoPa);

                                File.Move(rutaArchivoPa, destinoArchivo);

                                MensajeRealizadoConExito("movido");
                            }
                            else
                            {
                                MensajeOperacionCancelada();
                            }
                        }
                    }
                    else
                    {
                        MensajeRutaNoValida();
                    }
                    break;
                case 3:
                    Console.Write($"\n¿Está seguro de que desea eliminar el archivo [{nombreArchivo}] (s/n)?: ");
                    respuestaEliminar = Console.ReadLine();

                    if (respuestaEliminar.ToLower() == "s")
                    {
                        File.Delete(rutaArchivoPa);

                        MensajeRealizadoConExito("eliminado");
                    }
                    else
                    {
                        MensajeOperacionCancelada();
                    }
                    break;
                case 4:
                    Console.Write("\nIngresa el nuevo nombre para el archivo (con extensión): ");
                    nuevoNombreArchivo = Console.ReadLine();

                    Console.Write($"El nuevo nombre de [{nombreArchivo}] será: [{nuevoNombreArchivo}], ¿es correcto? (s/n): ");
                    respuestaRenombrar = Console.ReadLine();

                    if (respuestaRenombrar.ToLower() == "s")
                    {
                        rutaArchivoRenombrado = Path.Combine(Path.GetDirectoryName(rutaArchivoPa), nuevoNombreArchivo);

                        File.Move(rutaArchivoPa, rutaArchivoRenombrado);

                        MensajeRealizadoConExito("renombrado");
                    }
                    else if (respuestaRenombrar.ToLower() == "n")
                    {
                        MensajeOperacionCancelada();
                    }
                    break;
                default:
                    Console.WriteLine("¡Escoge una opción correcta!");
                    Console.Write("Presione cualquier tecla para continuar...");
                    Console.ReadKey();
                    break;
            }
        }

        static void MensajeRutaNoValida()
        {
            Console.WriteLine("\n¡Ingresa una ruta válida!");

            Console.Write("Presiona cualquier tecla para continuar...");
            Console.ReadKey();
        }

        static void MensajeOperacionCancelada()
        {
            Console.WriteLine("\n¡Operación cancelada por el usuario!");

            Console.Write("Presione cualquier tecla para continuar...");
            Console.ReadKey();
        }

        static void MensajeRealizadoConExito(string tipoMovimientoPa)
        {
            Console.WriteLine($"\n¡El archivo se ha {tipoMovimientoPa} con éxito!");
            Console.Write("Presione cualquier tecla para continuar...");
            Console.ReadKey();
        }

    }
}
