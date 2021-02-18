using System;

namespace Montante
{
    class Program
    {
        static void ImprimirMatrizLlenado(double[ , ] matriz, double[] resultado, int n, int x, int y)
        {
            for (int i = 0; i < n + 1; i++)
            {
                if (i == n)
                {
                    Console.WriteLine("Resultado");
                }
                else
                {
                    Console.Write("x" + (i + 1) + "\t");
                }
            }
            for (int j = 0; j < n; j++)
            {
                for (int i = 0; i < n; i++)
                {
                    if(i == x && j == y)
                    {
                        Console.Write("{"+matriz[i, j]+"}" + "\t");
                    }
                    else
                    Console.Write(matriz[i, j] + "\t");
                }
                if(x == -1 && j == y)
                {
                    Console.WriteLine("{"+resultado[j]+"}");
                }
                else
                Console.WriteLine(resultado[j]);
            }
        }

        static void ImprimirMatriz(double[,] matriz, double[] resultado, int n)
        {
            for (int i = 0; i < n + 1; i++)
            {
                if (i == n)
                {
                    Console.WriteLine("Resultado");
                }
                else
                {
                    Console.Write("x" + (i + 1) + "\t");
                }
            }
            for (int j = 0; j < n; j++)
            {
                for (int i = 0; i < n; i++)
                {
                    Console.Write(matriz[i, j] + "\t");
                }
                Console.WriteLine(resultado[j]);
            }
        }

        static void ImprimirAumentada(double[,] matriz, double[,] identidad, int n)
        {
            for (int i = 0; i < n * 2 + 1; i++)
            {
                if (i < n)
                {
                    Console.Write("x" + (i + 1) + "\t");
                }
                else if (i == n)
                {
                    Console.Write("|\t");
                }
                else
                {
                    Console.Write("i" + (i - 3) + "\t");
                }
            }
            Console.Write("\n");
            for (int j = 0; j < n; j++)
            {
                for (int i = 0; i < n * 2 + 1; i++)
                {
                    if (i < n)
                    {
                        Console.Write(matriz[i, j] + "\t");
                    }
                    else if (i == n)
                    {
                        Console.Write("|\t");
                    }
                    else
                    {
                        Console.Write(identidad[i-4, j] + "\t");
                    }
                }
                Console.Write("\n");
            }
        }

        /*static void ImprimirAumentada(double[,] matriz, double[,] identidad, int n)
        {
            int b=-1;
            for (int i = 0; i < n*2; i++)
            {
                if(i >= n && b == 1)
                {
                    Console.Write("i" + (i - 2) + "\t");
                }
                else if(i == n)
                {
                    Console.Write("|\t");
                    i = n;
                    b = 1;
                }
                else
                {
                    Console.Write("x" + (i + 1) + "\t");
                    b = 0;
                }
            }
            Console.Write("\n");
            for (int j = 0; j < n; j++)
            {
                for (int i = 0; i < n*2; i++)
                {
                    if(i >= n && b==1)
                    {
                        Console.Write(identidad[i-3, j] + "\t");
                    }
                    if(i == n)
                    {
                        Console.Write("|\t");
                        i = n;
                        b = 1;
                    }
                    else
                    {
                        Console.Write(matriz[i, j] + "\t");
                        b = 0;
                    }
                }
                Console.Write("\n");
            }
        }*/

        static void LlenarMatriz(double[,] matriz, double[] resultado, int n)
        {
            for(int j = 0; j < n; j++)
            {
                for (int i = 0; i < n; i++)
                {
                    ImprimirMatrizLlenado(matriz, resultado, n, i, j);
                    matriz[i, j] = Convert.ToDouble(Console.ReadLine());
                    Console.Clear();
                }
                ImprimirMatrizLlenado(matriz, resultado, n, -1, j);
                resultado[j] = Convert.ToInt32(Console.ReadLine());
                Console.Clear();
            }    
        }

        static void DeclararIdentidad(double[,] identidad, int n)
        {
            for(int i = 0; i < n; i++)
            {
                identidad[i, i] = 1;
            }
        }

        static void HacerMontante(double[, ] matriz, double[, ] identidad, double[] resultado, int n)
        {
            int j, k, l;
            double antPivote = 1;
            double actPivote;
            for(int i = 0; i < n; i++) //pivoteo
            {
                actPivote = matriz[i, i];
                for(l = i; l >= 0; l--)
                {
                    matriz[l, l] = actPivote;
                }
                for(j = i+1; j < n; j++)
                {
                    for(k = i+1; k < 2*n; k++)
                    {
                        if(k < n)
                        {
                            matriz[k, j] = (matriz[i, i] * matriz[k, j] - matriz[i, j] * matriz[k, i]) / antPivote;
                        }
                        else
                        {
                            identidad[k - 3, j] = (matriz[i, i] * identidad[k - 3, j] - matriz[i, j] * identidad[k - 3, i]) / antPivote;
                        }
                        
                    }
                    matriz[i, j] = 0;
                }
                for (j = i - 1; j >= 0; j--)
                {
                    for (k = i + 1; k < 2*n; k++)
                    {
                        if (k < n)
                        {
                            matriz[k, j] = (matriz[i, i] * matriz[k, j] - matriz[i, j] * matriz[k, i]) / antPivote;
                        }
                        else
                        {
                            identidad[k - 3, j] = (matriz[i, i] * identidad[k - 3, j] - matriz[i, j] * identidad[k - 3, i]) / antPivote;
                        }
                    }
                    matriz[i, j] = 0;
                }
                ImprimirAumentada(matriz, identidad, n);
                Console.WriteLine("");
                Console.ReadKey();
                antPivote = actPivote;
                
            }
            

        }

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World");
            Console.Write("De que tamaño sera la matriz: ");
            int n = Convert.ToInt32(Console.ReadLine());
            double[,] matriz = new double[n, n];
            double[] resultado = new double[n];
            double[,] matriz2 = new double[n, n];
            double[,] identidad = new double[n, n];
            matriz2 = matriz;

            LlenarMatriz(matriz, resultado, n);
            DeclararIdentidad(identidad, n);
            HacerMontante(matriz, identidad, resultado, n);
            
        }

    }
}
