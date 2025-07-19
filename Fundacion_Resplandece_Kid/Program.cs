using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Fundacion_Resplandece_Kid.Clases.Base; // Necesario para BaseDeDatos
using Fundacion_Resplandece_Kid.Clases;    // Necesario para Beneficiarios y Usuarios

namespace Fundacion_Resplandece_Kid
{
    internal class Program
    {
        private static Clases.Usuarios gestionUsuarios = new Clases.Usuarios(); // Instancia de Usuarios

        static void Main(string[] args)
        {
            // Inicializar los usuarios administrativos al inicio
            gestionUsuarios.CrearUsuariosAdministrativos();
            MostrarMenuPrincipal(); // Menú principal para el usuario antes de ingresar al sistema
        }

        public static void MostrarMenuPrincipal()
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.Clear();
            Console.WriteLine("╔══════════════════════════════════════════════════════╗    ");
            Console.WriteLine("║  ║║     ║║║║     ║║║║║║║║  ║║        ║║║║      ║    ");
            Console.WriteLine("║  ║║     ║║  ║║       ║║    ║║        ║║        ║    ");
            Console.WriteLine("║  ║║     ║║         ║║    ║║        ║║          ║    ");
            Console.WriteLine("║  ║║       ║║         ║║    ║║        ║║          ║    ");
            Console.WriteLine("║  ║║     ║║  ║║       ║║    ║║        ║║        ║    ");
            Console.WriteLine("║  ║║ ║║  ║║║║  ║║  ║║ ║║  ║║    ║║║║║║ ║║    ║║║║  ║║  ║    ");
            Console.WriteLine("╚══════════════════════════════════════════════════════╝    ");
            Console.WriteLine("╔══════════════════════════════════════════════════════╗    ");
            Console.WriteLine("║            BIENVENIDO A MI APLICACIÓN            ║    ");
            Console.WriteLine("║                  Versión 1.0                     ║    ");
            Console.WriteLine("╚══════════════════════════════════════════════════════╝    ");
            Console.WriteLine("╔══════════════════════════════════════════════════════╗    ");
            Console.WriteLine("║ Sistema de Gestión de Información para la Fundación ║    ");
            Console.WriteLine("║                    RESPLANDECE KIDS                  ║    ");
            Console.WriteLine("╚══════════════════════════════════════════════════════╝    ");

            Console.Write("Cargando...");
            for (int i = 0; i < 5; i++)
            {
                Console.Write(".");
                Thread.Sleep(300); // Reducido el tiempo de espera para que sea más rápido
            }
            Console.ResetColor();

            while (true)
            {
                Console.Clear();
                Console.WriteLine("╔══════════════════════════════════════════════════════╗  ");
                Console.WriteLine("║                  RESPLANDECE KIDS                    ║  ");
                Console.WriteLine("╠══════════════════════════════════════════════════════╣  ");
                Console.WriteLine("║  1 INGRESAR AL SISTEMA                               ║  ");
                Console.WriteLine("║  2 MENÚ DEL USUARIO                                  ║  ");
                Console.WriteLine("║  3 SALIR                                             ║  ");
                Console.WriteLine("╚══════════════════════════════════════════════════════╝  ");
                Console.WriteLine("\n");
                Console.Write("Ingrese una opción: ");

                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        IngresaralSistema();
                        break;
                    case "2":
                        MenudelUsuario();
                        break;
                    case "3":
                        Console.WriteLine("Gracias por usar el sistema!");
                        return;
                    default:
                        Console.WriteLine("Opción no válida. Intente de nuevo. ");
                        Console.ReadLine();
                        break;
                }
            }
        }

        private static void MenudelUsuario()
        {
            throw new NotImplementedException();
        }

        private static void IngresaralSistema()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("╔════════════════════════════════════════╗");
            Console.WriteLine("║           INGRESO AL SISTEMA           ║");
            Console.WriteLine("╚════════════════════════════════════════╝");
            Console.WriteLine("╔════════════════════════════════════════╗");
            Console.WriteLine("║       BIENVENIDO A RESPLANDECE KIDS      ║");
            Console.WriteLine("╚════════════════════════════════════════╝");
            Console.ResetColor();
            Console.Write("\nIngrese sus credenciales a continuación\n");
            Console.WriteLine();

            bool isAuthenticated = false;
            while (!isAuthenticated)
            {
                Console.Write("Usuario: ");
                string username = Console.ReadLine();

                Console.Write("Contraseña: ");
                string password = ReadPassword();

                isAuthenticated = gestionUsuarios.AutenticarUsuario(username, password);

                if (!isAuthenticated)
                {
                    Console.WriteLine("\nUsuario o contraseña incorrectos. Intente de nuevo.\n");
                    Console.ReadLine();
                    Console.Clear();
                }
            }
            Console.WriteLine("\n¡Autenticación exitosa! Presione cualquier tecla para continuar al menú principal.");
            Console.ReadLine();
            DisplayMainMenu(); // Llama al menú principal una vez autenticado
        }

        private static string ReadPassword()
        {
            StringBuilder passwordBuilder = new StringBuilder();
            ConsoleKeyInfo key;

            do
            {
                key = Console.ReadKey(true);

                if (key.Key != ConsoleKey.Enter && key.Key != ConsoleKey.Backspace)
                {
                    passwordBuilder.Append(key.KeyChar);
                    Console.Write("*");
                }
                else if (key.Key == ConsoleKey.Backspace && passwordBuilder.Length > 0)
                {
                    passwordBuilder.Remove(passwordBuilder.Length - 1, 1);
                    Console.Write("\b \b");
                }
            }
            while (key.Key != ConsoleKey.Enter);

            Console.WriteLine();
            return passwordBuilder.ToString();
        }

        public static void DisplayMainMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("╔══════════════════════════════════════════════════════╗  ");
                Console.WriteLine("║                  MENU PRINCIPAL                      ║  ");
                Console.WriteLine("╠══════════════════════════════════════════════════════╣  ");
                Console.WriteLine("║  1 REGISTRAR NUEVO NIÑ@                              ║  ");
                Console.WriteLine("║  2 INFORMACIÓN DEL NIÑ@ (Buscar por ID)             ║  "); // ¡Cambiado aquí!
                Console.WriteLine("║  3 REGISTRO COMPLETO (Listar todos los Beneficiarios)║  ");
                Console.WriteLine("║  4 GESTIÓN DE DATOS (Actualizar Beneficiario)        ║  ");
                Console.WriteLine("║  5 ELIMINAR DATOS DEL NIÑ@                           ║  ");
                Console.WriteLine("║  0 SALIR                                             ║  ");
                Console.WriteLine("╚══════════════════════════════════════════════════════╝  ");
                Console.ResetColor();
                Console.WriteLine("\n");
                Console.Write("Seleccione una opción: ");
                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        CreateBeneficiario();
                        break;
                    case "2":
                        ReadBeneficiario(); // Se modificará internamente para usar ID
                        break;
                    case "3":
                        ReadAllBeneficiario();
                        break;
                }
            }
        }

        private static void ReadAllBeneficiario()
        {
            throw new NotImplementedException();
        }

        private static void ReadBeneficiario()
        {
            throw new NotImplementedException();
        }

        private static void CreateBeneficiario()
        {
            Console.WriteLine("Ingrese la cedula del beneficiario");
            string cedula = Console.ReadLine();
            Console.WriteLine();
        }
    }
}
