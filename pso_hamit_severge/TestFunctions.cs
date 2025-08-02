using System;

namespace pso_hamit_severge
{
    public static class TestFunctions
    {
        // Six-hump Camel-back function as described in the slides
        // f(x) = 4x₁² - 2.1x₁⁴ + (1/3)x₁⁶ + x₁x₂ - 4x₂² + 4x₂⁴
        // -5 ≤ x₁, x₂ ≤ 5
        public static double SixHumpCamelBack(double[] x)
        {
            double x1 = x[0];
            double x2 = x[1];
            
            double term1 = 4 * Math.Pow(x1, 2);
            double term2 = -2.1 * Math.Pow(x1, 4);
            double term3 = (1.0/3.0) * Math.Pow(x1, 6);
            double term4 = x1 * x2;
            double term5 = -4 * Math.Pow(x2, 2);
            double term6 = 4 * Math.Pow(x2, 4);
            
            return term1 + term2 + term3 + term4 + term5 + term6;
        }
        
        // Sphere function (simple test function)
        // f(x) = Σx₁²
        public static double Sphere(double[] x)
        {
            double sum = 0;
            for (int i = 0; i < x.Length; i++)
            {
                sum += x[i] * x[i];
            }
            return sum;
        }
        
        // Rosenbrock function (banana function)
        // f(x) = Σ[100(x_{i+1} - x_i²)² + (1 - x_i)²]
        public static double Rosenbrock(double[] x)
        {
            double sum = 0;
            for (int i = 0; i < x.Length - 1; i++)
            {
                double term1 = 100 * Math.Pow(x[i + 1] - x[i] * x[i], 2);
                double term2 = Math.Pow(1 - x[i], 2);
                sum += term1 + term2;
            }
            return sum;
        }
    }
} 