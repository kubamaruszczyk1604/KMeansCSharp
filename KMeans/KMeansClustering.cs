using System;


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

        /// <summary>
        /// Create instance of KMeansClustering clasifier.
        /// </summary>
        /// <param name="points">All data points</param>
        /// <param name="k">Number of bins</param>
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
            int dimensions = points[0].Components.Length;
            for(int i = 0; i < m_K; ++i)
            {
                m_Clusters[i] = new Cluster();
                m_Clusters[i].Initialize(points);
            }

        }

        /// <summary>
        /// Performs clustering.
        /// </summary>
        /// <param name="maxDiv">Mean acceptable divergence</param>
        /// <returns>Array of clusters, each containing centroid and a list of assigned data points.</returns>
        public Cluster[] Compute(double maxDiv = 0.0001d)
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
                Console.WriteLine("Mean error = " + distChanged);
                if (distChanged/m_Clusters.Length < maxDiv)
                    break;
            }
            return m_Clusters;
        }

        /// <summary>
        /// Prints brief summary of cluster info.
        /// </summary>
        public void PrintClusters()
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
            int dimensions = points[0].Components.Length;
            for (int i = 1; i < points.Length; ++i)
            {
                if (points[i] == null) return KMSState.NullEntryInDataPoints;
                if (points[i].Components.Length != dimensions) return KMSState.DimensionMismatch;
            }

            return KMSState.OK;
        }
    }
}