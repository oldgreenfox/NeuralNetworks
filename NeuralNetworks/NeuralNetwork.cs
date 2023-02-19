namespace NeuralNetworks;

public class NeuralNetwork
{
    public Topology Topology { get; }
    public List<Layer> Layers { get; }

    public NeuralNetwork(Topology topology)
    {
        this.Topology = topology;
        this.Layers = new List<Layer>();
        CreateInputLayer();
        CreateHiddenLayers();
        CreateOutputLayer();
    }

    public double FeetForward(List<double> signals)
    {
        SendSignalsToInputLayer(signals);
        SendSignalToAllLayersAfterInput();
        return Layers.Last().neurons.OrderByDescending(n => n.Output).First().Output;
    }

    private void SendSignalToAllLayersAfterInput()
    {
        for (int i = 1; i < Layers.Count; i++)
        {
            var layer = this.Layers[i];
            var previousLayerSignals = Layers[i - 1].GetSignals();
            foreach (var neuron in layer.neurons)
            {
                neuron.FeetForward(previousLayerSignals);
            }
        }
    }

    private void SendSignalsToInputLayer(List<double> signals)
    {
        for (int i = 0; i < signals.Count; i++)
        {
            var signal = new List<double>() { signals[i] };
            var neuron = Layers[0].neurons[i];
            neuron.FeetForward(signal);
        }
    }

    private void CreateInputLayer()
    {
        var inputNeurons = new List<Neuron>();
        for (int i = 0; i < this.Topology.inputCount; i++)
        {
            var neuron = new Neuron(1, ActivationFunctions.LogisticFunction, NeuronType.INPUT);
            inputNeurons.Add(neuron);
        }
        var layer = new Layer(inputNeurons, NeuronType.INPUT);
        Layers.Add(layer);
    }

    private void CreateHiddenLayers()
    {
        for (int j = 0; j < Topology.hiddenLayers.Count; j++)
        {
            var hiddenNeurons = new List<Neuron>();
            var lastLayerCount = Layers.Last().Count;
            for (int i = 0; i < this.Topology.hiddenLayers[j]; i++)
            {
                var neuron = new Neuron(lastLayerCount, ActivationFunctions.LogisticFunction);
                hiddenNeurons.Add(neuron);

            }
            var layer = new Layer(hiddenNeurons);
            Layers.Add(layer);
        }
    }

    private void CreateOutputLayer()
    {
        var outputNeurons = new List<Neuron>();
        var lastLayerCount = Layers.Last().Count;
        for (int i = 0; i < this.Topology.outputCount; i++)
        {
            var neuron = new Neuron(lastLayerCount, ActivationFunctions.LogisticFunction, NeuronType.OUTPUT);
            outputNeurons.Add(neuron);
        }
        var layer = new Layer(outputNeurons, NeuronType.OUTPUT);
        Layers.Add(layer);
    }
}