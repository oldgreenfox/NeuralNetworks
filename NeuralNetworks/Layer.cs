namespace NeuralNetworks;

public class Layer
{
    public List<Neuron> neurons { get; }
    public int Count => neurons?.Count ?? 0;

    public Layer(List<Neuron> neurons, NeuronType neuronType = NeuronType.NORMAL)
    {
        foreach (var neuron in neurons)
        {
            if (neuron.neuronType != neuronType)
            {
                throw new ArgumentException($"{neuron.id} has another type");
            }
        }

        this.neurons = neurons;
    }

    public List<double> GetSignals()
    {
        return this.neurons.Select(n => n.Output).ToList();

        // List<double> signals = new List<double>();
        // foreach (var neuron in this.neurons)
        // {
        //     signals.Add(neuron.Output);
        // }
        //
        // return signals;
    }
}