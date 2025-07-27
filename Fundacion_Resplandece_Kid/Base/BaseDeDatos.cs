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
            using (FileStream nuevoArchivo = new FileStream(nombreBaseDatosBeneficiarios, FileMode.Create))// 
            {
                BinaryFormatter bf = new BinaryFormatter();
                //FileStream nuevoArchivo = new FileStream(nombreBaseDatosBeneficiarios, FileMode.Create);
                bf.Serialize(nuevoArchivo, BaseDatosBeneficiarios);
            }
        }

        public static void cargarDatosDesdeArchivoBeneficiarios()
        {
            if (File.Exists(nombreBaseDatosBeneficiarios))
            {
                using (FileStream abrirArchivo = new FileStream(nombreBaseDatosBeneficiarios, FileMode.Open)) //
                {
                    BinaryFormatter bf = new BinaryFormatter();
                    // FileStream archivoExistente = new FileStream(nombreBaseDatosBeneficiarios, FileMode.Open);
                    BaseDatosBeneficiarios = (List<Beneficiarios>)bf.Deserialize(abrirArchivo); //archivoExistente
                }
                // archivoExistente.Close();
            }
        }
        public static Beneficiarios GetBeneficiariosXCodigo(string codigo)
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
        public static void MostrarBeneficiarios()
        {
            foreach (var beneficiarios in BaseDatosBeneficiarios)
            {
                beneficiarios.ImprimirBeneficiarios();
            }
        }



        //=================================================================================================================================
        //=================================================================================================================================

        public static List<Usuarios> BaseDatosUsuarios = new List<Usuarios>();
        private static string nombreBaseDatosUsuarios = "Usuarios.dat";

        public static void guardarDatosEnArchivoUsuarios()
        {
            using (FileStream nuevoArchivo = new FileStream(nombreBaseDatosUsuarios, FileMode.Create))
            {
                BinaryFormatter bf = new BinaryFormatter();
                // FileStream nuevoArchivo = new FileStream(nombreBaseDatosUsuarios, FileMode.Create);
                bf.Serialize(nuevoArchivo, BaseDatosUsuarios);
            }
        }
        public static void cargarDatosDesdeArchivoUsuarios()
        {
            if (File.Exists(nombreBaseDatosUsuarios))
            {
               
                    BinaryFormatter bf = new BinaryFormatter();
                    FileStream archivoExistente = new FileStream(nombreBaseDatosUsuarios, FileMode.Open);
                    BaseDatosUsuarios = (List<Usuarios>)bf.Deserialize(archivoExistente); //archivoExistente
                
                archivoExistente.Close();
            }
        }
        public static void MostarUsuario()
        {
            foreach (var usuario in BaseDatosUsuarios)
            {
                usuario.Imprimir();
            }
        }

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

        //=================================================================================================================================
        //=================================================================================================================================        
        public static List<Tutores> BaseDatosTutores = new List<Tutores>();
        private static string nombreBaseDatosTutores = "Tutores.dat";

        public static void guardarDatosEnArchivoTutores()
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream nuevoArchivo = new FileStream(nombreBaseDatosTutores, FileMode.Create);
            bf.Serialize(nuevoArchivo, BaseDatosTutores);
        }
        public static void cargarDatosDesdeArchivoTutores()
        {
            if (File.Exists(nombreBaseDatosTutores))
            {
                BinaryFormatter bf = new BinaryFormatter();
                FileStream archivoExistente = new FileStream(nombreBaseDatosTutores, FileMode.Open);
                BaseDatosTutores = (List<Tutores>)bf.Deserialize(archivoExistente);
                archivoExistente.Close();
            }
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
        //=================================================================================================================================
        public static List<Responsable> BaseDatosResponsable = new List<Responsable>();
        private static string nombreBaseDatosResponsable = "Responsable.dat";

        public static void guardarDatosEnArchivoResponsable()
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream nuevoArchivo = new FileStream(nombreBaseDatosResponsable, FileMode.Create);
            bf.Serialize(nuevoArchivo, BaseDatosResponsable);
        }
        public static void cargarDatosDesdeArchivoResponsable()
        {
            if (File.Exists(nombreBaseDatosResponsable))
            {
                BinaryFormatter bf = new BinaryFormatter();
                FileStream archivoExistente = new FileStream(nombreBaseDatosResponsable, FileMode.Open);
                BaseDatosResponsable = (List<Responsable>)bf.Deserialize(archivoExistente);
                archivoExistente.Close();
            }
        }

    }
}
