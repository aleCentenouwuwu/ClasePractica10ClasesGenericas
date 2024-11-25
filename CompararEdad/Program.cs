using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompararEdad
{
    public class Program
    {
        static void Main(string[] args)
        {
            bool Continue = true;
            do
            {
                try
                {
                    Console.Clear();
                    Console.WriteLine("Bienvenido! Ingrese nombres y edades por favor");
                    Console.WriteLine("Nombre y edad (1)");
                    string nombre1 = Console.ReadLine(); int edad1 = Int32.Parse(Console.ReadLine());
                    Persona persona1 = new Persona { Nombre = nombre1 , Edad = edad1};
                    Console.WriteLine("Nombre y edad (2)");
                    string nombre2 = Console.ReadLine(); int edad2 = Int32.Parse(Console.ReadLine());
                    Persona persona2 = new Persona { Nombre= nombre2, Edad= edad2};
                    Comparer<Persona> comparer = new Comparer<Persona>();
                    var mayor = comparer.Comparar(persona1, persona2);
                    Console.WriteLine($"La persona mayor es: {mayor.Nombre} con {mayor.Edad} años.");
                    Console.WriteLine("Desea continuar? \n1. Si \n2. No");
                    byte opc = byte.Parse(Console.ReadLine());
                    if (opc == 2)
                    {
                        Continue = false;
                    }
                }
               
                catch (FormatException) { MensajeError(); }
                catch (Exception) { MensajeError(); }
            } while (Continue);
        }
        static void MensajeError()
        {
            Console.Clear();
            Console.WriteLine("Ingrese la informacion correctamente");
            Console.ReadKey();
        }
    }
}
    public class Persona
    {
        public int Edad { get; set; }
        public string Nombre { get; set; }
      
    }
public class Comparer<T> where T : Persona
{
    public T Comparar(T person1, T person2)
    {
        return person1.Edad > person2.Edad ? person1 : person2;
    }
}

