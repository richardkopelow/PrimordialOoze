using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class Link
{
    private double _value;
    public double Value
    {
        get { return _value; }
    }

    public double  Weight { get; set; }
    public Neuron Input { get; set; }

    public void Update()
    {
        _value = Input.Value * Weight;
    }
}
