using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KMeans
{
    public class DataVec
    {

        public double [] Elements { get; private set; }


        static public DataVec DeepCopy(DataVec source)
        {
            double[] data = new double[source.Elements.Length];
            Array.Copy(source.Elements, data, source.Elements.Length);
            DataVec ret = new DataVec(data);
            return ret;
        }

        public DataVec(double [] data)
        {
            Elements = data;
        }

        public DataVec(int dimensions)
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
        

        public double GetDistance(DataVec other)
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
            Console.WriteLine("E: " + this.ToString());
        }

        public override string ToString()
        {
            string str = "";

            for (int i = 0; i < Elements.Length; ++i)
            {
                str += Elements[i].ToString() + ",";
            }
            return str.Substring(0,str.Length-1);
        }

        public string ToStringFormated()
        {
            string str = "";
            const int digits = 25;
            for (int i = 0; i < Elements.Length; ++i)
            {
                int ln = Elements[i].ToString().Length;
                str += Elements[i].ToString() + new string(' ', digits - ln);
            }
            return str.Substring(0, str.Length - 1);
        }
    }

   
}
