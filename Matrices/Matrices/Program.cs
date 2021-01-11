using System;
using System.Threading;
using System.Diagnostics;
using System.Threading.Tasks;
using System.IO;
namespace Matrices
{
    class Program
    {
        static void Main(string[] args)
        {
            var sw = Stopwatch.StartNew();

            Program.ObtenerTamañoParalelo();
            Console.WriteLine(sw.ElapsedMilliseconds);
            sw.Stop();
            sw.Restart();
            Program.ObtenerTamaño();
            Console.WriteLine(sw.ElapsedMilliseconds);
            sw.Stop();

            return ;
            var opcion = 0;

            do
            {
                Console.Clear();
                Console.WriteLine("**************************");
                Console.WriteLine("*    Kevin Guachagmira   *");
                Console.WriteLine("*       08/01/2021       *");
                Console.WriteLine("*                        *");
                Console.WriteLine("*     MATRICES   EN C#   *");
                Console.WriteLine("*                        *");
                Console.WriteLine("**************************");
                Console.WriteLine("(1) Ejemplo de tarea");
                Console.WriteLine("(2) Crear Matrices aletorias y multiplicar");
                Console.WriteLine("(3) Salir");
                Console.WriteLine("Seleccione una opción del menú: ");
                opcion = int.Parse(Console.ReadLine());
                Console.Clear();
                switch (opcion)
                {
                    case 1:
                        Console.WriteLine("Ejemplo de tarea");
                        Program.CrearMatrizQuemada();
                        Console.WriteLine("Presiona una tecla para continuar");
                        Console.ReadLine();
                        break;
                    case 2:
                        Console.WriteLine("Crear Matrices aletorias y multiplcar");
                        Program.MatrizAleatoria();
                        Console.WriteLine("Presiona una tecla para continuar");
                        Console.ReadLine();
                        break;
                    case 3:
                        Console.WriteLine("Crear Matrices aletorias y multiplcar");
                        Program.MatrizAleatoria();
                        Console.WriteLine("Presiona una tecla para continuar");
                        Console.ReadLine();
                        break;
                    case 4:
                        Console.WriteLine("Muchas gracias por usar este programita");
                        Console.WriteLine("Presiona una tecla para continuar");
                        Console.ReadLine();
                        opcion = 4;
                        break;
                    default:
                        Console.WriteLine("La opción escogida no esta dentro del menú vuelve a digitarlo porfavor");
                        Console.WriteLine("Presiona una tecla para continuar");
                        Console.ReadLine();
                        break;
                }
            } while (opcion != 4);
        }
        public static void MatrizAleatoria()
        {
            int dimRowB;
            int dimColB;
            var aleatorio = new Random();
            Console.WriteLine("Ingrese el número de filas de la Matriz A");
            int dimRowA = int.Parse(Console.ReadLine());
            Console.WriteLine("Ingrese el número de columnas de la Matriz A");
            int dimColA = int.Parse(Console.ReadLine());
            do
            {
                Console.WriteLine("Ingrese el número de filas de la Matriz B");
                dimRowB = int.Parse(Console.ReadLine());
                Console.WriteLine("Ingrese el número de columnas de la MatrizA");
                dimColB = int.Parse(Console.ReadLine());

                if (dimRowB != dimColA)
                    Console.WriteLine("La dimensión de la fila de la Matriz B debe ser igual a la dimension de las columnas de la Matriz A para poder ser operable ");

            } while (dimRowB != dimColA);


            int[,] matrizA = new int[dimRowA, dimColA];
            int[,] matrizB = new int[dimRowB, dimColB];

            LlenarMatrizAleatoria(matrizA);
            LlenarMatrizAleatoria(matrizB);

            var sw = Stopwatch.StartNew();

            int[,] matrizC = MutiplicarMatrices(matrizA, matrizB);
            long tiempoTranscurrido = sw.ElapsedMilliseconds;
            Console.WriteLine("El tiempo transcurrido es :{0}",tiempoTranscurrido);
            var sw1 = Stopwatch.StartNew();
            int [,] matrizD = MutiplicarMatricesParalelo(matrizA, matrizB);
            long tiempo2 = sw1.ElapsedMilliseconds; 
            Console.WriteLine("El tiempo transcurrido es :{0}",tiempo2);

            sw.Stop();
            sw1.Stop();
            //MATRIZ DE ENTEROS NO DE DOBLES
            //MATRIZ ALEATORIA dado la dimesión
        }

        private static int[,] MutiplicarMatrices(int[,] matrizA, int[,] matrizB)
        {
            int dimRowA = matrizA.GetLength(0);
            int dimColA = matrizA.GetLength(1);
            int dimColB = matrizB.GetLength(1);

            int[,] matrizC = new int[dimRowA, dimColA];

            for (int i = 0; i < dimRowA; i++)
            {
                for (int j = 0; j < dimColB; j++)
                {
                    matrizC[i, j] = 0;
                    for (int k = 0; k < dimColA; k++)
                    {
                        matrizC[i, j] += matrizA[i, k] * matrizB[k, j];
                    }
                }
            }
            return matrizC;
        }

        private static void LlenarMatrizAleatoria(int[,] matrizA)
        {
            var aleatorio = new Random();
            int dimRowA = matrizA.GetLength(0);
            int dimColA = matrizA.GetLength(1);
            for (int i = 0; i < dimRowA; i++)
            {
                for (int j = 0; j < dimColA; j++)
                {
                    matrizA[i, j] = aleatorio.Next(0, 100);
                }
            }
        }

        public static void CrearMatrizQuemada()
        {
            int[,] matrizC = new int[3, 4];

            int[,] matrizB =
{
                {6,7,8,9},
                {1,4,3,7}
            };
            int[,] matrizA = {
                {1,5},
                {2,3},
                {7,4}
            };
             matrizC = MultiplicarMatricesQuemada(matrizA, matrizB);
        }
        public static int [,] MultiplicarMatricesQuemada(int [,] matrizA, int[,] matrizB)
        {
            /*
            MATRIZ A

            1 5
            2 3
            7 4 (3x2)

            MATRIZ B

             6 7 8 9
             1 4 3 7 (2x4)

            MATRIZ C = MATRIZ A X MATRIZ B
            MATRIZ D = MATRIZ B X MATRIZ A    

            MATRIZ C = (1*6+5*1  1*7+5*4  1*8+3*5   1*9+5*5)
                       (2*6+3*1  2*7+3*4  2*8+3*3   2*9+3*7)
                       (7*6+4*1  7*7+4*4  7*8+4*3   7*9+4*7)
            MATRIZ C = (11 27 23 44)
                       (15 26 25 39)
                       (46 65 68 91)*/



            int[,] matrizC = new int[3, 4];



            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    matrizC[i, j] = 0;
                    for (int k = 0; k < 2; k++)
                    {
                        matrizC[i, j] = matrizC[i, j] + (matrizA[i, k] * matrizB[k, j]);
                    }
                    Console.WriteLine(matrizC[i, j]);

                }
            }
            return matrizC;

        }
        private static int[,] MutiplicarMatricesParalelo(int[,] matrizA, int[,] matrizB)
        {
            int dimRowA = matrizA.GetLength(0);
            int dimColA = matrizA.GetLength(1);
            int dimColB = matrizB.GetLength(1);

            int[,] matrizC = new int[dimRowA, dimColA];
            Parallel.For(0,dimRowA, i=>{
                Parallel.For(0,dimColB, j=>{
                    matrizC[i, j] = 0;
                    for (int k = 0; k < dimColA; k++)
                    {
                        matrizC[i, j] += matrizA[i, k] * matrizB[k, j];
                    }
                });
            });
            return matrizC;
        }
        private static void ObtenerTamañoParalelo()
        {
            long totalSize = 0;
            string ruta = @"C:\Users\Kevin111\Documents";
            if (! Directory.Exists(ruta) ){
                Console.WriteLine("The directory does not exist.");
                return;
            }

            String[] files = Directory.GetFiles(ruta);
            Parallel.For(0, files.Length,
            index => 
            { FileInfo fi = new FileInfo(files[index]);
                long size = fi.Length;
                Interlocked.Add(ref totalSize, size);
            } );
            Console.WriteLine("Directory '{0}':", ruta);
            Console.WriteLine("{0:N0} files, {1:N0} bytes", files.Length, totalSize);
        }
        private static void ObtenerTamaño()
        {
            long totalSize = 0;
            string ruta = @"C:\Users\Kevin111\Documents";
            if (! Directory.Exists(ruta) ){
                Console.WriteLine("The directory does not exist.");
                return;
            }

            String[] files = Directory.GetFiles(ruta);
            for(int index=0; index<files.Length;index++)
            {
                FileInfo fi = new FileInfo(files[index]);
                long size = fi.Length;
                Interlocked.Add(ref totalSize, size);
            }
            Console.WriteLine("Directory '{0}':", ruta);
            Console.WriteLine("{0:N0} files, {1:N0} bytes", files.Length, totalSize);
        }
    }
}
