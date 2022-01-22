using System;
using System.Collections.Generic;

namespace KMeans
{
    class Program
    {


        static void Main(string[] args)
        {
            
            List<DataVec> points = ReadTestData();

            KMeansClustering cl = new KMeansClustering(points.ToArray(), 15);
            Cluster[] clusters =  cl.Compute();

            Console.WriteLine("\n");
            Console.WriteLine("Number of clusters k = " + clusters.Length);
            cl.PrintClusters();

            Console.ReadLine();
        }


        
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
    }
}
