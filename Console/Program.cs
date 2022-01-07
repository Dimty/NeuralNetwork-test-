using System;
using NeuronNet;
using NeuralNetworks;

namespace ConsoleProj
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = new double[][]
            {
                new[]{0d, 0d, 0d, 0d },
                new[]{0d,0d,0d,1d },
                new[]{0d,0d,1d,0d },
                new[]{0d,0d,1d,1d },
                new[]{0d,1d,0d,0d },
                new[]{0d,1d,0d,1d },
                new[]{0d,1d,1d,0d },
                new[]{0d,1d,1d,1d },
                new[]{1d,0d,0d,0d },
                new[]{1d,0d,0d,1d },
                new[]{1d,0d,1d,0d },
                new[]{1d,0d,1d,1d },
                new[]{1d,1d,0d,0d },
                new[]{1d,1d,0d,1d },
                new[]{1d,1d, 1d, 0d },
                new[]{1d, 1d, 1d,1d },
            };
            var expected = new[] { 0d, 0, 0, 0, 1, 1, 1, 1, 0, 0, 0, 0, 1, 1, 1, 1 };

            Topology topology = new Topology(4, 1, 1, 3);
            NeuralNetwork neuralNetwork = new NeuralNetwork(topology);
            neuralNetwork.Learn(expected, ReDefinishion(input), 1000);
            var ans = neuralNetwork.Predict(new[] { 0d, 1d, 0d, 0d });
            NeuronNetwork neuronNetwork = new NeuronNetwork(4, 1, 3);
            neuronNetwork.Training(input, expected, 1000);
            var result = neuronNetwork.Predict(new[] { 0d, 1d, 0d, 0d }, 1);
            Console.WriteLine("Him " + Math.Round(ans.Output), 1);
            Console.WriteLine("My " + Math.Round(result[0], 1));
        }
        public static Double[,] ReDefinishion(double[][] array)
        {
            double[,] newArray = new double[array.Length, 4];
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array[i].Length; j++)
                {
                    newArray[i, j] = array[i][j];
                }
            }
            return newArray;
        }
    }
}
