using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class Neuron
{
    public List<Link> Inputs { get; set; }

    protected double _value;
    public virtual double Value
    {
        get
        {
            return _value;
        }
    }

    public Neuron()
    {
        Inputs = new List<Link>();
    }

    public virtual void Update()
    {
        double sum = 0;
        foreach (Link link in Inputs)
        {
            sum += link.Value;
        }
        _value = Sigmoid(sum);

    }

    public double Sigmoid(double x)
    {
        return 2 / (1 + Math.Exp(-2 * x)) - 1;
    }
}
