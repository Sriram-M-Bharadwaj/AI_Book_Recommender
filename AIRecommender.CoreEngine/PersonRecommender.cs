using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace AIRecommender.CoreEngine
{
  

    public class PersonRecommender : IRecommender
    {
        public double GetCorrelation(int[] baseArray, int[] otherArray)
        {
            int[] baseData = baseArray;
            int[] otherData = otherArray;                                
             
                            
         
         Array.Resize(ref otherData,baseData.Length);
            int[] xy = new int[baseData.Length];
            int[]x2 = new int[baseData.Length];
            int[]y2 = new int[baseData.Length];
             for (int i = 0; i < baseData.Length; i++)
            {
                if (baseData[i] == 0 || otherData[i] == 0)
                {
                    baseData[i] += 1;
                    otherData[i] += 1;
                }
                xy[i] = baseData[i] * otherData[i];
                x2[i] = baseData[i] * baseData[i];
                y2[i] = otherData[i] * otherData[i];
            }

             int N= baseData.Length;
            double num = (N * xy.Sum()) - (baseData.Sum() * otherData.Sum());
            double den = Math.Sqrt((N * x2.Sum() - (baseData.Sum() * baseData.Sum())) * (N * y2.Sum() - (otherData.Sum() * otherData.Sum())));

             
                
            return num / den;

            
            
             
        }
    }
   
}
