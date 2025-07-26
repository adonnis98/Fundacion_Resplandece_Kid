using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Fundacion_Resplandece_Kid.Clases.Base;
using Fundacion_Resplandece_Kid.Clases;

namespace Fundacion_Resplandece_Kid
{
    internal class Program
    {
        private static Clases.Usuarios gestionUsuarios = new Clases.Usuarios();
        static void Main(string[] args)
        {

            gestionUsuarios = new Clases.Usuarios();
            MostrarMenuPrincipal();
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
                Thread.Sleep(300);
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
            DisplayMainMenu();

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





        //ELIMINAR USUARIO
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
        //CONSULTAR USUARIO 
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

        //MOSTRAR LISTA DE TODOS USUARIOS
        private static void ListaUsuarios()
        {
            Console.Clear();
            foreach (var usuario in BaseDeDatos.BaseDatosUsuarios)
            {
                usuario.Imprimir();
            }
            Console.ReadLine();

        }

        //CREAR USUARIOS
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
                Console.WriteLine("║  2.  LISTADO DE TODOS LOS BENEFICIARIOS               ║  ");//RALL
                Console.WriteLine("║  3.  CONSULTAR DATOS DE UN BENEFICIARIO               ║  ");//R
                Console.WriteLine("║  4.  ACTUALIZAR DATOS DE UN BENEFICIARIO              ║  ");//U
                Console.WriteLine("║  5.  ELIMINAR DATOS DE UN BENEFICIARIO                ║  ");//D
                Console.WriteLine("║  6.  REPORTES DE BENEFICIARIOS                        ║  ");// OJO ESTO AQUI NO SE COMO AGREGARLE AQUI SE SUPONE QUE DEBERIA IR EL REPORTE MEDICO Y OTRAS OBSERVACIONES
                Console.WriteLine("║  7.  REGISTRAR NUEVO TUTOR                            ║  ");//C
                Console.WriteLine("║  8.  LISTADO DE TODOS LOS TUTORES                     ║  ");//RALL
                Console.WriteLine("║  9. CONSULTAR DATOS DE UN TUTOR                       ║  ");//R
                Console.WriteLine("║  10. ACTUALIZAR DATOS DE TUTOR                        ║  ");//U
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
                        CreateBeneficiario();//C
                        break;
                    case "2":
                        ReadAllBeneficiario();//RALL
                        break;
                    case "3":
                        ReadBeneficiario();//R
                        break;
                    case "4":
                        UpdateBeneficiario();//U
                        break;
                    case "5":
                        DeleteBeneficiario();//D
                        break;
                    case "6":
                        // Beneficiario(); // Aquí se podría implementar un reporte de beneficiarios, pero no está definido.
                        break;
                    case "7":
                        CreateTutor();
                        break;
                    case "8":
                        ReadAllTutor();
                        break;
                    case "9":
                        ReadTutor();
                        break;
                    case "10":
                        UpdateTutor();
                        break;
                    case "11":
                        DeleteTutor();
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
        //ELIMINAR TUTOR
        private static void DeleteTutor()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("╔════════════════════════════════════════╗");
            Console.WriteLine("║ * * * ELIMINAR DATOS DE UN TUTOR * * * ║");
            Console.WriteLine("╚════════════════════════════════════════╝");
            Console.ResetColor();
            Console.WriteLine();
            Console.Write("Ingrese el código del tutor a eliminar: ");
            string codigo = Console.ReadLine();
            Tutores objTutorEliminar = BaseDeDatos.GetTutoresXCodigo(codigo);
            if (objTutorEliminar == null)
            {
                Console.WriteLine("Código de tutores no encontrado.");
            }
            else
            {
                Console.WriteLine("¿Está seguro que desea eliminar este tutor? (S/N)");
                string respuesta = Console.ReadLine().ToUpper();
                if (respuesta == "S")
                {
                    BaseDeDatos.BaseDatosTutores.Remove(objTutorEliminar);
                    Console.WriteLine("Tutor eliminado con éxito.");
                }
                else
                {
                    Console.WriteLine("Eliminación cancelada.");
                }
                Console.ReadLine();
            }
        }


        //ACTUALIZAR DATOS DE ALGUN TUTOR
        private static void UpdateTutor()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("╔══════════════════════════════════════════╗");
            Console.WriteLine("║ * * * ACTUALIZAR DATOS DE UN TUTOR * * * ║");
            Console.WriteLine("╚══════════════════════════════════════════╝");
            Console.ResetColor();
            Console.Write("Ingrese el código del tutor a actualizar: ");
            string codigo = Console.ReadLine();
            Tutores objTutorActualizar = BaseDeDatos.GetTutoresXCodigo(codigo);

            if (objTutorActualizar == null)
            {
                Console.WriteLine("Código de tutores no encontrado.");
            }
            else
            {
                objTutorActualizar.ImprimirTutores();
                Console.WriteLine("\nIngrese los nuevos datos del tutor: ");

                Console.Write("Ingrese los nuevos nombres del tutor: ");
                string nombres = Console.ReadLine();
                Console.WriteLine();

                Console.Write("Ingrese los nuevos apellidos del tutor: ");
                string apellidos = Console.ReadLine();
                Console.WriteLine();

                Console.Write("Ingrese el nuevo teléfono del beneficiario: ");
                string telefono = Console.ReadLine();
                Console.WriteLine();

                Console.Write("Ingrese el nuevo correo del beneficiario: ");
                string correo = Console.ReadLine();
                Console.WriteLine();

                Console.Write("Ingrese el nuevo grupo etario del tutor: ");
                string grupo_etario = Console.ReadLine();
                Console.WriteLine();

                Console.Write("Ingrese la nueva edad mínima del tutor: ");
                string edad_minima = Console.ReadLine();
                Console.WriteLine();

                Console.Write("Ingrese la nueva edad máxima del tutor: ");
                string edad_maxima = Console.ReadLine();
                Console.WriteLine();

                BaseDeDatos.BaseDatosTutores.RemoveAt(Convert.ToInt32(objTutorActualizar.getCodigo()) - 1);
                BaseDeDatos.BaseDatosTutores.Insert(Convert.ToInt32(objTutorActualizar.getCodigo()) - 1, objTutorActualizar);
                Console.WriteLine("Beneficiario actualizado con éxito.");
                Console.ReadLine();
            }
        }


        // BUSCAR TUTOR POR CODIGO
        private static void ReadTutor()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("╔═════════════════════════════════════════╗");
            Console.WriteLine("║ * * * CONSULTAR DATOS DE UN TUTOR * * * ║");
            Console.WriteLine("╚═════════════════════════════════════════╝");
            Console.ResetColor();
            Console.Write("Ingrese el código del tutor a consultar: ");
            string codigo = Console.ReadLine();

            Tutores objTutorConsultar = BaseDeDatos.GetTutoresXCodigo(codigo);
            if (objTutorConsultar == null)
            {
                Console.WriteLine("Código de beneficiario no encontrado.");
            }
            else
            {
                objTutorConsultar.ImprimirTutores();
            }
            Console.ReadLine();
        }

        //LISTA DE TODOS LOS TUTORES
        private static void ReadAllTutor()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("╔══════════════════════════════════════════╗");
            Console.WriteLine("║ * * * LISTADO DE TODOS LOS TUTORES * * * ║");
            Console.WriteLine("╚══════════════════════════════════════════╝");
            Console.ResetColor();
            foreach (var Tutores in BaseDeDatos.BaseDatosTutores)
            {
                Tutores.ImprimirTutores();
            }
            Console.ReadLine();
        }

        //CREAR TUTOR
        private static void CreateTutor()
        {
            string nombres;
            string apellidos;
            string telefono;
            string correo;
            string grupo_etario;
            string edad_minima;
            string edad_maxima;
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("╔═══════════════════════════════════════════╗");
            Console.WriteLine("║   * * * CREACIÓN DEL BENEFICIARIO * * *   ║");
            Console.WriteLine("╚═══════════════════════════════════════════╝");
            Console.ResetColor();
            Console.WriteLine();

            Console.Write("Ingrese los nombres del tutor: ");
            nombres = Console.ReadLine();
            Console.WriteLine();

            Console.Write("Ingrese los apellidos del tutor: ");
            apellidos = Console.ReadLine();
            Console.WriteLine();

            Console.Write("Ingrese el teléfono del tutor: ");
            telefono = Console.ReadLine();
            Console.WriteLine();

            Console.Write("Ingrese el correo del beneficiario: ");
            correo = Console.ReadLine();
            Console.WriteLine();

            Console.Write("Ingrese el grupo etario del tutor: ");
            grupo_etario = Console.ReadLine();
            Console.WriteLine();

            Console.Write("Ingrese la edad mínima del tutor: ");
            edad_minima = Console.ReadLine();
            Console.WriteLine();
            Console.Write("Ingrese la edad máxima del tutor: ");
            edad_maxima = Console.ReadLine();
            Console.WriteLine();
            Clases.Tutores objTutor = new Clases.Tutores(nombres, apellidos, telefono, correo, grupo_etario, edad_minima, edad_maxima);
            Console.WriteLine("Tutor " + nombres + " " + apellidos + " grabado con éxito!!");
            Console.ReadLine();
        }

        //==========================================================================================================================================================        

        //ELIMINAR BENEFICIARIO
        private static void DeleteBeneficiario()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("╔═══════════════════════════════════════════════╗");
            Console.WriteLine("║ * * * ELIMINAR DATOS DE UN BENEFICIARIO * * * ║");
            Console.WriteLine("╚═══════════════════════════════════════════════╝");
            Console.ResetColor();
            Console.WriteLine();
            Console.Write("Ingrese el código del beneficiario a eliminar: ");
            string codigo = Console.ReadLine();
            Beneficiarios objBeneficiarioBusacado = BaseDeDatos.GetBeneficiariosXCodigo(codigo);
            if (objBeneficiarioBusacado == null)
            {
                Console.WriteLine("Código de beneficiario no encontrado.");
            }
            else
            {
                Console.WriteLine("¿Está seguro que desea eliminar este beneficiario? (S/N)");
                string respuesta = Console.ReadLine().ToUpper();
                if (respuesta == "S")
                {
                    BaseDeDatos.BaseDatosBeneficiarios.Remove(objBeneficiarioBusacado);
                    Console.WriteLine("Beneficiario eliminado con éxito.");
                }
                else
                {
                    Console.WriteLine("Eliminación cancelada.");
                }
                Console.ReadLine();
            }
        }


        //ACTUALIZAR DATOS DE UN BENEFICIARIO
        private static void UpdateBeneficiario()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("╔═════════════════════════════════════════════════╗");
            Console.WriteLine("║ * * * ACTUALIZAR DATOS DE UN BENEFICIARIO * * * ║");
            Console.WriteLine("╚═════════════════════════════════════════════════╝");
            Console.ResetColor();
            Console.Write("Ingrese el código del beneficiario a actualizar: ");
            string codigo = Console.ReadLine();
            Beneficiarios objBeneficiarioActualizar = BaseDeDatos.GetBeneficiariosXCodigo(codigo);

            if (objBeneficiarioActualizar == null)
            {
                Console.WriteLine("Código de beneficiario no encontrado.");
            }
            else
            {
                objBeneficiarioActualizar.ImprimirBeneficiarios();
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
                BaseDeDatos.BaseDatosBeneficiarios.RemoveAt(Convert.ToInt32(objBeneficiarioActualizar.getCodigo()) - 1);
                BaseDeDatos.BaseDatosBeneficiarios.Insert(Convert.ToInt32(objBeneficiarioActualizar.getCodigo()) - 1, objBeneficiarioActualizar);
                Console.WriteLine("Beneficiario actualizado con éxito.");
                Console.ReadLine();
            }
        }

        //CONSULTAR BENEFICIARIO POR CODIGO
        private static void ReadBeneficiario()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("╔════════════════════════════════════════════════╗");
            Console.WriteLine("║ * * * CONSULTAR DATOS DE UN BENEFICIARIO * * * ║");
            Console.WriteLine("╚════════════════════════════════════════════════╝");
            Console.ResetColor();
            Console.Write("Ingrese el código del beneficiario a consultar: ");
            string codigo = Console.ReadLine();

            Beneficiarios objBeneficiarioConsultar = BaseDeDatos.GetBeneficiariosXCodigo(codigo);
            if (objBeneficiarioConsultar == null)
            {
                Console.WriteLine("Código de beneficiario no encontrado.");
            }
            else
            {
                objBeneficiarioConsultar.ImprimirBeneficiarios();
            }
            Console.ReadLine();
        }
        //LISTA DE TODOS LOS BENEFICIARIOS
        private static void ReadAllBeneficiario()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("╔════════════════════════════════════════════════╗");
            Console.WriteLine("║ * * * LISTADO DE TODOS LOS BENEFICIARIOS * * * ║");
            Console.WriteLine("╚════════════════════════════════════════════════╝");
            Console.ResetColor();
            foreach (var beneficiarios in BaseDeDatos.BaseDatosBeneficiarios)
            {
                beneficiarios.ImprimirBeneficiarios();
            }
            Console.ReadLine();
        }

        //CREAR BENEFICIARIO
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
