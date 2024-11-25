using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistroDeTareas
{
    public class Program
    {
        static void Main(string[] args)
        {
            TaskManager<string> taskManager = new TaskManager<string>();

            bool cont = true;
            do
            {
                try
                {
                 
                    Console.Clear();
                    Console.WriteLine("Qeu desea hacer \n1. Agregar Tarea \n2. Completar tarea \n3. Ver tareas completadas \n4. Ver tareas pendientes \n0. Salir ");
                    byte opc = byte.Parse(Console.ReadLine());
                    switch (opc)
                    {
                        case 0:
                            cont = false;
                            break;
                        case 1:
                            Console.Clear();
                            Console.WriteLine("Ingrese la tarea: ");
                            string nuevaTarea = Console.ReadLine();
                            taskManager.AgregarTarea(nuevaTarea);
                            Console.ReadKey();
                            break;

                        case 2:
                            Console.Clear();
                            Console.WriteLine("Ingrese la tarea a completar: ");
                            string tareaCompletar = Console.ReadLine();
                            taskManager.CompletarTarea(tareaCompletar);
                            Console.ReadKey();
                            break;

                        case 3:
                            Console.Clear();
                            Console.WriteLine("\nTareas completadas:");
                            taskManager.MostrarTareasCompletadas();
                            Console.ReadKey();
                            break;

                        case 4:
                            Console.Clear();
                            Console.WriteLine("\nTareas pendientes:");
                            taskManager.MostrarTareasPendientes();
                            Console.ReadKey();
                            break;
                        default:
                            Console.WriteLine("Error, opcion no valida");
                            break;
                    }

                }
                catch (FormatException)
                {
                    Console.Clear();
                    Console.WriteLine("Ingrese info correctamente");
                    Console.ReadLine();
                }
            } while (cont);
        }

        public class TaskManager<T>
        {
            private Dictionary<string, bool> Tareas = new Dictionary<string, bool>();
            public void AgregarTarea(T tarea)
            {
                string tareaNew = tarea.ToString().ToLower().Trim();
                if (!Tareas.ContainsKey(tareaNew))
                {
                    Console.Clear();
                    Tareas[tareaNew] = false;
                    Console.WriteLine($"Se agrego {tarea}");
                }
                else
                {
                    Console.WriteLine("La tarea ya existe");
                }

            }
            public void CompletarTarea(T tarea)
            {
                string tareaNew = tarea.ToString().ToLower().Trim();
                if (Tareas.ContainsKey(tareaNew))
                {
                    Console.Clear();
                    Tareas[tareaNew] = true;
                    Console.WriteLine($"Se completó la tarea {tarea}");
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("No se encontro la tarea");
                }
            }
            public void MostrarTareasCompletadas()
            {
                Console.Clear();
                Console.WriteLine("Sus tareas completadas son");
                foreach (var tarea in Tareas)
                {
                    if (tarea.Value)
                    {
                        Console.WriteLine(tarea.Key);
                    }

                }
            }
            public void MostrarTareasPendientes()
            {
                Console.Clear();
                Console.WriteLine("Sus tareas pendientes son");
                foreach (var tarea in Tareas)
                {
                    if (!tarea.Value)
                    {
                        Console.WriteLine(tarea.Key);
                    }

                }
            }

        }


    }
}
