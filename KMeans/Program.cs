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
            for (int i = 0; i < 50; ++i)
            {
                //points.Add(new IDataPoint(new double[] { rnd.NextDouble() * rnd.Next(0, 20), rnd.NextDouble() * rnd.Next(0, 20) }));
                points.Add(new IDataPoint(new double[] { i,  i }));
            }

            //foreach (var point in points)
            //{
            //    point.Print();
            //}
            //Console.WriteLine();

            KMeansClustering cl = new KMeansClustering(points.ToArray(), 5);
            cl.PrintCentroids();
            Cluster[] clusters =  cl.Calculate();
            Console.WriteLine(clusters.Length);
            cl.PrintCentroids();
            clusters[2].SaveAsCSV("C:/users/kuba/desktop/cluster0.csv");
            Console.ReadLine();
        }
    }
}
