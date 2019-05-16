using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP7_Estructuras
{
    class Program
    {

        public enum Cargo {Auxiliar,Administrativo, Ingeniero, Especialista, Investigador};

        public struct Personal
        {
            public string Nombre, Apellido, FechaNacimiento, EstadoCivil, Genero, FechaIngreso;
            public double Sueldo;
            public Cargo cargo;
        }


        static void Main(string[] args)
        {
            MENU();
        }

        static public void MENU()
        {
            Console.Write()
        }
    }
}
