using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fundacion_Resplandece_Kid.Clases.Base;

namespace Fundacion_Resplandece_Kid.Clases
{
    [Serializable]
    public class Tutores
    {
        private int id;
        private string codigo;
        private string nombres;
        private string apellidos;
        private string telefono;
        private string email;
        private string grupo_etario;
        private int edad_minima;
        private int edad_maxima;
        private string nombres_completos;

        public Tutores(string nombres, string apellidos, string telefono, string email, string grupo_etario, string edad_minima_str, string edad_maxima_str)
        {
            this.id = BaseDeDatos.BaseDatosBeneficiarios.Count() + 1;
            this.codigo = "TU" + this.id.ToString("D4");
            this.nombres = nombres;
            this.apellidos = apellidos;
            this.telefono = telefono;
            this.email = email;
            this.grupo_etario = grupo_etario;
            int parsedMinAge;
            this.nombres_completos = this.nombres + " " + this.apellidos;
            if (int.TryParse(edad_minima_str, out parsedMinAge))
            {
                this.edad_minima = parsedMinAge;
            }

            int parsedMaxAge;
            if (int.TryParse(edad_maxima_str, out parsedMaxAge))
            {
                this.edad_maxima = parsedMaxAge;
            }
        } 
        //{ }
        public int GetId()
        {
            return id;
        }
        public string getCodigo()
        {
            return this.codigo;
        }
        public void Setnombres(string nombres)
        {
            this.nombres = nombres;
            this.nombres_completos = this.nombres + " " + this.apellidos;
        }
        public void SetApellidos(string apellidos)
        {
            this.apellidos = apellidos;
            this.nombres_completos = this.nombres + " " + this.apellidos;
        }
        public string GetNombresCompletos()
        {
            return nombres_completos;
        }
        public string GetTelefono()
        {
            return telefono;
        }
        public string Getcorreo()
        {
            return email;
        }
        public string GetGrupoEtario()
        {
            return grupo_etario;
        }
        public int GetEdadMinima()
        {
            return edad_minima;
        }
        public int GetEdadMaxima()
        {
            return edad_maxima;
        }
        public void ImprimirTutores()
        {
            Console.WriteLine(" ╔══════════════════════════════════════════════════════════════════════════════════════════════════╗");
            Console.WriteLine(" ║                 Datos del beneficiario registrado                             ║".PadRight(80) + "║");
            Console.WriteLine(" ╠══════════════════════════════════════════════════════════════════════════════════════════════════╣");
            Console.WriteLine($"║ ID: {this.id}".PadRight(80) + "║");
            Console.WriteLine($"║ Codigo: {this.codigo}".PadRight(80) + "║");
            Console.WriteLine($"║ Nombres Completos: {this.nombres_completos}".PadRight(80) + "║");
            Console.WriteLine($"║ Teléfono: {this.telefono}".PadRight(80) + "║");
            Console.WriteLine($"║ Correo: {this.email}".PadRight(80) + "║");
            Console.WriteLine($"║ Grupo Etario: {this.grupo_etario} (Edades : {edad_minima} - {edad_maxima} años)".PadRight(80) + "║");
            Console.WriteLine(" ╚══════════════════════════════════════════════════════════════════════════════════════════════════╝");
        }
    }
}
