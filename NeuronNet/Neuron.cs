using System;
using System.Collections.Generic;

namespace NeuralNet
{
    public class Neuron
    {
       
        public Neuron()
        {

        }
        private void GenerateRandomValueWeight()
        {
        }
        public static double Sigmoid(double x)
        {
            return (double)1 / (1 + Math.Exp(-x));
        }
        private double SigmoidDerivative(double x)
        {
            return x * (1 - x);
        }
    }
    
    public enum TypeOfNeuron
    {
        Input,
        Hidden,
        Output
    }
}
