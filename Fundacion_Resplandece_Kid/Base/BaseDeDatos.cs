using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Fundacion_Resplandece_Kid.Clases.Base
{
    public static class BaseDeDatos
    {
        public static List<Beneficiarios> BaseDatosBeneficiarios = new List<Beneficiarios>();
        private static string nombreBaseDatosBeneficiarios = "Beneficiarios.dat";

        public static void guardarDatosEnArchivoBeneficiarios()
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream nuevoArchivo = new FileStream(nombreBaseDatosBeneficiarios, FileMode.Create);
            bf.Serialize(nuevoArchivo, BaseDatosBeneficiarios);
        }
        public static void cargarDatosDesdeArchivoBeneficiarios()
        {
            if (File.Exists(nombreBaseDatosBeneficiarios))
            {
                BinaryFormatter bf = new BinaryFormatter();
                FileStream archivoExistente = new FileStream(nombreBaseDatosBeneficiarios, FileMode.Open);
                BaseDatosBeneficiarios = (List<Beneficiarios>)bf.Deserialize(archivoExistente);
                archivoExistente.Close();
            }
        }
//=================================================================================================================================

        public static List<Usuarios> BaseDatosUsuarios = new List<Usuarios>();
        private static string nombreBaseDatosUsuarios= "Usuarios.dat";

        public static void GuardarDatosEnArchivo()
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream nuevoArchivo = new FileStream(nombreBaseDatosUsuarios, FileMode.Create);
            bf.Serialize(nuevoArchivo, BaseDatosUsuarios);
        }
        public static void CargarDatosDesdeArchivo()
        {
            if (File.Exists(nombreBaseDatosUsuarios))
            {
                BinaryFormatter bf = new BinaryFormatter();
                FileStream archivoExistente = new FileStream(nombreBaseDatosUsuarios, FileMode.Open);
                BaseDatosUsuarios = (List<Usuarios>)bf.Deserialize(archivoExistente);
                archivoExistente.Close();
            }
        }
//=================================================================================================================================
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

        public static Tutores GetTutoresXCodigo(string codigo)
        {
            foreach (var item in BaseDatosTutores)
            {
                if (item.getCodigo() == codigo)
                {
                    return item;
                }
            }
            return null;
        }
        //=================================================================================================================================        
        public static List<Tutores> BaseDatosTutores = new List<Tutores>();
        private static string nombreBaseDatosTutores = "Tutores.dat";

        public static void guardarDatosEnArchivo()
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream nuevoArchivo = new FileStream(nombreBaseDatosTutores, FileMode.Create);
            bf.Serialize(nuevoArchivo, BaseDatosTutores);
        }
        public static void cargarDatosDesdeArchivo()
        {
            if (File.Exists(nombreBaseDatosTutores))
            {
                BinaryFormatter bf = new BinaryFormatter();
                FileStream archivoExistente = new FileStream(nombreBaseDatosTutores, FileMode.Open);
                BaseDatosTutores = (List<Tutores>)bf.Deserialize(archivoExistente);
                archivoExistente.Close();
            }
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
