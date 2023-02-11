namespace NeuralNetworks;

public class ActivationFunctions
{
    public static double LogisticFunction(double x)
    {
        return 1 / (1 + Math.Exp(-x));
    }
}