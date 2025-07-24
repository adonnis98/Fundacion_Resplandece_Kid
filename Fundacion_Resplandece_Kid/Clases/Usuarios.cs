using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fundacion_Resplandece_Kid.Clases.Base;

namespace Fundacion_Resplandece_Kid.Clases
{
    [Serializable]
    public class Usuarios
    {
        private int id;
        private string codigo;
        private string usuario;
        private string contrasena;
        private string rol;


        public Usuarios(string usuario, string contrasena, string rol)
        {
            this.id = BaseDeDatos.BaseDatosUsuarios.Count() + 1; // Genera un ID secuencial para el usuario
            this.usuario = usuario;
            this.contrasena = contrasena;
            this.rol = rol;
            this.codigo = this.usuario.Substring(0, 2) + "-" + this.id.ToString();
            BaseDeDatos.BaseDatosUsuarios.Add(this);
        }
        public List<Usuarios> UsuariosDelSistema;// Lista de usuarios del sistema

        public Usuarios()
        {
            UsuariosDelSistema = new List<Usuarios>();// Inicializa la lista de usuarios del sistema
        }


        //codigo por tener private
        public string getCodigo()// 
        {
            return this.codigo;
        }

        public void Imprimir()
        {
            Console.WriteLine(" ╔══════════════════════════════════════════════════════════════╗");
            Console.WriteLine($"║ Codigo: {this.codigo}".PadRight(52) +                       "║");
            Console.WriteLine($"║ Usuario: {this.usuario}".PadRight(52) +                     "║");
            Console.WriteLine($"║ Contraseña: {this.contrasena}".PadRight(52) +               "║");
            Console.WriteLine($"║ Rol: {this.rol}".PadRight(52) +                             "║");
            Console.WriteLine(" ╚══════════════════════════════════════════════════════════════╝");
        }

        public void MostrarUsuarios() // muestra los usuarios registrados en la base de datos
        {
            foreach (var usuario in BaseDeDatos.BaseDatosUsuarios)
            {
                Console.WriteLine($"Usuario: {usuario.usuario}, Rol: {usuario.rol}");
            }
        }
        // con esto autentificamos a un usuario si son los registrados
        public bool AutenticarUsuario(string username, string password)
        {
            foreach (var user in BaseDeDatos.BaseDatosUsuarios)
            {
                if (user.usuario == username && user.contrasena == password)
                {
                    return true;
                }
            }
            return false;
        }
         
    }
}

