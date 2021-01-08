using System;

namespace Matrices
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            //Matriz A
            //1 5 
            //2 3
            //7 4 (3 x 2)


            //Matriz B
            //6 7 8 9
            //1 4 3 7 (2 x 4)

            //matriz C
            //1 x 6 + 5 x 1 = 11   1 x 7 + 5 x 4 = 27    1 x 8 + 5 x 3 = 23    1 x 9 + 5 x 7 = 44   
            //2 x 6 + 3 x 1 = 15   2 x 7 + 3 x 4 = 26    2 x 8 + 3 x 3 = 25    2 x 9 + 3 x 7 = 39
            //7 x 6 + 4 x 1 = 46   7 x 7 + 4 x 4 = 65    7 x 8 + 4 x 3 = 68    7 x 9 + 4 x 7 = 91


            //hacer algoritmo con prueba y la prueba que empuje a realizar el algoritmo...F
            //para el monday
            //metodo que permita hacer una matriz aleatoria
            //reciba 2 matrices.. calculadora de matrcies....


            //Matriz C = Matriz A X Matriz B  //Si hay como calcular :V

            //Matriz D = Matriz B X Matriz A //No hay como calcular xD

            //pseudocodigo
            var  matrizA = CrearMatriz(10, 8);
            var matrizB =  CrearMatriz(8, 50);
            var calculadora = new Calculadora();
            var matrizC = calculadora.Multiplicar(matrizA, matrizB);


            
          
        }
    }
}
