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
        public List<IDataPoint> Points { get; set; }

        private IDataPoint m_LastCentroid;


        public Cluster(int dimensions)
        {
            Centroid = new IDataPoint(dimensions);
            Points = new List<IDataPoint>();
        }

        public void ClearData()
        {
            Points.Clear();
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
            m_LastCentroid = Centroid;
            
        }
        /// <summary>
        /// retrun dist updated
        /// </summary>
        /// <returns></returns>
        public double RecalculateCentroid()
        {
            
            if(Points.Count == 0)
            {
                return 0;
            }
            double[] mean = new double[Centroid.Elements.Length];
            for(int i = 0; i < mean.Length; ++i)
            {
                for(int pI = 0; pI < Points.Count; ++pI)
                {
                    mean[i] += Points[pI].Elements[i];
                }
                mean[i] /= Points.Count;

            }
            Centroid = new IDataPoint(mean);
            return Centroid.GetDistance(m_LastCentroid);
        }
    }
}
