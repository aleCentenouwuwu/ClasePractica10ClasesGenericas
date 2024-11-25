using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductoPrecio
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<Producto> productos = new List<Producto>
        {
            new Producto { Nombre = "Tomates", Precio = 400 },
            new Producto { Nombre = "Manzanas", Precio = 250 },
            new Producto { Nombre = "Fetuccini", Precio = 50 },
            new Producto { Nombre = "Guanabana que asco", Precio = 10 },
            new Producto { Nombre = "Maracuya", Precio = 183 },
            new Producto { Nombre = "Sandia uwu", Precio = 50000 }
        };
            bool cont = true;
            do
            {
                try
                {
                    Console.Clear();
                    Console.WriteLine("buenas ingresa precio a filtrar porfa");
                    double MinPrecio = double.Parse(Console.ReadLine());
                    Filtro<Producto> filtro = new Filtro<Producto>();
                    List<Producto> filtrados = filtro.FiltrarPrecio(productos, MinPrecio);
                    Console.WriteLine($"Productos con precio mayor a {MinPrecio}:");
                    foreach (var producto in filtrados)
                    {
                        Console.WriteLine($"{producto.Nombre} - ${producto.Precio}");
                    }
                    Console.WriteLine("Desea continuar? \n1. Si \n2. No");
                    byte opc = byte.Parse(Console.ReadLine());
                    if (opc == 2)
                    {
                        cont = false;
                    }
                }
                catch (FormatException) { MensajeError(); }
                catch (Exception) { MensajeError(); }
            } while (cont);
        }
static void MensajeError()
{
    Console.Clear();
    Console.WriteLine("Ingrese la informacion correctamente");
    Console.ReadKey();
}

    }

    public class Producto
    {
        public string Nombre { get; set; }
        public double Precio { get; set; }
    }

    public class Filtro<T> where T : Producto
    {
        public List<T> FiltrarPrecio(List<T> productos, double PrecioMinimo)
        {
            return productos.Where(p => p.Precio >  PrecioMinimo).ToList();
        }
    }
}
