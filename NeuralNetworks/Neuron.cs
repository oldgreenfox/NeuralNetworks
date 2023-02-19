namespace NeuralNetworks;

public class Neuron
{
    public Guid id { get; private set; }
    public List<double> Weights { get; private set; }
    public NeuronType neuronType { get; }
    public double Output { get; private set; }
    private Func<double, double> activationFunc;

    public Neuron(int inputCount, Func<double, double> activationFunc, NeuronType neuronType = NeuronType.NORMAL)
    {
        this.id = Guid.NewGuid();
        this.activationFunc = activationFunc;
        this.neuronType = neuronType;
        this.Weights = new List<double>();
        for (int i = 0; i < inputCount; i++)
        {
            Weights.Add( 1);
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

        if (this.neuronType != NeuronType.INPUT)
        {
            this.Output = this.activationFunc(sum);
        }
        else
        {
            this.Output = sum;
        }
        return this.Output;
    }

    public void SetWeights(params double[] weights)
    {
        //TODO видалити після реалізації навчання
        for (int i = 0; i < weights.Length; i++)
        {
            this.Weights[i] = weights[i];
        }
    }

    public override string ToString()
    {
        return Output.ToString();
    }
}