using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KMeans
{
    public class KMClusterer<T> where T : IDataPoint, new()
    {

        private int m_K;
        private IDataPoint [] p_DataPoints;
        private IDataPoint[] m_Centroids;

        public KMClusterer(IDataPoint[] data, int k)
        {
            m_K = k;
            p_DataPoints = data;
            m_Centroids = new IDataPoint[k];
            for(int i = 0; i < m_K; ++i)
            {
                m_Centroids[i] = new T();
                m_Centroids[i].AssignRandomPositionFromSet(data);
            }

        }


        public void Calculate()
        {
            while(true)
            {
                for(int iPoint = 0; iPoint < p_DataPoints.Length; ++iPoint)
                {

                }
            }
        }
    }
}
