using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fundacion_Resplandece_Kid.Clases.Base
{
    public static class BaseDeDatos
    {
        public static List<Beneficiarios> BaseDatosBeneficiarios = new List<Beneficiarios>();
        public static List<Usuarios> BaseDatosUsuarios = new List<Usuarios>();
        public static Beneficiarios GetBeneficiariosXCodigo(string codigo )
        {
            foreach (var item in BaseDatosBeneficiarios)
            {
                if (item.getCodigo() == codigo)
                {
                    return item;
                }
            }
            return null;
        }
        

        // public static void CrearUsuariosAdministrativos()
        //{
        //  Usuarios admin1 = new Usuarios("DA2025", "David", "Administrador");
        //Usuarios admin2 = new Usuarios("MA2025", "María", "Administrador");
        //Usuarios admin3 = new Usuarios("JU2025", "Juan", "Administrador");
        //Usuarios admin4 = new Usuarios("LA2025", "Laura", "Administrador");
        //Usuarios admin5 = new Usuarios("PE2025", "Pedro", "Administrador");
        //}
        // // con esto autentificamos a un usuario si son los registrados
        public static void MostarUsuario()
        {
            foreach (var usuario in BaseDatosUsuarios)
            {
                usuario.Imprimir();
            }
        }

        // con esto autentificamos a un usuario si son los registrados
        public static Usuarios GetUsuariosXCodigo(string codigo)
        {
            foreach (var item in BaseDatosUsuarios)
            {
                if (item.getCodigo() == codigo)
                {
                    return item;
                }
            }
            return null;

        }
   
    }
}
