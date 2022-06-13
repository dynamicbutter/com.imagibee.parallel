using System.Collections.Generic;
using UnityEngine;

namespace Imagibee.Parallel {
    // Only intended to form a baseline for testing
    public class Functions {
        // Returns the sum of the array
        public static float Sum(float[] x)
        {
            var sum = 0f;
            for (var i = 0; i < x.Length; ++i) {
                sum += x[i];
            }
            return sum;
        }

        // Returns the sum of the product of the arrays
        public static float SumProd(float[] x, float[] y)
        {
            var sum = 0f;
            for (var i = 0; i < x.Length; ++i) {
                sum += x[i] * y[i];
            }
            return sum;
        }

        // Returns the Pearson correlation coefficient x with each y
        public static List<float> Pcc(float[] x, float[][] y)
        {
            var results = new List<float>();
            var sumX = Sum(x);
            var n = x.Length;
            var xResult = Mathf.Sqrt(n * SumProd(x, x) - sumX * sumX);
            for (var ycount = 0; ycount < y.Length; ++ycount) {
                var sumY = Sum(y[ycount]);
                results.Add(
                    (n * SumProd(x, y[ycount]) - sumX * sumY) /
                    xResult /
                    Mathf.Sqrt(n * SumProd(y[ycount], y[ycount]) - sumY * sumY));
            }
            return results;
        }
    }
}