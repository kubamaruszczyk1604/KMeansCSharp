using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KMeans
{
    public class IDataPoint
    {

        public double [] Elements { get; private set; }


        static public IDataPoint DeepCopy(IDataPoint source)
        {
            double[] data = new double[source.Elements.Length];
            Array.Copy(source.Elements, data, source.Elements.Length);
            IDataPoint ret = new IDataPoint(data);
            return ret;
        }

        public IDataPoint(double [] data)
        {
            Elements = data;
        }

        public IDataPoint(int dimensions)
        {
            Elements = new double[dimensions];
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
            if(other.Elements.Length != Elements.Length)
            {
                throw new Exception("Dimension mismatch");
            }
            double[] diff = new double[Elements.Length];
            for(int i = 0; i < diff.Length; ++i)
            {
                diff[i] = other.Elements[i] - Elements[i];
            }

            return EuclidianMagnitude(diff);
        }

        public void Print()
        {
            string str = "E: ";

            for(int i = 0; i < Elements.Length; ++i)
            {
                str += Elements[i].ToString() + ", ";
            }
            Console.WriteLine(str);
        }
    }

   
}
