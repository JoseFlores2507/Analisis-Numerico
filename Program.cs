using System;

namespace Montante
{
    class Program
    {
        static void ImprimirCambio(double[,] matriz, double[] resultado, byte n)
        {
            for (int i = 0; i < n + 3; i++)
            {
                if (i == 0)
                {
                    Console.Write("\t");
                }
                else if (i == n + 2)
                {
                    Console.WriteLine("[" + (i - 1) + "a]");
                }
                else if (i == n + 1)
                {
                    Console.Write("\t");
                }
                else
                    Console.Write("["+ i + "a]\t");
            }
            for(int j = 0; j < n; j++)
            {
                for(int i = 0; i < n + 2; i++)
                {
                    if (i == 0)
                    {
                        Console.Write("["+(j + 1) + "b]\t");
                    }
                    else if (i == n + 1)
                    {
                        Console.Write("=\t");
                    }
                    else
                        Console.Write(matriz[i-1, j] + "\t");
                }
                Console.WriteLine(resultado[j]);
            }

        }

        static void ImprimirMatrizLlenado(double[ , ] matriz, double[] resultado, byte n, int x, int y)
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

        static void ImprimirResultado(double[,] matriz, double[] resultado, byte n)
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

        static void ImprimirMatriz(double[,] matriz, byte n, int b)
        {
            if (b == 1)//inversa
            {
                Console.WriteLine("Inversa:");
                for(int i = 0; i < n; i++)
                {
                    Console.Write("i" + (i + 1) + "\t");
                }
                Console.WriteLine("");
                for (int j = 0; j < n; j++)
                {
                    for (int i = 0; i < n; i++)
                    {
                        Console.Write(String.Format("{0,-7:0.####}", matriz[i, j]) + "\t");
                    }
                    Console.WriteLine("");
                }
            }
            else
            {
                for (int i = 0; i < n; i++)
                {
                    Console.Write("x" + (i + 1) + "\t");
                }
                Console.WriteLine("");
                for (int j = 0; j < n; j++)
                {
                    for (int i = 0; i < n; i++)
                    {
                        Console.Write(String.Format("{0,-7:0.####}", matriz[i, j]) + "\t");
                    }
                    Console.WriteLine("");
                }
            }
            Console.ReadKey();
        }

        static void ImprimirAumentada(double[,] matriz, double[,] identidad, byte n)
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
                    Console.Write("i" + (i - n) + "\t");
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
                        Console.Write(identidad[i-(n+1), j] + "\t");
                    }
                }
                Console.Write("\n");
            }
        }

        static void LlenarMatriz(double[,] matriz, double[] resultado, byte n)
        {
            for(int j = 0; j < n; j++)
            {
                for (int i = 0; i < n; i++)
                {
                    ImprimirMatrizLlenado(matriz, resultado, n, i, j);
                    matriz[i, j] = ReadDouble();
                    Console.Clear();
                }
                ImprimirMatrizLlenado(matriz, resultado, n, -1, j);
                resultado[j] = ReadDouble();
                Console.Clear();
            }    
        }

        static void DeclararIdentidad(double[,] identidad, byte n)
        {
            for (int i = 0; i < n; i++)
            {
                for(int j = 0;j<n; j++)
                {
                    identidad[i, j] = 0;
                }
            }
            for (int i = 0; i < n; i++)
            {
                identidad[i, i] = 1;
            }
        }

        static void HacerMontante(double[, ] matriz, double[, ] identidad, byte n)
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
                            identidad[k - n, j] = (matriz[i, i] * identidad[k - n, j] - matriz[i, j] * identidad[k - n, i]) / antPivote;
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
                            identidad[k - n, j] = (matriz[i, i] * identidad[k - n, j] - matriz[i, j] * identidad[k - n, i]) / antPivote;
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

        static void ValidarMontante(double[,] matriz, double[,] identidad, byte n)
        {
            int j, k, l;
            double antPivote = 1;
            double actPivote;
            for (int i = 0; i < n; i++) //pivoteo
            {
                actPivote = matriz[i, i];
                for (l = i; l >= 0; l--)
                {
                    matriz[l, l] = actPivote;
                }
                for (j = i + 1; j < n; j++)
                {
                    for (k = i + 1; k < 2 * n; k++)
                    {
                        if (k < n)
                        {
                            matriz[k, j] = (matriz[i, i] * matriz[k, j] - matriz[i, j] * matriz[k, i]) / antPivote;
                        }
                        else
                        {
                            identidad[k - n, j] = (matriz[i, i] * identidad[k - n, j] - matriz[i, j] * identidad[k - n, i]) / antPivote;
                        }

                    }
                    matriz[i, j] = 0;
                }
                for (j = i - 1; j >= 0; j--)
                {
                    for (k = i + 1; k < 2 * n; k++)
                    {
                        if (k < n)
                        {
                            matriz[k, j] = (matriz[i, i] * matriz[k, j] - matriz[i, j] * matriz[k, i]) / antPivote;
                        }
                        else
                        {
                            identidad[k - n, j] = (matriz[i, i] * identidad[k - n, j] - matriz[i, j] * identidad[k - n, i]) / antPivote;
                        }
                    }
                    matriz[i, j] = 0;
                }
                antPivote = actPivote;
            }
        }
        static void Determinante(double[,] matriz, double[,] identidad, byte n)
        {
            for(int j = 0; j < n; j++)
            {
                for(int i = 0; i < n; i++)
                {
                    identidad[i, j] = identidad[i, j]/matriz[n-1, n-1];
                }
            }
        }

        static void ValorIncognitas(double[,] inversa, double[] resultado, byte n, double[] incognitas)
        {
            for(int i = 0; i < n; i++)
            {
                incognitas[i] = 0;
                for (int j = 0; j < n; j++)
                {
                    incognitas[i] = incognitas[i] + resultado[j] * inversa[j, i];
                }
            }
        }

        static void ImprimirIncognitas(double[] incognitas, byte n)
        {
            Console.Clear();
            for(int i = 0; i< n; i++)
            {
                Console.WriteLine("x" + (i + 1) + "\t=\t" + String.Format("{0,-7:0.####}", incognitas[i]));
            }
        }

        static void HacerCambios(double[,] matriz, double[] resultado, byte n)
        {
            char c;
            byte x, y;
            ImprimirResultado(matriz, resultado, n);
            Console.WriteLine("Quieres Cambiar Algun Elemento? (y = si): ");
            c = Console.ReadKey().KeyChar;
            Console.Clear();
            while (c == 'y')
            {
                ImprimirCambio(matriz, resultado, n);
                Console.WriteLine("Ingresa la posición a: ");
                x = ReadByte();
                while ((x > n + 1 || x == 0))
                {
                    Console.WriteLine("Ingresa la posición a: ");
                    x = ReadByte();
                }
                Console.WriteLine("Ingresa la posición b: ");
                y = ReadByte();
                while (y > n || x == 0)
                {
                    Console.WriteLine("Ingresa la posición b: ");
                    y = ReadByte();
                }
                CambiarElemento(matriz, resultado, n, (x - 1), (y - 1));
                ImprimirResultado(matriz, resultado, n);
                Console.WriteLine("Quieres Cambiar Algun Elemento? (y = si): ");
                c = Console.ReadKey().KeyChar;
                Console.Clear();
            }
            //ImprimirCambio(matriz, resultado, n);
        }

        static void CambiarElemento(double[,] matriz, double[] resultado, byte n, int i, int j)
        {
            Console.WriteLine("Ingresa el Nuevo Valor: ");
            if (i < n)
            {
                matriz[i, j] = ReadDouble();
            }
            else
                resultado[j] = ReadDouble();
        }

        static void Main(string[] args)
        {
            Montante();

        }

        private static void Montante()
        {
            Console.WriteLine("De que tamaño sera la matriz: ");
            byte n = ReadByte();
            double[,] matriz = new double[n, n]; //se convierte en determinante
            double[,] aux = new double[n, n]; //copia auxiliar
            double[] resultado = new double[n];
            double[] incognitas = new double[n];
            double[,] identidad = new double[n, n]; //se convierte en inversa
            LlenarMatriz(matriz, resultado, n);
            DeclararIdentidad(identidad, n);
            HacerCambios(matriz, resultado, n);
            aux = (double[,])matriz.Clone();
            ValidarMontante(aux, identidad, n);
            Determinante(aux, identidad, n);
            ValorIncognitas(identidad, resultado, n, incognitas);
            if (ValidarIncognitas(incognitas, n))
            {
                DeclararIdentidad(identidad, n);
                HacerMontante(matriz, identidad, n);
                Determinante(matriz, identidad, n);
                ImprimirMatriz(identidad, n, 1); //inversa
                ValorIncognitas(identidad, resultado, n, incognitas);
                ImprimirIncognitas(incognitas, n);
            }
            else
            {
                Console.WriteLine("La matriz no se puede resolver usando el metodo de montante.");
            }
        }

        private static bool ValidarIncognitas(double[] incognitas, byte n)
        {
            for(int i = 0; i<n; i++)
            {
                if (double.IsNaN(incognitas[i]))
                {
                    return false;
                }
                else
                {
                    return true;
                } 
            }
            return true;
        }

        static byte ReadByte()
        {
            string num;
            byte valido;
            num = Console.ReadLine();
            if (!byte.TryParse(num, out valido)
                || string.IsNullOrEmpty(num))
            {
                ClearLine(1);
            }
            while (!byte.TryParse(num, out valido)
                || string.IsNullOrEmpty(num))
            {
                num = Console.ReadLine();
                ClearLine(1);
            }
            return valido;

        }

        static double ReadDouble()
        {
            string num;
            double valido;
            num = Console.ReadLine();
            if (!double.TryParse(num, out valido)
                || string.IsNullOrEmpty(num))
            {
                ClearLine(1);
            }
                while (!double.TryParse(num, out valido)
                || string.IsNullOrEmpty(num))
            {
                num = Console.ReadLine();
                ClearLine(1);
            }
            return valido;

        }

        static void ClearLine(int n)
        {
            for(int i = 0; i < n + 1; i++)
            {
                Console.SetCursorPosition(0, Console.CursorTop);
                Console.Write(new string(' ', Console.WindowWidth));
                Console.SetCursorPosition(0, Console.CursorTop - 1);
            }
            Console.WriteLine("");
        }
    }
}
