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

        public double [] Components { get; protected set; }

        /// <summary>
        /// Performs a deep copy of DataVec class. 
        /// </summary>
        /// <param name="source">DataVec object to copy</param>
        /// <returns></returns>
        static public DataVec DeepCopy(DataVec source)
        {
            double[] data = new double[source.Components.Length];
            Array.Copy(source.Components, data, source.Components.Length);
            DataVec ret = new DataVec(data);
            return ret;
        }

        public DataVec()
        {
            Components = new double[0];
        }

        public DataVec(double [] data)
        {
            Components = data;
        }

        public DataVec(int dimensions)
        {
            Components = new double[dimensions];
        }
    
        /// <summary>
        /// Calculates distance between two data points.
        /// </summary>
        /// <param name="other">Other data point</param>
        /// <returns></returns>
        public virtual double GetDistance(DataVec other)
        {
            if(other.Components.Length != Components.Length)
            {
                throw new Exception("Dimension mismatch");
            }
            double[] diff = new double[Components.Length];
            for(int i = 0; i < diff.Length; ++i)
            {
                diff[i] = other.Components[i] - Components[i];
            }

            return CalculateMagintude(diff);
        }
        /// <summary>
        /// Print data point. For Debug.
        /// </summary>
        public void Print()
        {
            Console.WriteLine("E: " + this.ToString());
        }

        /// <summary>
        /// Obtain string representation of component values separated by commas.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            string str = "";

            for (int i = 0; i < Components.Length; ++i)
            {
                str += Components[i].ToString() + ",";
            }
            return str.Substring(0,str.Length-1);
        }

        /// <summary>
        /// Obtain string representation of component values, separated by spaces and alligned.
        /// </summary>
        /// <returns></returns>
        public string ToStringFormated()
        {
            string str = "";
            const int digits = 25;
            for (int i = 0; i < Components.Length; ++i)
            {
                int ln = Components[i].ToString().Length;
                str += Components[i].ToString() + new string(' ', digits - ln);
            }
            return str.Substring(0, str.Length - 1);
        }


        protected double CalculateMagintude(double[] data)
        {
            double sumSquared = 0;

            for (int i = 0; i < data.Length; ++i)
            {
                sumSquared += (data[i] * data[i]);
            }
            return Math.Sqrt(sumSquared);
        }
    }

   
}
