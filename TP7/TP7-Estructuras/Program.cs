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
        public enum EstadoCivil { Soltero, Casado, Divorciado, Viudo };
        public enum Genero { Hombre, Mujer, Indistinto };

        public struct Personal
        {
            public string Nombre, Apellido;
            public double Sueldo;
            public Cargos Cargo;
            public EstadoCivil estadoCivil;
            public Genero genero;
            public DateTime FechaNacimiento, FechaIngreso;

            public Personal(string _Nombre, string _Apellido, EstadoCivil _EstadoCivil, Genero _Genero, double _Sueldo, Cargos _Cargo, DateTime _FechaNacimiento, DateTime _FechaIngreso)
            {
                Nombre = _Nombre;
                Apellido = _Apellido;
                estadoCivil = _EstadoCivil;
                genero = _Genero;
                Sueldo = _Sueldo;
                Cargo = _Cargo;
                FechaNacimiento = _FechaNacimiento;
                FechaIngreso = _FechaIngreso;
            }

            public void mostrarDatos()
            {
                Console.Write(" Nombre: " + Nombre + "\n Apellido: " + Apellido + "\n Edad: " + edad() + "\n Estado civil: " + estadoCivil + "\n Genero: " + genero + "\n Sueldo: $" + Sueldo + "\n Cargo: " + Cargo +
                    "\n Fecha de nacimiento: " + FechaNacimiento.ToString("dd/MM/yyyy") + "\n Fecha de Ingreso: " + FechaIngreso.ToString("dd/MM/yyyy") + "\n Antigüedad: " + antiguedad() +
                    "\n Años para jubilarse: " + jubilacion() + "\n Salario: $" + salario() + "\n\n");
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
                if (genero == Genero.Hombre)
                    jubilacion = 65 - antiguedad();
                else
                    jubilacion = 60 - antiguedad();
                return jubilacion;
            }

            public double salario()
            {
                Random rand = new Random();
                double salario = 0, adicional = 0;
                int hijos = rand.Next(1, 6);

                if (antiguedad() > 20)
                    adicional = Sueldo * 0.40 + Sueldo * 0.25;
                else
                    adicional = Sueldo * ((antiguedad() * 2) / 100);

                if (Cargo == Cargos.Ingeniero || Cargo == Cargos.Especialista)
                    adicional = adicional * 1.50;

                if (estadoCivil == EstadoCivil.Casado && hijos > 2)
                    adicional = adicional + 5000;

                salario = Sueldo + adicional;
                return salario;
            }
        }

        //ESTA BIEN ESTA DECLARACION????????
        static public Random rand = new Random();
        static List<Personal> Empresa = new List<Personal>();
        static public string[] Nombres = { "Claudio", "Pedro", "Maria" };
        static public string[] Apellidos = { "Armando", "Aleman", "Fernandez" };

        static void Main(string[] args)
        {
            MENU();
        }
        static public void MENU()
        {
            int Opcion = 1;
            //como hacer la lista global para todas las funciones???
            Console.Clear();
            Console.Write("1: SIMULAR CARGA DE 20 EMPLEADOS.\n2: EMPLEADOS.\n3: CANTIDAD DE EMPLEADOS.\n4: MONTO TOTAL DE LA EMPRESA (EN SALARIOS).\n0: SALIR.\nOPCION: ");
            Opcion = int.Parse(Console.ReadLine());
            switch (Opcion)
            {
                case 1:
                    Console.Clear();
                    simulador();
                    Otra_Operacion();
                    break;
                case 2:
                    Console.Clear();
                    empleados();
                    Otra_Operacion();
                    break;
                case 3:
                    Console.Clear();
                    cantidadEmpleados();
                    Otra_Operacion();
                    break;
                case 4:
                    Console.Clear();
                    montoSalarios();
                    Otra_Operacion();
                    break;
                case 0:
                    break;
            }
        }

        static public void generarPersonal(List<Personal> lista)
        {
            string Nombre, Apellido;
            double Sueldo;
            Cargos cargo;
            EstadoCivil estadoCivil;
            Genero genero;
            DateTime FechaNacimiento, FechaIngreso;
            int Añon, Mesn, Añoi, Mesi;

            Nombre = Nombres[rand.Next(Nombres.Length)];
            Apellido = Apellidos[rand.Next(Apellidos.Length)];
            estadoCivil = (EstadoCivil)(EstadoCivil)rand.Next(0, Enum.GetNames(typeof(EstadoCivil)).Length);
            genero = (Genero)rand.Next(0, Enum.GetNames(typeof(Genero)).Length);
            //POR QUE? NO DEBERIA PRODUCIR ERROR?
            cargo = (Cargos)(Cargos)rand.Next(0, Enum.GetNames(typeof(Cargos)).Length);
            Sueldo = rand.Next(15, 30) * 1000;
            Añon = rand.Next(1950, DateTime.Today.Year - 18);
            Mesn = rand.Next(1, 12);
            FechaNacimiento = new DateTime(Añon, Mesn, rand.Next(1, DateTime.DaysInMonth(Añon, Mesn)));
            Añoi = rand.Next(Añon + 17, DateTime.Today.Year);
            Mesi = rand.Next(1, 12);
            FechaIngreso = new DateTime(Añoi, Mesi, rand.Next(1, DateTime.DaysInMonth(Añoi, Mesi)));
            Personal personal = new Personal(Nombre, Apellido, estadoCivil, genero, Sueldo, cargo, FechaNacimiento, FechaIngreso);
            lista.Add(personal);
        }

        static public void simulador()
        {
            int cont = 0;
            while (cont < 20)
            {
                generarPersonal(Empresa);
                cont++;
            }
            cont = 0;
            foreach (Personal personal in Empresa)
            {
                Console.Write((cont + 1) + "*****************************************\n\n");
                personal.mostrarDatos();
                cont++;
            }
        }

        static public void empleados()
        {
            int i = 0, cont = 1;
            if (Empresa.Count != 0)
            {
                foreach (Personal _personal in Empresa)
                {
                    Console.WriteLine(cont + ": " + _personal.Apellido + ", " + _personal.Nombre);
                    cont++;
                }
                Console.Write("\n¿QUE EMPLEADO DESEA MOSTRAR?: ");
            }
            else
            {
                Console.Write("La lista esta vacia.");
                return;
            }
            i = int.Parse(Console.ReadLine()) - 1;
            Console.Write("\n\t\t\t**********\n");
            Console.Write("\t\t\t*EMPLEADO*\n");
            Console.Write("\t\t\t**********\n\n");
            Empresa[i].mostrarDatos();
        }

        static public void cantidadEmpleados()
        {
            Console.Write("Cantidad de empleados: " + Empresa.Count);
        }

        static public void montoSalarios()
        {
            double monto = 0;
            foreach (Personal _Personal in Empresa)
            {
                monto += _Personal.salario();
            }
            Console.Write("El monto total de la empresa en concepto de salarios: $" + monto);
        }

        static public void Otra_Operacion()
        {
            string eleccion;
            Console.Write("\n\nDESEA REALIZAR OTRA ACCION (Y/N): ");
            eleccion = Console.ReadLine();
            eleccion = eleccion.ToLower();
            if (eleccion == "y")
                MENU();
            else if (eleccion == "n")
                return;
            else
            {
                Console.Write("OPCION INCORRECTA.\n");
                Otra_Operacion();
            }
        }
    }
}
