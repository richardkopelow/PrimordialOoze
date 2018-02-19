using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycast : BodyPart
{
    public Vector3 Direction;
    public float Distance;

    private Transform trans;
    private DrivenNeuron neuron;
    private int layerMask;

    protected override void Awake()
    {
        base.Awake();

        neuron = new DrivenNeuron();
        Inputs.Add(neuron);
    }

    void Start()
    {
        trans = GetComponent<Transform>();
        layerMask = LayerMask.GetMask("World");
    }

    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(trans.position + Direction * 0.6f, Direction, out hit, Distance, layerMask))
        {
            neuron.Drive(hit.distance / Distance);
        }
        else
        {
            neuron.Drive(0);
        }
    }
}
