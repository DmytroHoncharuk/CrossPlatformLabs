using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace App;

public class GlassProblemSolver
{
    private static readonly int Modulus = 1000 * 1000;
    public static int Solve(int height)
    {
        if (height < 1 || height > 1e5)
        {
            throw new ArgumentOutOfRangeException(nameof(height), "The number must be a natural number and less than or equal to 100000.");
        }
        
        List<int> count = new List<int>(new int[height + 1]);
        count[0] = 1; 

        for (int h = 1; h <= height; h++)
        {
            if (h >= 10)
            {
                count[h] += count[h - 10];
            }
            if (h >= 11)
            {
                count[h] += count[h - 11];
            }
            if (h >= 12)
            {
                count[h] += count[h - 12];
            }
            count[h] %= Modulus;
        }

        return count[height] * 2 % Modulus;
    }
}
