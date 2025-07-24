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
        private static Clases.Usuarios gestionUsuarios = new Clases.Usuarios();
        static void Main(string[] args)
        {
            // Inicializar los usuarios administrativos al inicio
            gestionUsuarios = new Clases.Usuarios();
          

            MostrarMenuPrincipal(); // Menú principal para el usuario antes de ingresar al sistema
        }

        public static void MostrarMenuPrincipal()
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Clear();
            Console.WriteLine("╔══════════════════════════════════════════════════════╗    ");
            Console.WriteLine("║  ║║     ║║║║║║    ║║║║║║║║   ║║        ║║║║║║        ║    ");
            Console.WriteLine("║  ║║     ║║  ║║       ║║      ║║        ║║            ║    ");
            Console.WriteLine("║  ║║      ║║          ║║      ║║        ║║            ║    ");
            Console.WriteLine("║  ║║        ║║        ║║      ║║        ║║            ║    ");
            Console.WriteLine("║  ║║     ║║  ║║       ║║      ║║        ║║            ║    ");
            Console.WriteLine("║  ║║ ║║  ║║║║║║  ║║   ║║  ║║  ║║║║║║    ║║║║║║ ║║     ║    ");
            Console.WriteLine("╚══════════════════════════════════════════════════════╝    ");
            Console.WriteLine("╔══════════════════════════════════════════════════════╗    ");
            Console.WriteLine("║            BIENVENIDO A MI APLICACIÓN                ║    ");
            Console.WriteLine("║                  Versión 1.0                         ║    ");
            Console.WriteLine("╚══════════════════════════════════════════════════════╝    ");
            Console.WriteLine("╔══════════════════════════════════════════════════════╗    ");
            Console.WriteLine("║ Sistema de Gestión de Información para la Fundación  ║    ");
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
                Console.ForegroundColor = ConsoleColor.Magenta;
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

        //OPCION 1 INGRESAR AL SISTEMA
        private static void IngresaralSistema()
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Clear();
            Console.WriteLine("╔════════════════════════════════════════╗");
            Console.WriteLine("║           INGRESO AL SISTEMA           ║");
            Console.WriteLine("╚════════════════════════════════════════╝");
            Console.WriteLine("╔════════════════════════════════════════╗");
            Console.WriteLine("║       BIENVENIDO A RESPLANDECE KIDS    ║");
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

        //OPCION 2 MENU DEL USUARIO
        private static void MenudelUsuario()
        {
            Console.Clear();
            Console.WriteLine("╔══════════════════════════════════════════════════════╗ ");
            Console.WriteLine("║            * * * MENÚ DEL USUARIO * * *              ║ ");
            Console.WriteLine("╠══════════════════════════════════════════════════════╣ ");
            Console.WriteLine("║  1. CREACIÓN DE USUARIO                              ║ ");//C
            Console.WriteLine("║  2. LISTA DE USUARIOS                                ║ ");//R
            Console.WriteLine("║  3. CONSULTAR USUARIO                                ║ ");//D
            Console.WriteLine("║  4. ELIMINAR USUARIO                                 ║ ");//D
            Console.WriteLine("║  5. VOLVER AL MENU                                   ║ ");
            Console.WriteLine("║                                                      ║ ");
            Console.WriteLine("╚══════════════════════════════════════════════════════╝ ");
            Console.WriteLine();
            Console.Write("Ingrese una opción:  ");

            string opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    CrearUsuario();
                    break;

                case "2":
                    ListaUsuarios();
                    break;
                case "3":
                    ConsultarUsuarios();
                    break;

                case "4":
                    EliminarUsuario();
                    break;

                case "5":
                    Console.WriteLine("Gracias por usar el sistema!");
                    return;

                default:
                    Console.WriteLine("Opción no válida. Intente de nuevo. ");
                    Console.ReadLine();
                    break;
            }
        }





        //CASO 3 ELIMINAR
        private static void EliminarUsuario()
        {
            Console.Clear();
            Console.Write("Ingrese el código del usuario a eliminar: ");
            string codigo = Console.ReadLine();
            Usuarios objUsuariosEliminar = BaseDeDatos.GetUsuariosXCodigo(codigo);
            if (objUsuariosEliminar == null)
            {
                Console.WriteLine("Código de usuario no encontrado.");
            }
            else
            {
                Console.WriteLine("¿Está seguro que desea eliminar este usuario? (S/N)");
                string respuesta = Console.ReadLine().ToUpper();
                if (respuesta == "S")
                {
                    BaseDeDatos.BaseDatosUsuarios.Remove(objUsuariosEliminar);
                    Console.WriteLine("Usuario eliminado con éxito.");
                }
                else
                {
                    Console.WriteLine("Eliminación cancelada.");
                }
            }
            Console.ReadLine();
        }
        //CASO 3 CONSULTAR
        private static void ConsultarUsuarios()
        {
            Console.Clear();
            Console.Write("Ingrese el código del usuario a consultar: ");
            string codigo = Console.ReadLine();

            Usuarios objUsuariosConsultar = BaseDeDatos.GetUsuariosXCodigo(codigo);

            if (objUsuariosConsultar == null)
            {
                Console.WriteLine("Código de usuario no encontrado.");
            }
            else
            {
                objUsuariosConsultar.Imprimir();
            }
            Console.ReadLine();
        }

        //CASO 2 MOSTRAR LISTA
        private static void ListaUsuarios()
        {
            Console.Clear();
            foreach (var usuario in BaseDeDatos.BaseDatosUsuarios)
            {
                usuario.Imprimir();
            }
            Console.ReadLine();

        }

        //CASO 1 CREAR
        private static void CrearUsuario()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("╔═══════════════════════════════════════════╗");
            Console.WriteLine("║            CREACIÓN DEL USUARIO           ║");
            Console.WriteLine("╚═══════════════════════════════════════════╝");
            Console.ResetColor();
            Console.WriteLine();
            Console.Write("Ingrese el nombre para usuario: ");
            string usuario = Console.ReadLine();
            Console.WriteLine();
            Console.Write("Ingrese la contraseña para usuario: ");
            string contrasena = Console.ReadLine();
            Console.WriteLine();
            Console.Write("Ingrese el rol del usuario: ");
            string rol = Console.ReadLine();
            Console.WriteLine();
            Console.WriteLine();

            Usuarios objUsuario = new Usuarios(usuario, contrasena, rol);
            Console.WriteLine("Usuario " + usuario + " " + contrasena + " grabado con éxito!!");
            Console.ReadLine();
        }

        //YA PASA USUARIO TODO BIEN AHORA FALTA EL MENU PRINCIPAL

        public static void DisplayMainMenu()
        {
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.Clear();
                Console.WriteLine("╔═══════════════════════════════════════════════════════╗  ");
                Console.WriteLine("║                  MENU PRINCIPAL                       ║  ");
                Console.WriteLine("╠═══════════════════════════════════════════════════════╣  ");
                Console.WriteLine("║  1.  REGISTRAR NUEVO BENEFICIARIO                     ║  ");//C
                Console.WriteLine("║  2.  LISTADO DE TODOS LOS BENEFICIARIOS               ║  ");//R
                Console.WriteLine("║  3.  CONSULTAR DATOS DE UN BENEFICIARIO               ║  ");//RALL
                Console.WriteLine("║  4.  ACTUALIZAR DATOS DE UN BENEFICIARIO              ║  ");//U
                Console.WriteLine("║  5.  ELIMINAR DATOS DE UN BENEFICIARIO                ║  ");//D
                Console.WriteLine("║  6.  BUSCAR BENEFICIARIO POR CODIGO                   ║  ");
                Console.WriteLine("║  7.  REPORTES DE BENEFICIARIOS                        ║  ");
                Console.WriteLine("║  8.  REGISTRAR NUEVO TUTOR                            ║  ");//C
                Console.WriteLine("║  9.  BUSCAR TUTOR POR CODIGO                          ║  ");//R
                Console.WriteLine("║  10.  ACTUALIZAR DATOS DE TUTOR                       ║  ");//U
                Console.WriteLine("║  11. ELIMINAR DATOS DE TUTOR                          ║  ");//D
                Console.WriteLine("║  0 SALIR                                              ║  ");
                Console.WriteLine("╚═══════════════════════════════════════════════════════╝  ");
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
                        ReadAllBeneficiario();
                        break;
                    case "3":
                        ReadBeneficiario();
                        break;
                    case "4":
                        UpdateBeneficiario();
                        break;
                    case "5":
                        ReadAllBeneficiario();
                        break;
                    case "6":
                        ReadAllBeneficiario();
                        break;
                    case "7":
                        ReadAllBeneficiario();
                        break;
                    case "8":
                        ReadAllBeneficiario();
                        break;
                    case "9":
                        ReadAllBeneficiario();
                        break;
                    case "10":
                        ReadAllBeneficiario();
                        break;
                    case "0":
                        Console.WriteLine("Gracias por usar el sistema!");
                        return;

                    default:
                        Console.WriteLine("Opción no válida. Intente de nuevo. ");
                        Console.ReadLine();
                        break;
                }
            }
        }

        private static void UpdateBeneficiario()
        {
            Console.Clear();
            Console.Write("Ingrese el código del beneficiario a actualizar: ");
            string codigo = Console.ReadLine();

            Beneficiarios objBeneficiarioActualizar = BaseDeDatos.GetBeneficiariosXCodigo(codigo);
            if (objBeneficiarioActualizar == null)
            {
                Console.WriteLine("Código de beneficiario no encontrado.");
            }
            else
            {
                objBeneficiarioActualizar.Imprimir();
                Console.WriteLine("\nIngrese los nuevos datos del beneficiario: ");
                Console.Write("Ingrese la cédula del beneficiario: ");
                string cedula = Console.ReadLine();
                Console.WriteLine();

                Console.Write("Ingrese los nuevos nombres del beneficiario: ");
                string nombres = Console.ReadLine();
                Console.WriteLine();

                Console.Write("Ingrese los nuevos apellidos del beneficiario: ");
                string apellidos = Console.ReadLine();
                Console.WriteLine();

                Console.Write("Ingrese la nueva dirección del beneficiario: ");
                string direccion = Console.ReadLine();
                Console.WriteLine();

                Console.Write("Ingrese la nueva fecha de nacimiento del beneficiario (dd/mm/yyyy): ");
                DateTime fecha_nacimiento = Convert.ToDateTime(Console.ReadLine());
                Console.WriteLine();

                Console.Write("Ingrese el nuevo plantel educativo del beneficiario: ");
                string plantel_educativo = Console.ReadLine();
                Console.WriteLine();
                Console.Write("Ingrese el nuevo año educativo del beneficiario: ");
                string anio_educativo = Console.ReadLine();
                Console.WriteLine();
                Console.Write("Ingrese el nuevo teléfono del beneficiario: ");
                string telefono = Console.ReadLine();
                Console.WriteLine();
                Console.Write("Ingrese el nuevo email del beneficiario: ");
                string email = Console.ReadLine();
                Console.WriteLine();
                BaseDeDatos.BaseDatosBeneficiarios.RemoveAt(Convert.ToInt32(objBeneficiarioActualizar.getCodigo()) -1);
                BaseDeDatos.BaseDatosBeneficiarios.Insert(Convert.ToInt32(objBeneficiarioActualizar.getCodigo()) -1, objBeneficiarioActualizar);
                Console.WriteLine("Beneficiario actualizado con éxito.");
                Console.ReadLine();
                Console.WriteLine();


            }
        }

        //CASO3 CONSULTAR
        private static void ReadBeneficiario()
        {
            Console.Clear();
            Console.Write("Ingrese el código del beneficiario a consultar: ");
            string codigo = Console.ReadLine();

            Beneficiarios objBeneficiarioConsultar = BaseDeDatos.GetBeneficiariosXCodigo(codigo);
            if (objBeneficiarioConsultar == null)
            {
                Console.WriteLine("Código de beneficiario no encontrado.");
            }
            else
            {
                objBeneficiarioConsultar.Imprimir();
            }
            Console.ReadLine();
        }
        //CASO 2 LISTAR
        private static void ReadAllBeneficiario()
        {
            Console.Clear();
            Console.WriteLine("╔═══════════════════════════════════════════╗");
            Console.WriteLine("║           LISTA DE BENEFICIARIOS          ║");
            Console.WriteLine("╚═══════════════════════════════════════════╝");
            foreach (var usuario in BaseDeDatos.BaseDatosBeneficiarios)
            {
                usuario.Imprimir();
            }
            Console.ReadLine();
        }

        //CASO 1
        private static void CreateBeneficiario()
        {
            string cedula;
            string nombres;
            string apellidos;
            string direccion;
            DateTime fecha_nacimiento;
            string plantel_educativo;
            string anio_educativo;
            string telefono;
            string email;
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("╔═══════════════════════════════════════════╗");
            Console.WriteLine("║   * * * CREACIÓN DEL BENEFICIARIO * * *   ║");
            Console.WriteLine("╚═══════════════════════════════════════════╝");
            Console.ResetColor();
            Console.WriteLine();

            Console.Write("Ingrese la cédula del beneficiario: ");
            cedula = Console.ReadLine();
            Console.WriteLine();

            Console.Write("Ingrese los nombres del beneficiario: ");
            nombres = Console.ReadLine();
            Console.WriteLine();

            Console.Write("Ingrese los apellidos del beneficiario: ");
            apellidos = Console.ReadLine();
            Console.WriteLine();

            Console.Write("Ingrese la dirección del beneficiario: ");
            direccion = Console.ReadLine();
            Console.WriteLine();

            Console.Write("Ingrese la fecha de nacimiento del beneficiario (dd/mm/yyyy): ");
            fecha_nacimiento = Convert.ToDateTime(Console.ReadLine());
            Console.WriteLine();

            Console.Write("Ingrese el plantel educativo del beneficiario: ");
            plantel_educativo = Console.ReadLine();
            Console.WriteLine();

            Console.Write("Ingrese el año educativo del beneficiario: ");
            anio_educativo = Console.ReadLine();
            Console.WriteLine();

            Console.Write("Ingrese el teléfono del beneficiario: ");
            telefono = Console.ReadLine();
            Console.WriteLine();

            Console.Write("Ingrese el email del beneficiario: ");
            email = Console.ReadLine();
            Console.WriteLine();
        }


    }
}
