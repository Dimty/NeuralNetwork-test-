using System;
using NeuralNet;


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

            
            NeuralNetwork neuronNetwork = new NeuralNetwork(4, 1, 3);
            neuronNetwork.Training(input, expected, 1000);
            var result = neuronNetwork.Predict(new[] { 0d, 1d, 0d, 0d }, 1);
            Console.WriteLine("Him " + Math.Round(ans.Output), 1);
            Console.WriteLine("My " + Math.Round(result[0], 1));
        }
        
    }
}
