using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fundacion_Resplandece_Kid.Clases.Base;

namespace Fundacion_Resplandece_Kid.Clases
{
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
        public List<Usuarios> UsuariosDelSistema;

        public Usuarios()
        {
            UsuariosDelSistema = new List<Usuarios>();
        }

        public void CrearUsuariosAdministrativos()
        {
            Usuarios admin1 = new Usuarios("David", "DA2025", "Administrador");
            UsuariosDelSistema.Add(admin1);

            Usuarios admin2 = new Usuarios("Williams", "WILL2025", "Administrador");
            UsuariosDelSistema.Add(admin2);

            Usuarios admin3 = new Usuarios("Adonis", "ADN123", "Administrador");
            UsuariosDelSistema.Add(admin3);

            Usuarios admin4 = new Usuarios("Gabriel", "GAB123", "Administrador");
            UsuariosDelSistema.Add(admin4);
        }


        //codigo por tener private
        public string getCodigo()
        {
            return this.codigo;
        }

        public void Imprimir()
        {
            Console.WriteLine(" ╔══════════════════════════════════════════════════════════════╗");
            Console.WriteLine($"║ Codigo: {this.codigo}".PadRight(52) + "║");
            Console.WriteLine($"║ Usuario: {this.usuario}".PadRight(52) + "║");
            Console.WriteLine($"║ Contraseña: {this.contrasena}".PadRight(52) + "║");
            Console.WriteLine($"║ Rol: {this.rol}".PadRight(52) + "║");
            Console.WriteLine(" ╚══════════════════════════════════════════════════════════════╝");
        }

        public void MostrarUsuarios()
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
        //para crear un nuevo usuario desde dentro del sistema
        //public void CrearUsuariosAdministrativos()
        //{
        //Usuario admin1 = new Usuario("Pilar", "PI2025", "Administrador");
        //UsuariosDelSistema.Add(admin1);
        //Usuario admin2 = new Usuario("Narcisa", "NAR2025", "Administrador");
        //UsuariosDelSistema.Add(admin2);
        //USUARIO CLASE HECHA POR ADONIS
    }
}

