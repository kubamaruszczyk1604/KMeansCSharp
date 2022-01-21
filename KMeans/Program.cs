using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KMeans
{
    class Program
    {

        static List<DataVec> ReadTestData()
        {
            string path = "dataset1.csv";

            List<DataVec> pts = new List<DataVec>();
            using (System.IO.StreamReader reader = new System.IO.StreamReader(path))
            {
                int index = 0;
                while(!reader.EndOfStream)
                {
                    index++;
                    string rd = reader.ReadLine();
                    string[] el = rd.Split(',');
                    if (el.Length != 2) continue;
                    el[0] = el[0].Trim();
                    el[1] = el[1].Trim();
                    double x = double.Parse(el[0]);
                    double y = double.Parse(el[1]);
                    pts.Add(new DataVec(new double[] { x, y }));
                }
            }
            return pts;
        }
        static void Main(string[] args)
        {
            
            List<DataVec> points = ReadTestData();
                // new List<IDataPoint>();
            //Random rnd = new Random();
            //for (int i = 0; i < 50; ++i)
            //{
            //    //points.Add(new IDataPoint(new double[] { rnd.NextDouble() * rnd.Next(0, 20), rnd.NextDouble() * rnd.Next(0, 20) }));
            //    points.Add(new IDataPoint(new double[] { i,  i }));
            //}

            //foreach (var point in points)
            //{
            //    point.Print();
            //}
            //Console.WriteLine();

            KMeansClustering cl = new KMeansClustering(points.ToArray(), 15);
            cl.PrintCentroids();
            Cluster[] clusters =  cl.Calculate();
            Console.WriteLine(clusters.Length);
            cl.PrintCentroids();
            clusters[2].SaveAsCSV("C:/users/kuba/desktop/cluster0.csv");
            Console.ReadLine();
        }
    }
}
