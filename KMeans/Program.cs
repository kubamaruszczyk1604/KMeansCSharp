using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KMeans
{
    class Program
    {
        static void Main(string[] args)
        {

            List<IDataPoint> points = new List<IDataPoint>();
            Random rnd = new Random();
            for(int i =0; i < 20; ++i)
            {
                points.Add(new IDataPoint(new double[] {rnd.NextDouble()*rnd.Next(0,20), rnd.NextDouble()*rnd.Next(0, 20) }));
            }

            foreach(var point in points)
            {
                point.Print();
            }
            Console.WriteLine();

            KMeansClustering cl = new KMeansClustering(points.ToArray(), 5);
            cl.PrintCentroids();
            Console.ReadLine();
        }
    }
}
