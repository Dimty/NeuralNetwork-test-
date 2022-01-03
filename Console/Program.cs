using System;
using NeuronNet;

namespace ConsoleProj
{
    class Program
    {
        static void Main(string[] args)
        {
            NeuronNetwork neuronNetwork = new NeuronNetwork(2, 1, 2);
            neuronNetwork.Training(new double[]{1,1 }, new int[]{ 1 },100);
        }
    }
}
