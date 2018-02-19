using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyPart : MonoBehaviour
{
    public List<Neuron> Inputs;
    public List<Neuron> Outputs;

    protected virtual void Awake()
    {
        Inputs = new List<Neuron>();
        Outputs = new List<Neuron>();
    }
}
