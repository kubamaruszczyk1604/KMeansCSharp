using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KMeans
{
    public class IDataPoint
    {

        public double [] Data { get; private set; }


        static public IDataPoint DeepCopy(IDataPoint source)
        {
            double[] data = new double[source.Data.Length];
            Array.Copy(source.Data, data, source.Data.Length);
            IDataPoint ret = new IDataPoint(data);
            return ret;
        }

        public IDataPoint(double [] data)
        {
            Data = data;
        }

        public IDataPoint(int dimensions)
        {
            Data = new double[dimensions];
        }

        public double GetDistance(IDataPoint other)
        {
            return 0;
        }

        public void Print()
        {
            string str = "E: ";

            for(int i = 0; i < Data.Length; ++i)
            {
                str += Data[i].ToString() + ", ";
            }
            Console.WriteLine(str);
        }
    }

   
}
