using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Body : MonoBehaviour
{
    public BodyPart[] BodyParts;
    public Genome Genome;

    private Transform trans;
    private Brain brain;

    void Start()
    {
        trans = GetComponent<Transform>();
        List<Neuron> inputs = new List<Neuron>();
        List<Neuron> outputs = new List<Neuron>();
        foreach (BodyPart part in BodyParts)
        {
            inputs.AddRange(part.Inputs);
            outputs.AddRange(part.Outputs);
        }

        brain = new Brain(Genome, inputs, outputs);
    }
    
    void Update()
    {
        brain.Update();
    }
}
