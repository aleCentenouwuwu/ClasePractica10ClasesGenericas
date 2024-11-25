using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClasePractica10ClasesGenericas
{
    class Program
    {
        static void Main(string[] args)
        {
            Inventory<string> inventory = new Inventory<string>();
            bool continuar = true;
            do
            {
                try
                {
                    Console.Clear();
                    Console.WriteLine("Bienvenido");
                    Console.WriteLine("Que desea hacer? \n1. Agregar producto \n2. Borrar producto \n3. Ver inventario \n0. Salir");
                    byte opc = byte.Parse(Console.ReadLine());
                    switch (opc)
                    {
                        case 0:
                            Console.Clear();
                            Console.WriteLine("Nos vemos");
                            continuar = false;
                            break;
                        case 1:
                            Console.Clear();
                            Console.WriteLine("Ingrese nombre del producto a agregar");
                            string producto = Console.ReadLine();
                            inventory.AgregarProducto(producto);
                            break;
                        case 2:
                            Console.Clear();
                            Console.WriteLine("Ingrese indice de producto a eliminar");
                            int indice = Int32.Parse(Console.ReadLine());
                            inventory.EliminarProducto(indice - 1);
                            break;
                        case 3:
                            Console.Clear();
                            inventory.MostrarProductos();
                            break;
                        default:
                            Console.WriteLine("opcion no valida");
                            break;
                    }
                }
                catch(IndexOutOfRangeException){ MensajeError();}
                catch(FormatException) { MensajeError(); }
                catch(Exception) { MensajeError();  }

             } while (continuar) ;
        }
    static void MensajeError()
        {
            Console.Clear();
            Console.WriteLine("Ingrese la informacion correctamente");
            Console.ReadKey();
        }
    }

    public class Inventory<T>
    {
        private List<T> productos = new List<T>();
            
        public void AgregarProducto(T producto)
        {
            productos.Add(producto);
            Console.WriteLine($"Se agrego {producto}");
            Console.ReadKey();
        }

        public void EliminarProducto(int indice)
        {
            if (indice >= 0 && indice < productos.Count)
            {
                Console.WriteLine($"Se eliminó {productos[indice]}");
                productos.RemoveAt(indice);
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Índice no encontrado.");
                Console.ReadKey();
            }
        }

        public void MostrarProductos()
        {
            Console.WriteLine("-------Inventario-------");
            foreach (var producto in productos)
            {
                Console.WriteLine(producto);
            }
            Console.ReadKey();
        }
    }
}