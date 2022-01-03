using System;
using System.Collections.Generic;

namespace NeuronNet
{
    public class Neuron
    {
        public TypeOfNeuron TypeN { get; private set; }
        private double[] listOfOutputWeight;
        private double sumOfInputWeight;
        public double CorrectionValue;
        public double SumInputValues
        {
            get => sumOfInputWeight;
            set
            {
                if (value < 0) sumOfInputWeight = 0;
                else sumOfInputWeight = value;
            }
        }
        public double[] ListOfWeights
        {
            get => listOfOutputWeight;
            set => listOfOutputWeight = value;
        }
        public Neuron(TypeOfNeuron type, int amountOfNeurons)
        {
            this.TypeN = type;
            GenerateRandomValueWeight(amountOfNeurons);
        }
        private void GenerateRandomValueWeight(int amountOfNeuronsInTheNextLayer)
        {
            listOfOutputWeight = new double[amountOfNeuronsInTheNextLayer];
            for (int i = 0; i < amountOfNeuronsInTheNextLayer; i++)
            {
                listOfOutputWeight[i] = 0.5d;
            }
        }
        public static double Sigmoid(double x)
        {
            return (double)1 / (1 + Math.Exp(-x));
        }
        private void SumInput(IList<double> list)
        {
            double sum = 0.0d;
            foreach (var item in list)
            {
                sum += item;
            }
            sumOfInputWeight = sum;
        }
    }
    public enum TypeOfNeuron
    {
        Input=0,
        Hidden=1,
        Output=2
    }
}
