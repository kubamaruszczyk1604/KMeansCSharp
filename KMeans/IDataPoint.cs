using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KMeans
{
    public interface IDataPoint
    {
        double GetDistance(IDataPoint other);
        void AssignRandomPositionFromSet(IDataPoint[] set);
    }
}
