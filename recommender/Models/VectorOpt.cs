using System;
using System.Numerics;

namespace recommender.Models
{
    public class VectorOpt // to be used for any vectors
    {       
        public static int CountNonZero<T>(T[] arg)
        {
            int no_elements = 0;
            for (int k = 0; k < arg.Length; k++) 
            {                
                if (Convert.ToInt32(arg[k]) != 0) no_elements++; 
            }
            return no_elements;
        }
        public static double vectorMagnitude<T>(T[] arg)
        {
            double sum_sq = 0;
            for (int k = 0; k < arg.Length; k++)
            {
                sum_sq = sum_sq + Math.Pow(Convert.ToDouble(arg[k]), 2);
            }
            return Math.Sqrt(sum_sq);
        }
        public static double vectorDotProduct<T>(T[] argu, T[] argv)
        {
            double inner_prod = 0;
            for (int k = 0; k < argu.Length; k++)
            {
                inner_prod = inner_prod + Convert.ToDouble(argu[k])*Convert.ToDouble(argv[k]);
            }
            return inner_prod;
        }
        public static double cosineSimilarity<T>(T[] argu, T[] argv)
        {
            double ssu = 0;
            double ssv = 0;
            double num = 0;
            for (int k = 0; k < argu.Length; k++)
            {
                ssu = ssu + Math.Pow(Convert.ToDouble(argu[k]), 2);
                ssv = ssv + Math.Pow(Convert.ToDouble(argv[k]), 2);
                num = Convert.ToDouble(argu[k])*Convert.ToDouble(argv[k]);
            }
            return num/Math.Sqrt(ssu)/Math.Sqrt(ssv);
        }
    }
}
