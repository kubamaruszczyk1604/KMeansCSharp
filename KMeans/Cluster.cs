using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KMeans
{
    public class Cluster
    {
        public IDataPoint Centroid { get; set; }
        public List<IDataPoint> Data { get; set; }
    }
}
