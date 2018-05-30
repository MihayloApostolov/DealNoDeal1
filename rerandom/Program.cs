using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rerandom
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] BoxValues = new double[22] { 0.10, 0.20, 0.50, 1, 5, 10, 20, 50, 100, 200,
                   300, 750, 1000, 2500, 5000, 7500, 10000, 12500, 15000, 2500, 50000, 100000 };
            int[] boxIndex = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21 };

            double[] rAray = new double[22];

            foreach(int i in boxIndex)
            {
                var rnd = new Random(DateTime.Now.Millisecond);

                int index = rnd.Next(0,22);
                rAray[i] = BoxValues[index];
                Console.WriteLine(rAray[i]);
            }

            
            Console.ReadLine();
        }
    }
}
