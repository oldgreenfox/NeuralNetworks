namespace NeuralNetworks;

public class Neuron
{
    public Guid id { get; private set; }
    public List<double> Weights { get; }
    public NeuronType neuronType { get; }
    public double Output { get; private set; }
    private Func<double, double> activationFunc;

    public Neuron(int inputCount, Func<double, double> activationFunc, NeuronType neuronType = NeuronType.NORMAL)
    {
        this.id = Guid.NewGuid();
        this.activationFunc = activationFunc;
        this.neuronType = neuronType;
        this.Weights = new List<double>(inputCount);
        for (int i = 0; i < inputCount; i++)
        {
            this.Weights[i] = 1;
        }
    }

    public double FeetForward(List<double> inputs)
    {
        if (inputs.Count != this.Weights.Count)
        {
            throw new ArgumentException($"{this.id} neuron can't feet output, because cont inputs not equal weights");
        }

        var sum = 0.0;
        for (int i = 0; i < inputs.Count; i++)
        {
            sum += inputs[i] * this.Weights[i];
        }

        this.Output = this.activationFunc(sum);
        return Output;
    }

    public override string ToString()
    {
        return Output.ToString();
    }
}