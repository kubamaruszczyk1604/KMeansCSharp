using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KMeans
{
    public class Cluster
    {

        static List<int> s_OccupuedPositions = new List<int>();
        public IDataPoint Centroid { get; set; }
        public List<IDataPoint> Data { get; set; }


        public Cluster(int dimensions)
        {
            Centroid = new IDataPoint(dimensions);
        }

        public void ClearData()
        {
            Data.Clear();
        }

        public void RandomCentroidPlacement(IDataPoint [] data)
        {
            int index = 0;
            int cnt = 0;
            Random rnd = new Random();
            do
            {
                cnt++;
                if(cnt > 100)
                {
                    throw new Exception("Cannot do centroid placement.");
                }

                index = rnd.Next(data.Length);

            } while (s_OccupuedPositions.Contains(index));

            Centroid = IDataPoint.DeepCopy(data[index]);
            s_OccupuedPositions.Add(index);
            
        }

        public void RecalculateCentroid()
        {
            
            for(int i = 0; i < Data.Count; ++i)
            {
                
            }
            
        }
    }
}
