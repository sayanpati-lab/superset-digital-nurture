using System;

namespace FinancialForecasting
{
    class Program
    {
        // Step 3: Recursive method to calculate future value
        // FV_n = FV_0 * (1 + r)^n
        static double PredictFutureValue(double initialValue, double growthRate, int years)
        {
            if (years == 0)
                return initialValue;
            return PredictFutureValue(initialValue, growthRate, years - 1) * (1 + growthRate);
        }

        // Step 4: Optimized version using memoization
        static double PredictFutureValueMemo(double initialValue, double growthRate, int years, double[] memo)
        {
            if (years == 0)
                return memo[0] = initialValue;

            if (memo[years] != 0)
                return memo[years];

            return memo[years] = PredictFutureValueMemo(initialValue, growthRate, years - 1, memo) * (1 + growthRate);
        }

        static void Main(string[] args)
        {
            double initialValue = 1000.0;     // Starting capital
            double annualGrowthRate = 0.1;    // 10% growth
            int forecastYears = 5;

            // Step 3: Recursive approach
            double futureValue = PredictFutureValue(initialValue, annualGrowthRate, forecastYears);
            Console.WriteLine($"📈 Predicted Future Value (Year {forecastYears}) using recursion: ${futureValue:F2}");

            // Step 4: Optimized with memoization
            double[] memo = new double[forecastYears + 1];
            double optimizedValue = PredictFutureValueMemo(initialValue, annualGrowthRate, forecastYears, memo);
            Console.WriteLine($"⚡ Optimized Future Value (Memoized): ${optimizedValue:F2}");

            // Time complexity analysis
            Console.WriteLine("\n📊 Time Complexity:");
            Console.WriteLine("🔁 Recursive: O(n) - one call per year");
            Console.WriteLine("🧠 Memoized: O(n) - avoids recomputation");
            Console.WriteLine("✅ Use memoization for deep recursion or repeated calculations.");

            Console.ReadKey();
        }
    }
}
