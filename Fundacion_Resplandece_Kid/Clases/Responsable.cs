using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fundacion_Resplandece_Kid.Clases
{
    [Serializable]
    public class Responsable
    {
        private string cedula;
        private string nombres;
        private string apellidos;
        private string telefono;
        private string email;
        private int edad;
        private string parentesco;
        private string nombres_completos;

        public Responsable(string cedula, string nombres, string apellidos, string telefono, string email, string parentesco)
        {
            this.cedula = cedula;
            this.nombres = nombres;
            this.apellidos = apellidos;
            this.telefono = telefono;
            this.email = email;
            this.parentesco = parentesco;
            this.nombres_completos = nombres + " " + apellidos;
        }

        public string GetCedula()
        {
            return cedula;
        }

        public string GetNombres()
        {
            return nombres;
        }
        public string GetApellidos()
        {
            return apellidos;
        }
        public string GetTelefono()
        {
            return telefono;
        }
        public string GetEmail()
        {
            return email;
        }
        public int GetEdad()
        {
            return edad;
        }
        public string GetParentesco()
        {
            return parentesco;
        }
        public string GetNombresCompletos()
        {
            return nombres_completos;
        }

        public void SetNombres(string nombres)
        {
            this.nombres = nombres;
            this.nombres_completos = this.nombres + " " + this.apellidos;
        }
        public void SetApellidos(string apellidos)
        {
            this.apellidos = apellidos;
            this.nombres_completos = this.nombres + " " + this.apellidos;
        }
        public void SetTelefono(string telefono)
        {
            this.telefono = telefono;
        }
        public void SetEmail(string email)
        {
            this.email = email;
        }
        public void SetEdad(int edad)
        {
            this.edad = edad;
        }
        public void SetParentesco(string parentesco)
        {
            this.parentesco = parentesco;
        }

        public void ImprimirResponsable()
        {
            Console.WriteLine(" ╔══════════════════════════════════════════════════════════════════════════════════╗");
            Console.WriteLine(" ║                  DATOS DEL PADRE/MADRE/RESPONSABLE                               ║".PadRight(80) + "║");
            Console.WriteLine(" ╠══════════════════════════════════════════════════════════════════════════════════╣");
            Console.WriteLine($"║ Cédula: {this.cedula}".PadRight(80) + "║");
            Console.WriteLine($"║ Nombres Completos: {this.nombres_completos}".PadRight(80) + "║");
            Console.WriteLine($"║ Teléfono: {this.telefono}".PadRight(80) + "║");
            Console.WriteLine($"║ Email: {this.email}".PadRight(80) + "║");
            Console.WriteLine($"║ Parentesco: {this.parentesco}".PadRight(80) + "║");
            Console.WriteLine(" ╚══════════════════════════════════════════════════════════════════════════════════╝");
        }
    }
}
