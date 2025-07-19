using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fundacion_Resplandece_Kid.Clases.Base;

namespace Fundacion_Resplandece_Kid.Clases
{
    public class Beneficiarios
    {
        public int id;
        public string cedula;
        private string nombres;
        private string apellidos;
        private string direccion;
        private DateTime fecha_nacimiento;
        public string plantel_educativo;
        private string anio_educativo;
        private string telefono;
        private string email;
        private int edad;
        private string nombres_completos;



        public Beneficiarios(string cedula, string nombres, string apellidos, string direccion, DateTime fecha_nacimiento, string plantel_educativo, string anio_educativo, string telefono, string email)
        {
            this.id = BaseDeDatos.BaseDatosBeneficiarios.Count() + 1; // Generación de ID secuencial
            this.cedula = cedula;
            this.nombres = nombres;
            this.apellidos = apellidos;
            this.direccion = direccion;
            this.fecha_nacimiento = fecha_nacimiento;
            this.plantel_educativo = plantel_educativo;
            this.anio_educativo = anio_educativo;
            this.telefono = telefono;
            this.email = email;
            this.fecha_nacimiento = fecha_nacimiento;
            this.edad = DateTime.Now.Year - this.fecha_nacimiento.Year;
            this.nombres_completos = this.nombres + " " + this.apellidos;   
            BaseDeDatos.BaseDatosBeneficiarios.Add(this);
        }
        public int GetId()
        {
            return id;
        }
        public string GetCedula()
        {
            return cedula;
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
        public DateTime GetFechaNacimiento()
        {
            return fecha_nacimiento;
        }
        public int GetEdad()
        {
            return edad;
        }
        public string GetDireccion()
        {
            return direccion;
        }
        public string GetTelefono()
        {
            return telefono;
        }
        public string GetEmail()
        {
            return email;
        }
        public string GetPlantelEducativo()
        {
            return plantel_educativo;
        }
        public string GetAnioEducativo()
        {
            return anio_educativo;
        }



        public void Imprimir()
        {
            Console.WriteLine(" ╔══════════════════════════════════════════════════════════════════════════════════╗");
            Console.WriteLine(" ║                 Datos del beneficiario registrado             ║".PadRight(80) + "║");
            Console.WriteLine($"║ ID: {this.id}".PadRight(80) +                                                   "║");
            Console.WriteLine($"║ Cédula: {this.cedula}".PadRight(80) +                                           "║");
            Console.WriteLine($"║ Nombres Completos: {this.nombres_completos}".PadRight(80) +                     "║");
            Console.WriteLine($"║ Fecha de Nacimiento:{this.fecha_nacimiento.ToShortDateString()} ".PadRight(80) +"║");
            Console.WriteLine($"║ Edad: {this.edad} años ".PadRight(80) +                                         "║");
            Console.WriteLine($"║ Dirección: {this.direccion}".PadRight(80) +                                     "║");
            Console.WriteLine($"║ Teléfono: {this.telefono}".PadRight(80) +                                       "║");
            Console.WriteLine($"║ Email: {this.email}".PadRight(80) +                                             "║");
            Console.WriteLine($"║ Plantel Educativo: {this.plantel_educativo}".PadRight(80) +                     "║");
            Console.WriteLine($"║ Año Educativo: {this.anio_educativo}".PadRight(80) +                            "║");
            Console.WriteLine(" ╠══════════════════════════════════════════════════════════════════════════════════╣");
            Console.WriteLine(" ║                 Datos del Representante                       ║".PadRight(80) + "║");
            //if (this.representante != null)
            //{
                //Console.WriteLine($"║ Cédula Rep.: {this.representante.GetCedula()}".PadRight(80) + "║");
                //Console.WriteLine($"║ Teléfono Rep.: {this.representante.GetTelefono()}".PadRight(80) + "║");
                //Console.WriteLine($"║ Dirección Rep.: {this.representante.GetDireccion()}".PadRight(80) + "║");
              //  Console.WriteLine($"║ Parentesco : {this.representante.GetRelacionConBeneficiario()}".PadRight(80) + "║");
            //}
           // else
            //{
              //  Console.WriteLine($"║ No hay representante asignado para este beneficiario.     ║".PadRight(80) + "║");
            //}
            //Console.WriteLine("╚═══════════════════════════════════════════════════════════════════════════════════╝");
        }
    }
}

