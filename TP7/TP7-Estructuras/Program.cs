using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP7_Estructuras
{
    class Program
    {

        public enum Cargos { Auxiliar, Administrativo, Ingeniero, Especialista, Investigador };
        public enum Nombres { Claudio, Pedro, Maria };
        public enum Apellidos { Armando, Aleman, Fernandez };
        //public string[] estadocivil = {"asd","asd","asd","asd"};
        public enum EstadoCivil { Soltero,Casado,Divorciado,Viudo };
        public enum Genero { Hombre,Mujer,Indistinto};

        public struct Personal
        {
            public string Nombre, Apellido, EstadoCivil, Genero;
            public double Sueldo;
            public Cargos Cargo;
            public DateTime FechaNacimiento, FechaIngreso;

            public Personal (string _Nombre, string _Apellido, string _EstadoCivil, string _Genero,double _Sueldo,Cargos _Cargo,DateTime _FechaNacimiento, DateTime _FechaIngreso)
            {
                Nombre = _Nombre;
                Apellido = _Apellido;
                EstadoCivil = _EstadoCivil;
                Genero = _Genero;
                Sueldo = _Sueldo;
                Cargo = _Cargo;
                FechaNacimiento = _FechaNacimiento;
                FechaIngreso = _FechaIngreso;
            }

            public void mostrarDatos()
            {
                Console.Write(" Nombre: "+Nombre+"\n Apellido: "+Apellido+"\n Edad: "+edad()+"\n Estado civil: "+EstadoCivil+"\n Genero: "+Genero+"\n Sueldo: "+Sueldo+"\n Cargo: "+Cargo+
                    "\n Fecha de nacimiento: "+ FechaNacimiento.ToString("dd/MM/yyyy")+"\n Fecha de Ingreso: "+FechaIngreso.ToString("dd/MM/yyyy") + "\n Antigüedad: "+antiguedad()+
                    "\n Años para jubilarse: "+jubilacion()+"\n\n");
            }

            public double edad()
            {
                double edad;
                edad = (DateTime.Today.Year - FechaNacimiento.Year);
                return edad;
            }

            public double antiguedad()
            {
                double antiguedad;
                antiguedad = (DateTime.Today.Year - FechaIngreso.Year);
                return antiguedad;
            }

            public double jubilacion()
            {
                double jubilacion;
                if (Genero == "Hombre")
                    jubilacion = 65 - antiguedad();
                else
                    jubilacion = 60 - antiguedad();
                return jubilacion;
            }

            public double salario()
            {
                double salario=0,adicional;
                int hijos=rand.Next(1,6);
                return salario;
            }
        }

        //ESTA BIEN ESTA DECLARACION????????
        static public Random rand = new Random();

        static void Main(string[] args)
        {
            MENU();
        }

        static public void MENU()
        {
            int Opcion = 1,cont = 0;
            List<Personal> Empresa = new List<Personal>();
            while (Opcion>0)
            {
                Console.Clear();
                Console.Write("1: INGRESAR EMPLEADO.\n2: ANTIGÜEDAD.\n3: EDAD.\n4: JUBILACION.\n5: SALARIO.\n6: CANTIDAD DE EMPLEADOS.\n7: MONTO TOTAL.\n8: MOTRAR DATOS.\n0: SALIR.\nOPCION: ");
                Opcion = int.Parse(Console.ReadLine());
                switch (Opcion)
                {
                    case 1:
                        Console.Clear();
                        while (cont < 20)
                        {
                            generarPersonal(Empresa);
                            cont++;
                        }
                        cont = 0;
                        foreach(Personal personal in Empresa)
                        {
                            Console.Write((cont+1) + "*****************************************\n\n");
                            personal.mostrarDatos();
                            cont++;
                        }
                        Console.ReadKey();
                        break;
            }
        }

        static public void generarPersonal(List<Personal> lista)
        {
            string Nombre, Apellido, EstadoCivil, Genero;
            double Sueldo;
            Cargos cargo;
            DateTime FechaNacimiento, FechaIngreso;
            int Añon, Mesn, Añoi, Mesi;



            /*Console.Write("**********");
            Console.Write("*EMPLEADO*");
            Console.Write("**********");*/
            Nombre = Enum.GetNames(typeof(Nombres))[rand.Next((Enum.GetNames(typeof(Nombres)).Length))];
            Apellido = Enum.GetNames(typeof(Apellidos))[rand.Next((Enum.GetNames(typeof(Apellidos)).Length))];
            EstadoCivil = Enum.GetNames(typeof(EstadoCivil))[rand.Next((Enum.GetNames(typeof(EstadoCivil)).Length))];
            Genero = Enum.GetNames(typeof(Genero))[rand.Next((Enum.GetNames(typeof(Genero)).Length))];
            //POR QUE? NO DEBERIA PRODUCIR ERROR?
            cargo = (Cargos)Enum.GetValues(typeof(Cargos)).GetValue(rand.Next(Enum.GetNames(typeof(Cargos)).Length));
            Sueldo = rand.Next(15, 30) * 1000;
            Añon = rand.Next(1950, DateTime.Today.Year-18);
            Mesn = rand.Next(1, 12);
            FechaNacimiento = new DateTime(Añon, Mesn, rand.Next(1,DateTime.DaysInMonth(Añon,Mesn)));
            Añoi = rand.Next(Añon + 18, DateTime.Today.Year);
            Mesi = rand.Next(1,12);
            FechaIngreso = new DateTime(Añoi,Mesi, rand.Next(1, DateTime.DaysInMonth(Añoi, Mesi)));
            Personal personal = new Personal(Nombre,Apellido,EstadoCivil,Genero,Sueldo,cargo,FechaNacimiento,FechaIngreso);
            lista.Add(personal);
        }
    }
}
