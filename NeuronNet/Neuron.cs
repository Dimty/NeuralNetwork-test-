using System;
using System.Collections.Generic;

namespace NeuralNet
{
    public class Neuron
    {
        public double exception = 0.0d;
        public TypeOfNeuron type;
        public List<double> listOfWeight = new List<double>();
        private double output = 0.0d;
        public double Output
        {
            get => output;
            set
            {
                if (type != TypeOfNeuron.Input) output = Sigmoid(value);
                else output = value;
            }
        }
        public Neuron(TypeOfNeuron type,int count)
        {
            this.type = type;
            if(type!=TypeOfNeuron.Output) GenerateRandomValueWeight(count);
        }
        private void GenerateRandomValueWeight(int count)
        {
            for (int i = 0; i < count; i++)
            {
                listOfWeight.Add(new Random().NextDouble());
            }
        }
        private static double Sigmoid(double x)
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
