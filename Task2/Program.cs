using System;
using System.Collections.Generic;
using System.IO;

namespace Task2
{
    class Program
    {
        static double Fi(double x, double[] arrOfX, double f, double xi)
        {
            List<double> l = new List<double>();
            for (int i = 0; i < arrOfX.Length; i++)
            {
                l.Add(arrOfX[i]);
            }

            l.Remove(xi);

            double x1 = l[0];
            double x2 = l[1];

            if (x != xi)
            {
                return f * ((x - xi) * (x - x1) * (x - x2)) / ((xi - x1) * (xi - x2));
            }
            else return f * ((x - x1) * (x - x2)) / ((xi - x1) * (xi - x2));
        }

        static double Li(double x, double[] arrayOfX, double[] arrayOfF)
        {
            double sum = 0;

            for (int i = 0; i < arrayOfX.Length; i++)
            {
                sum += +Fi(x, arrayOfX, arrayOfF[i], arrayOfX[i]);
            }

            return sum;
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
                Console.Write(Li(counter, arrayOfX, arrayOfF) + " ");
                counter += 0.5;
            }
        }
    }
}
