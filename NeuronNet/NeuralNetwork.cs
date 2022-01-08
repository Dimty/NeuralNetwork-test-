using System;
using System.Collections.Generic;
using System.Linq;

namespace NeuralNet
{
	public class NeuralNetwork
	{
        private int amountOfInputNeurons;
        private int amountOfOutputNeurons;
        private int[] amountOfHiddenNeurons;
        public int AmountOfInputNeurons
        {
            get => amountOfInputNeurons;
            set
            {
                if (value is 0) throw new Exception("The number of input neurons can't be zero");
                else amountOfInputNeurons = value;
            }
        }
        public int AmountOfOutputNeurons
        {
            get => amountOfOutputNeurons;
            set
            {
                if (value is 0) throw new Exception("The number of output neurons can't be zero");
                else amountOfOutputNeurons = value;
            }
        }
        public int[] AmountOfHiddenNeurons
        {
            get => amountOfHiddenNeurons;
            set => amountOfHiddenNeurons= value;
        }
        public List<List<Neuron>> layers = new List<List<Neuron>>();
		public NeuralNetwork(int input,int output,params int[] hiddens)
		{
            AmountOfInputNeurons = input;
            AmountOfOutputNeurons = output;
            AmountOfHiddenNeurons = hiddens;
            CreateLayers();
		}

        public void Training(double[,] inputParams, int[] expected,int epoch = 5000, double learningRate = 1.0d)
        {
            for (int q = 0; q < epoch; q++)
            {
                for (int i = 0; i < inputParams.Length; i++)
                {
                    var input = new double[inputParams.GetLength(1)];
                    for (int j = 0; j < input.Length; j++)
                    {
                        input[j] = inputParams[i, j];
                    }
                    var result = Predict(input);
                }
            }    
        }
        //ÍÓÆÍÎ ÍÀÉÒÈ ÎØÈÁÊÓ expect - actual
        private void BackPropagation()
        {
            
        }

        public double[] Predict(double[] input)
        {
            SetInputValues(input);
            for (int layer = 0; layer < layers.Count - 1; layer++)
            {
                double sum = 0.0d;
                for (int weight = 0; weight < layers[layer + 1].Count; weight++)
                {
                    for (int neur = 0; neur < layers[layer].Count; neur++)
                    {
                        var part1 = layers[layer][neur].Output;
                        var part2 = layers[layer][weight].listOfWeight[weight];
                        sum += part1 * part2;
                    }
                    layers[layer + 1][weight].Output = sum;
                }
            }
            return layers.Last().Select(x => x.Output).ToArray();
        }

        private void SetInputValues(double[] input)
        {
            for (int i = 0; i < amountOfInputNeurons; i++)
            {
                layers[0][i].Output = input[i];
            }
        }

        private void CreateLayers()
        {
            CreateInputLayer();
            CreateHiddenLayers();
            CreateOutputLayer();
        }



        private double[] TrainingPredict()
        {
            
        }

		private void CreateHiddenLayers()
		{
            
            for (int layer = 0; layer < amountOfHiddenNeurons.Length; layer++)
            {
                var list = new List<Neuron>();
                for (int neu = 0; neu < amountOfHiddenNeurons[layer]; neu++)
                {
                    if(layer!=amountOfHiddenNeurons.Length-1) list.Add(new Neuron(TypeOfNeuron.Hidden,amountOfHiddenNeurons[layer+1]));
                    else list.Add(new Neuron(TypeOfNeuron.Hidden, amountOfOutputNeurons));
                }
                layers.Add(list);
            }
		}
        private void CreateInputLayer()
		{
            int count = amountOfOutputNeurons;
            var list = new List<Neuron>();
            if (amountOfHiddenNeurons.Length != 0) count = amountOfHiddenNeurons[0];
            for (int i = 0; i < amountOfInputNeurons; i++)
            {
                list.Add(new Neuron(TypeOfNeuron.Input,count));
            }
            layers.Add(list);
        }
        private void CreateOutputLayer()
        {
            var list = new List<Neuron>();
            for (int i = 0; i < amountOfOutputNeurons; i++)
            {
                list.Add(new Neuron(TypeOfNeuron.Output,0));
            }
            layers.Add(list);
        }
	}
}