using Accord.MachineLearning.VectorMachines.Learning;
using Accord.Math.Optimization.Losses;
using Accord.Statistics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace hello._2dArray
{
    public class TwoDimArrayPrediction
    {
        private const int EXAMPLE_COUNT = 1000;


        public double[][] GetAnimal<T>(int size = EXAMPLE_COUNT) where T : IAnimal
        {
            var result = new List<T>();
            for (int i = 0; i < size; i++)
            {
                result.Add(Activator.CreateInstance<T>());
            }
            return result.Select(x => new double[] { x.Height, x.Weight }).ToArray();
        }

        public double[] GetAnimalLabel<T>(int size = EXAMPLE_COUNT) where T : IAnimal
        {
            var result = new List<double>();
            for (int i = 0; i < size; i++)
            {
                result.Add(typeof(T) == typeof(Cat) ? 0 : 1);
            }
            return result.Select(x => x).ToArray();
        }


        public void Run()
        {
            var smo = new SequentialMinimalOptimization<Accord.Statistics.Kernels.Gaussian>()
            {
                Complexity = 100 
            };

            var input = GetAnimal<Cat>().Concat(GetAnimal<Dog>()).ToArray();
            var input_test = GetAnimal<Cat>(100).Concat(GetAnimal<Dog>(100)).ToArray();

            var output = GetAnimalLabel<Cat>().Concat(GetAnimalLabel<Dog>()).ToArray();
            var output_test = GetAnimalLabel<Cat>(100).Concat(GetAnimalLabel<Dog>(100)).ToArray();

            Console.WriteLine($"Learn model on {input.Count()} inputs...");

            var model = smo.Learn(input, output);
            Console.WriteLine($"Make a prediction for {input_test.Count()} inputs...");
            var prediction = model.Decide(input_test);
            double accuracy = 1 - new AccuracyLoss(output_test).Loss(prediction);
            // Check if input_test equals output_test
            var testResults = prediction.ToZeroOne();
            Console.WriteLine($"Accuracy in percentage: { accuracy * 100 }");
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }


    }


}
