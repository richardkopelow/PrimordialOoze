using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class DrivenNeuron:Neuron
{
    public override void Update()
    {
        
    }

    public void Drive(double value)
    {
        _value = value;
    }
}
