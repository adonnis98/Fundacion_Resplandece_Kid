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
        public static Beneficiarios BuscarBeneficiarioPorId(int id)
        {
            return BaseDatosBeneficiarios.FirstOrDefault(b => b.id == id);
        }
      //  public static Beneficiarios BuscarBeneficiarioPorCedula(string cedula)
     // {
     //       return BaseDatosBeneficiarios.FirstOrDefault(b => b.cedula == cedula);
  //}
    }
}
