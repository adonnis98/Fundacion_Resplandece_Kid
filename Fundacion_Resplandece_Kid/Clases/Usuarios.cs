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
        public string usuario;
        public string contrasena;
        public string rol;

        public Usuarios(string usuario, string contrasena, string admin)
        {
            this.usuario = usuario;
            this.contrasena = contrasena;
            this.rol = admin;
            BaseDeDatos.BaseDatosUsuarios.Add(this);
        }

        public Usuarios()
        {
        }

        public void CrearUsuariosAdministrativos()
        {
            Usuarios admin1 = new Usuarios("David", "DA2025", "Administrador");
            BaseDeDatos.BaseDatosUsuarios.Add(admin1);

            Usuarios admin2 = new Usuarios("Williams", "WILL2025", "Administrador");
            BaseDeDatos.BaseDatosUsuarios.Add(admin2);

            Usuarios admin3 = new Usuarios("Adonis", "ADN123", "Administrador");
            BaseDeDatos.BaseDatosUsuarios.Add(admin3);

            Usuarios admin4 = new Usuarios("Gabriel", "GAB123", "Administrador");
            BaseDeDatos.BaseDatosUsuarios.Add(admin4);
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

