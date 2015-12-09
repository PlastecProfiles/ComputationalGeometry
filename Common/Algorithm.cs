﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputationalGeometry.Common
{
    public static class Algorithm
    {
        public static IEnumerable<int> RandomPermutation(int n)
        {
            var output = new List<int>();
            for (int i = 0; i < n; i++)
                output.Add(i);

            int randomIndex;
            Random generator = new Random();

            for (int i = n - 1; i > 0; i--)
            {
                randomIndex = generator.Next(0, i + 1);
                int temp = output[randomIndex];
                output[randomIndex] = output[i];
                output[i] = temp;
            }
            return output;
        }
    }
}
