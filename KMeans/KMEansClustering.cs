using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KMeans
{
    public enum KMSState { OK = 0, PointsArrayNull = 1, DataPointsArayEmpty = 2, MoreCategoriesThanPoints = 3,
                           NullEntryInDataPoints = 4,  DimensionMismatch = 5 }

    public class KMeansClustering
    {

        private readonly int MAX_ITERATIONS = 100;
        private int m_K;
        private DataVec [] p_DataPoints;
        private Cluster[] m_Clusters;

        public KMeansClustering(DataVec[] points, int k)
        {
            KMSState state = CheckData(points, k);
            if(state != KMSState.OK)
            {
                throw new Exception("Data check failed. Reason: " + state.ToString());
            }
            Cluster.ResetCache();

            m_K = k;
            p_DataPoints = points;
            m_Clusters = new Cluster[m_K];
            int dimensions = points[0].Elements.Length;
            for(int i = 0; i < m_K; ++i)
            {
                m_Clusters[i] = new Cluster();
                m_Clusters[i].Initialize(points);
            }

        }

        public Cluster[] Calculate()
        {
            int iterations = 0;
            while(iterations < MAX_ITERATIONS)
            {
                iterations++;
                //clear points in clusters
                for (int iCluster = 0; iCluster < m_Clusters.Length; ++iCluster)
                {
                    m_Clusters[iCluster].ClearData();
                }
                //reasing points in clusters
                for(int iPoint = 0; iPoint < p_DataPoints.Length; ++iPoint)
                {
                    double dist = double.PositiveInfinity;
                    int cluster = 0;
                    for(int iCluster = 0; iCluster < m_Clusters.Length; ++ iCluster)
                    {
                        double d = m_Clusters[iCluster].Centroid.GetDistance(p_DataPoints[iPoint]);
                        if(d<dist)
                        {
                            dist = d;
                            cluster = iCluster;
                        }
                    }
                    m_Clusters[cluster].Points.Add(p_DataPoints[iPoint]);

                }
                // recalculate centriods
                double distChanged = 0;
                for (int iCluster = 0; iCluster < m_Clusters.Length; ++iCluster)
                {
                    distChanged += m_Clusters[iCluster].RecalculateCentroid();
                }
                Console.WriteLine("Convergence = " + distChanged);
                if (distChanged < 0.001)
                    break;
            }
            return m_Clusters;
        }

        public void PrintCentroids()
        {
            Console.WriteLine("Centroids" + new string(' ', 50) + "Members");
            for (int i = 0; i < m_Clusters.Length; ++i)
            {
                string ptTex = m_Clusters[i].Centroid.ToStringFormated();
                int diff = 60 - ptTex.Length;
                if (diff < 1) diff = 1;
                ptTex += new string(' ', diff);
                Console.WriteLine(ptTex + " " + m_Clusters[i].Points.Count.ToString());
            }
        }

        private KMSState CheckData(DataVec[] points, int k)
        {
            if (points == null) return KMSState.PointsArrayNull;
            if (points.Length < 1) return KMSState.DataPointsArayEmpty;
            if (points.Length < k) return KMSState.MoreCategoriesThanPoints;
            if (points[0] == null) return KMSState.NullEntryInDataPoints;
            int dimensions = points[0].Elements.Length;
            for (int i = 1; i < points.Length; ++i)
            {
                if (points[i] == null) return KMSState.NullEntryInDataPoints;
                if (points[i].Elements.Length != dimensions) return KMSState.DimensionMismatch;
            }

            return KMSState.OK;
        }
    }
}
