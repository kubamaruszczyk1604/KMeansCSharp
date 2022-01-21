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
        

        private int m_K;
        private IDataPoint [] p_DataPoints;
        private Cluster[] m_Clusters;

        private KMSState CheckData(IDataPoint[] points, int k)
        {
            if (points == null) return KMSState.PointsArrayNull;
            if (points.Length < 1) return KMSState.DataPointsArayEmpty;
            if (points.Length < k) return KMSState.MoreCategoriesThanPoints;
            if (points[0] == null) return KMSState.NullEntryInDataPoints;
            int dimensions = points[0].Data.Length;
            for(int i = 1; i< points.Length;++i)
            {
                if (points[i] == null) return KMSState.NullEntryInDataPoints;
                if (points[i].Data.Length != dimensions) return KMSState.DimensionMismatch;
            }

            return KMSState.OK;
        }

       

        public KMeansClustering(IDataPoint[] points, int k)
        {

            KMSState state = CheckData(points, k);
            if(state != KMSState.OK)
            {
                throw new Exception("Data check failed. Reason: " + state.ToString());
            }

            m_K = k;
            p_DataPoints = points;
            m_Clusters = new Cluster[m_K];
            int dimensions = points[0].Data.Length;
            for(int i = 0; i < m_K; ++i)
            {
                m_Clusters[i] = new Cluster(dimensions);
                m_Clusters[i].RandomCentroidPlacement(points);
            }

        }


        public void PrintCentroids()
        {
            Console.WriteLine("Centroids: ");
            for(int i = 0; i < m_Clusters.Length; ++i)
            {
                m_Clusters[i].Centroid.Print();
            }
        }

        public void Calculate()
        {
            while(true)
            {
                for(int iPoint = 0; iPoint < p_DataPoints.Length; ++iPoint )
                {

                }
            }
        }


        //public 
    }
}
