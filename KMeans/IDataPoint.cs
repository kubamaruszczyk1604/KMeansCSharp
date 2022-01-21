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

        private double EuclidianMagnitude(double[] data)
        {
            double sumSquared = 0;

            for(int i = 0; i < data.Length; ++i)
            {
                sumSquared += (data[i] * data[i]);
            }
            return Math.Sqrt(sumSquared);
        }
        

        public double GetDistance(IDataPoint other)
        {
            if(other.Data.Length != Data.Length)
            {
                throw new Exception("Dimension mismatch");
            }
            double[] diff = new double[Data.Length];
            for(int i = 0; i < diff.Length; ++i)
            {
                diff[i] = other.Data[i] - Data[i];
            }

            return EuclidianMagnitude(diff);
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
