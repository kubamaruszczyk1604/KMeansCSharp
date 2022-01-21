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
        public DataVec Centroid { get; set; }
        public List<DataVec> Points { get; set; }

        private DataVec m_LastCentroid;


        public Cluster(int dimensions)
        {
            Centroid = new DataVec(dimensions);
            Points = new List<DataVec>();
        }

        public void ClearData()
        {
            Points.Clear();
        }

        public void RandomCentroidPlacement(DataVec [] data)
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

            Centroid = DataVec.DeepCopy(data[index]);
            s_OccupuedPositions.Add(index);
            m_LastCentroid = DataVec.DeepCopy(Centroid);

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
            m_LastCentroid = DataVec.DeepCopy(Centroid);
            Centroid = new DataVec(mean);
            return Centroid.GetDistance(m_LastCentroid);
        }


        public void SaveAsCSV(string path)
        {
            using (System.IO.StreamWriter writer = new System.IO.StreamWriter(path))
            {
                foreach(var point in Points)
                {
                    writer.WriteLine(point.ToString());
                }

                writer.Close();
            }
        }

    }
}
