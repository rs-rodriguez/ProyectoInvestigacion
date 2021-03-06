﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoInvestigacion
{
    class Program
    {

        static void Main(string[] args)
        {
            //inicializar clase crudMethod

            crudMethods methods = new crudMethods();

            //Definimos y creamos vectores
            String[] rut = new String[10];
            float[,] sueldos = new float[10, 1];

            int opt = 0; //Variable para las opciones de menu
            Boolean flagInsert = false; //Variable que nos confirma la insercion de empleados para validacion en metodos posteriores.
            String msj = "Presionar cualquier tecla para continuar"; //Mensaje global para reutilizacion

            while (true)
            {
                Console.WriteLine("      ARCO IRIS. S.A de C.V. \n Bienvenid@, Ingrese el número de la acción que desee realizar.");
                Console.WriteLine("1. AGREGAR \n" +
                    "2. MODIFICAR \n" +
                    "3. ELIMINAR \n" +
                    "4. BUSCAR \n" +
                    "5. VER LISTADO DE BENEFICIADOS");
                opt = int.Parse(Console.ReadLine());
                Console.Clear();

                switch (opt)
                {
                    case 1:
                        methods.Insertar(rut,sueldos,msj);
                        flagInsert = true;
                        break;
                    case 2:
                        if (flagInsert)
                        {
                            methods.Modificar(rut, sueldos);
                            break;
                        }
                        else
                        {
                            Console.WriteLine("No se han encontrado registros por el momento..... ");
                            Console.WriteLine(msj);
                            break;
                        }

                    case 3:
                        if (flagInsert)
                        {
                            Eliminar();
                            break;
                        }
                        else
                        {
                            Console.WriteLine("No se han encontrado registros por el momento..... ");
                            Console.WriteLine(msj);
                            break;
                        }
                    case 4:
                        if (flagInsert)
                        {
                            methods.buscarEmpleado(rut, sueldos, msj);
                            break;
                        }
                        else
                        {
                            Console.WriteLine("No se han encontrado registros por el momento..... ");
                            Console.WriteLine(msj);
                            break;
                        }
                    case 5:
                        if (flagInsert)
                        {
                            methods.obtenerBeneficiados(rut, sueldos);
                            break;
                        }
                        else
                        {
                            Console.WriteLine("No se han encontrado registros por el momento..... ");
                            Console.WriteLine(msj);
                            break;
                        }

                    default:
                        Console.WriteLine("OPCIÓN NO VALIDA");
                        Console.WriteLine(msj);
                        break;
                }
                Console.ReadKey();
                Console.Clear();



                //FUNCION ELIMINAR
                void Eliminar()
                {
                    String[] rutCopy = rut;
                    float[,] sueldosCopy = sueldos;

                    rut = null;
                    rut = new String[rutCopy.Length - 1];
                    sueldos = null;
                    sueldos = new float[sueldosCopy.Length - 1, 1];


                    String Emp = "";
                    //Busqueda de empleado
                    Console.WriteLine("Ingrese el RUT del empleado a eliminar:");
                    Emp = Console.ReadLine();

                    for (int i = 0; i < rut.Length; i++)
                    {
                        for (int rt = 0; rt < rutCopy.Length; rt++)
                        {
                            if (!rutCopy[rt].Equals(Emp) && !rut.Contains(rutCopy[rt]))
                            {
                                rut[i] = rutCopy[rt];
                                break;
                            }
                        }
                    }

                    for (int i = 0; i < rut.Length; i++)
                    {
                        for (int rt = 0; rt < rutCopy.Length; rt++)
                        {
                            if (rutCopy[rt].Equals(rut[i]))
                            {
                                for (int c = 0; c < sueldos.GetLength(1); c++)
                                {
                                    for (int sc = 0; sc < sueldosCopy.GetLength(1); sc++)
                                    {
                                        sueldos[i, c] = sueldosCopy[rt, sc];
                                    }
                                }
                                break;
                            }
                        }
                    }

                    Console.WriteLine(msj);
                }
            }
        }
    }
}
