using System;

namespace KMeans
{
    /// <summary>
    /// A data vector class with some distance calculation and helper methods.
    /// 
    /// If you need to use different/custom data structure or distance calculation, it should be fairly easy. 
    /// Since algorithm only cares about the distance function and not about the underlying data structure, 
    /// your custom class can just inherit from DataVec and provide new implementation of GetDistance() method via override.
    /// </summary>
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
        

        public virtual double GetDistance(DataVec other)
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
