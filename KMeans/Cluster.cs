using System;
using System.Collections.Generic;

namespace KMeans
{
    /// <summary>
    /// This class represents data point cluster. 
    /// It contains centroid and a list of references to member data points.
    /// </summary>
    public class Cluster
    {

        static List<int> s_OccupuedCentroidPositions = new List<int>(); // This is to keep track of which centroid positions are 
                                                                        // already occupied during random placement

        /// <summary>
        /// Clear chaced centroid indices
        /// </summary>
        public static void ResetCache()
        {
            s_OccupuedCentroidPositions.Clear();
        }
        private DataVec m_LastCentroid;

        /// <summary>
        /// Centre point of a cluster
        /// </summary>
        public DataVec Centroid { get; set; }
        /// <summary>
        /// Members of this cluster
        /// </summary>
        public List<DataVec> Points { get; set; }


        public Cluster()
        {
            const int defaultN = 2;
            Centroid = new DataVec(defaultN);
            Points = new List<DataVec>();
        }

        /// <summary>
        /// Clears references to datapoints used for centroid recalculation
        /// </summary>
        public void ClearData()
        {
            Points.Clear();
        }

        /// <summary>
        /// Places centrid at the position of a point randomly selected from the data.  
        /// </summary>
        /// <param name="allData"></param>
        public void Initialize(DataVec [] allData)
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

                index = rnd.Next(allData.Length);

            } while (s_OccupuedCentroidPositions.Contains(index));

            Centroid = DataVec.DeepCopy(allData[index]);
            s_OccupuedCentroidPositions.Add(index);
            m_LastCentroid = DataVec.DeepCopy(Centroid);

        }

        /// <summary>
        /// Updates centroid position in respect to cluster data data points
        /// </summary>
        /// <returns></returns>
        public double RecalculateCentroid()
        {
            
            if(Points.Count == 0)
            {
                return 0;
            }
            double[] mean = new double[Centroid.Components.Length];
            for(int i = 0; i < mean.Length; ++i)
            {
                for(int pI = 0; pI < Points.Count; ++pI)
                {
                    mean[i] += Points[pI].Components[i];
                }
                mean[i] /= Points.Count;

            }
            m_LastCentroid = DataVec.DeepCopy(Centroid);
            Centroid = new DataVec(mean);
            return Centroid.GetDistance(m_LastCentroid);
        }

        /// <summary>
        /// Dave results as CSV file
        /// </summary>
        /// <param name="path"></param>
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
