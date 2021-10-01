using System;

namespace task_3
{
    class Program
    {
        static double F4twoElem(double[] arrOfX, double[] arrOfY, double xk_1, double xk)
        {
            double fk_1 = 0, fk = 0;
            for (int i = 0; i < arrOfX.Length; i++)
            {
                if (arrOfX[i] == xk_1)
                {
                    fk_1 = arrOfY[i];
                }

                if (arrOfX[i] == xk)
                {
                    fk = arrOfY[i];
                }
            }
            return (fk - fk_1) / (xk - xk_1);
        }

        static double F4threeElem(double[] arrOfX, double[] arrOfY, int n)
        {
            if (n == 3)
            {
                return (F4twoElem(arrOfX, arrOfY, arrOfX[1], arrOfX[2])
                        - F4twoElem(arrOfX, arrOfY, arrOfX[0], arrOfX[1]))
                        / (arrOfX[n - 1] - arrOfX[0]);
            }
            else
                return (F4threeElem(arrOfX, arrOfY, n - 1)
                       - F4threeElem(arrOfX, arrOfY, n - 1))
                       / (arrOfX[n - 1] - arrOfX[0]);
        }

        static double N(double[] arrOfX, double[] arrOfY, int n, double x)
        {
            double res = arrOfY[0]; if (n == 1) return res;
            if (n >= 2)
            {
                res += F4twoElem(arrOfX, arrOfY, arrOfX[0], arrOfX[1])
                    * (x - arrOfX[0]);
                if (n == 2) return res;
            }

            if (n > 2)
            {
                double temp = (x - arrOfX[0]);
                for (int i = 3; i < n + 1; i++)
                {
                    temp *= (x - arrOfX[i - 2]);
                    res += F4threeElem(arrOfX, arrOfY, i) * temp;
                }
            }
            return res;
        }

        static void Main(string[] args)
        {
            Console.Write("n = ");
            int n; n = Convert.ToInt32(Console.ReadLine());

            double[] arrayOfX = new double[n];

            //x0 x1 x2
            for (int i = 0; i < n; i++)
            {
                Console.Write("x [ " + i + "] = ");
                arrayOfX[i] = Convert.ToDouble(Console.ReadLine());
            }

            double[] arrayOfF = new double[n];

            //f0 f1 f2
            for (int i = 0; i < n; i++)
            {
                Console.Write("f [ " + arrayOfX[i] + "] = ");
                arrayOfF[i] = Convert.ToDouble(Console.ReadLine());
            }

            double counter = arrayOfX[0];
            for (int i = 0; i < n + (n - 1); i++)
            {
                Console.Write(N(arrayOfX, arrayOfF, n, counter) + " ");
                counter += 0.5;
            }

            Console.WriteLine();
            if (n >= 1)
            {
                Console.Write("f[x0] = " + arrayOfF[0] + " ");
                if (n >= 2)
                {
                    Console.Write("f[x0,x1] = " + F4twoElem(arrayOfX, arrayOfF, 0, 1) + " ");

                    if (n >= 3)
                    {

                        for (int i = 3; i < n + 1; i++)
                        {
                            Console.Write("f[x0,x1,x2]= " + F4threeElem(arrayOfX, arrayOfF, n) + " ");
                        }
                    }
                }
            }
        }
    }
}
