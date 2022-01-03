using System;
using System.Collections.Generic;
using System.Linq;

namespace NeuronNet
{
	public class NeuronNetwork
	{
		private int inputLayer;
		private int outputLayer;
		private int[] hiddenLayer;
        private double[] answerOfNetwork;
		public List<Neuron[]> neurons = new List<Neuron[]>();
		public NeuronNetwork(int inp, int outp, params int[] hidden)
		{
			this.inputLayer = inp;
			this.outputLayer = outp;
            this.answerOfNetwork = new double[outp];
			this.hiddenLayer = hidden;
            CreateInputAndOutputLayers();
		}

		private void CreateHiddenLayers()
		{
            for (int item = 0 ;item < hiddenLayer.Length;item++)
			{
				Neuron[] nrs = new Neuron[hiddenLayer[item]];
                for (int i = 0; i < hiddenLayer[item]; i++)
                {
                    if (item + 1 != hiddenLayer.Length)
                    {
                        nrs[i] = new Neuron(TypeOfNeuron.Hidden,item+1);
                    }
                    else nrs[i] = new Neuron(TypeOfNeuron.Hidden, outputLayer);
                }
				neurons.Add(nrs);
			}
		}//генерирую слои со случайными значениями

        private void CreateInputAndOutputLayers()
		{
			for (int t = 0; t < 3; t++)
            {
                Neuron[] nrs = null; ;
                if (t == 1)
                {
                    CreateHiddenLayers();
                    continue;
                }
                if (t == 0)
                {
                    nrs = new Neuron[inputLayer];
                    if (hiddenLayer.Length != 0)CreateLayer(t, inputLayer, nrs, hiddenLayer[0]);
                    else CreateLayer(t, inputLayer, nrs, outputLayer);
                }
                if (t == 2)
                {
                    nrs = new Neuron[outputLayer];
                    CreateLayer(t, outputLayer, nrs, 0);
                }
                neurons.Add(nrs);
            }
        }//генерирую слои со случайными значениями

        private static void CreateLayer(int t, int amount, Neuron[] nrs,int outputValue)
        {
            for (int i = 0; i < amount; i++)
            {
                nrs[i] = new Neuron((TypeOfNeuron)t, outputValue);
            }
        }//генерирую слои со случайными значениями

        public void Training(double[] selection, int[] expected, int iteration)
        {
            for (int i = 0; i < inputLayer; i++)
            {
                neurons[0][i].SumInputValues = selection[i];
            }

            for (int i = 0; i < iteration; i++)
            {
                var actual = Predict();
                BackPropagation(expected, actual);
            }

        }//обучаю

        private void BackPropagation(int[] expected, double[] actual)
        {
            double[] exception = new double[actual.Length];
            for (int i = 0; i < neurons[neurons.Count-1].Length; i++)
            {
                neurons[neurons.Count - 1][i].CorrectionValue = expected[i] - actual[i];
            }
            for (int layer = neurons.Count-2; layer >= 0; layer--)
            {
                for (int neuron = 0; neuron < neurons[layer].Length; neuron++)
                {
                    double sum = 0.0d;
                    for (int weight = 0; weight < neurons[layer][neuron].ListOfWeights.Length; weight++)
                    {
                        sum += neurons[layer][neuron].ListOfWeights[weight] * neurons[layer + 1][weight].CorrectionValue;
                    }
                    neurons[layer][neuron].CorrectionValue = sum;
                }
            }//вычисляю сигму
            for (int layer = 1; layer < neurons.Count; layer++)
            {
                for (int presentNeuron = 0; presentNeuron < neurons[layer].Length; presentNeuron++)
                {
                    for (int previousNeuron = 0; previousNeuron < neurons[layer - 1].Length; previousNeuron++)
                    {
                        neurons[layer - 1][previousNeuron].ListOfWeights[presentNeuron] = 
                    }

                }
            }
        }
        private double WeightsCorrection()
        {
            
        }
        private double[] Predict()
        {
            for (int layer = 1; layer < neurons.Count; layer++)
            {
                for (int presentNeuron = 0; presentNeuron < neurons[layer].Length; presentNeuron++)
                {
                    double sum = 0.0d;
                    for (int previousNeuron = 0; previousNeuron < neurons[layer-1].Length; previousNeuron++)
                    {
                        sum += neurons[layer - 1][previousNeuron].ListOfWeights[presentNeuron] * neurons[layer - 1][previousNeuron].SumInputValues;
                    }
                    var result = Neuron.Sigmoid(sum);
                    neurons[layer][presentNeuron].SumInputValues = result;
                }
            }
            return neurons[neurons.Count-1].Select(x=>x.SumInputValues).ToArray();
        }
        private double SigmoidDerivative(double x)
        {
			double sig = Neuron.Sigmoid(x);
			return sig * (1 - sig);
        }
	}
}