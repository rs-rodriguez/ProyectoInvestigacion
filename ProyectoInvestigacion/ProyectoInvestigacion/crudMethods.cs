using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoInvestigacion
{
    class crudMethods
    {

        //FUNCION INSERTAR EMPLEADOS
        public void Insertar(String[] rut, float[,] sueldos, String msj)
        {
            Console.Clear();
            //Inserción de datos
            Console.WriteLine("INGRESE LOS DATOS CORRESPONDIENTES DEL EMPLEADO:");
            for (int i = 0; i < rut.Length; i++)
            {
                Console.WriteLine("RUT Empleado:");
                rut[i] = Console.ReadLine();

                for (int c = 0; c < sueldos.GetLength(1); c++)
                {
                    Console.WriteLine("SUELDO Empleado:");
                    sueldos[i, c] = float.Parse(Console.ReadLine());
                    Console.Clear();
                }
            }
            //MUESTRA DE EMPLEADOS INGRESADOS
            for (int i = 0; i < rut.Length; i++)
            {
                Console.WriteLine("# RUT: " + rut[i] + " - Sueldo: $" + getSueldo(i,sueldos));
            }
            Console.WriteLine(msj);
        }


        //FUNCION MODIFICAR
        public void Modificar(String[] rut, float[,] sueldos)
        {
            String bEmp = "";
            float nSueldo;
            //Busqueda de empleado
            Console.WriteLine("Ingrese el RUT del empleado a modificar: ");
            bEmp = Console.ReadLine();
            for (int i = 0; i < rut.Length; i++)
            {
                if (rut[i].Equals(bEmp))
                {
                    Console.WriteLine("Ingrese el nuevo RUT de: " + bEmp);
                    bEmp = Console.ReadLine();
                    rut[i] = bEmp;

                    for (int c = 0; c < sueldos.GetLength(1); c++)
                    {
                        Console.WriteLine("Sueldo actual del empleado(" + sueldos[i, c] + ")\n Ingrese el nuevo sueldo: ");
                        nSueldo = float.Parse(Console.ReadLine());
                        sueldos[i, c] = 0;
                        sueldos[i, c] = nSueldo;
                    }
                    Console.WriteLine("Modificado! \n \n \n Enter para regresar al menú principal. " + bEmp);
                }
            }
        }

        public double getSueldo(int numero, float[,] sueldos)
        {
            double sueldo = 0;
            for (int c = 0; c < sueldos.GetLength(1); c++)
            {
                sueldo = sueldos[numero, c];
            }
            return sueldo;
        }

        //FUNCION ELIMINAR
        public void Eliminar(String[] rut, float[,] sueldos)
        {
            String Emp = "";
            //Busqueda de empleado
            Console.WriteLine("Ingrese el RUT del empleado a eliminar:");
            Emp = Console.ReadLine();
            for (int i = 0; i < rut.Length; i++)
            {
                if (rut[i].Equals(Emp))
                {
                    rut[i].Remove(i);
                }


            }
        }

        //FUNCION PARA OBTENER LOS 10 BENEFICIARIOS
        public void obtenerBeneficiados(String[] rut, float[,] sueldos)
        {
            //Variables contenedoras de 10 beneficiarios.
            String[] benefRUT = new string[3];
            double[] benefSueldos = new double[3];

            double bono = 0;
            double bonosTotal = 0;
            double sueldoTotal = 0;

            //Ordenamos de menor a mayor los sueldos
           
            Console.WriteLine("LISTADO DE EMPLEADOS BENEFICIADOS ");


            for (int i = 0; i < 10; i++)
            {
                //Asignamos los primeros 10, luego de reordenar el vector.
                /* benefRUT[i] = rut[i];
                 benefSueldos[i] = sueldos[i];*/

                //Calculamos el sueldo con sus bonos respectivos.

                for (int c = 0; c < sueldos.GetLength(1); c++)
                {
                    bono = sueldos[i, c] * 0.05;
                    sueldoTotal = sueldos[i, c] + bono;
                    bonosTotal = bonosTotal + bono;
                    //Imprimimos los beneficiarios.
                    Console.WriteLine("---------------------------------------------------------------------------------------");
                    Console.WriteLine("Empleado: " + rut[i] + "  |  Sueldo: $" + sueldos[i, c] + "  | Bono a recibir: $" + bono + "  | Sueldo a recibir: $" + sueldoTotal);
                }
            }
            Console.WriteLine("\n |||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||");
            Console.WriteLine("COSTO TOTAL DE BONIFICACIONES: $" + bonosTotal);

        }

        //FUNCION BUSCAR EMPLEADOS
        public void buscarEmpleado(String[] rut, float[,] sueldos, String msj)
        {
            Console.WriteLine("BUSQUEDA");
            Console.WriteLine("Ingrese el RUT del empleado a buscar:");
            String encontrar = Console.ReadLine();
            float sueldo = 0;

            //Verificacion de busqueda de empleado por RUT
            for (int i = 0; i < rut.Length; i++)
            {
                if (rut[i].Equals(encontrar))
                {
                    encontrar = rut[i];
                    sueldo = sueldos[i,i];
                }
            }
            Console.WriteLine("Encontrado: " + encontrar + "\nSueldo: $" + sueldo);
            Console.WriteLine(msj);
        }
    }
}
