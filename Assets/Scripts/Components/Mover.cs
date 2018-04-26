using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : BodyPart
{
    public float Speed;

    private Rigidbody rigid;
    private Neuron up;
    private Neuron right;

    [SerializeField]
    private Vector3 v;

    protected override void Awake()
    {
        base.Awake();

        up = new Neuron();
        right = new Neuron();
        Outputs.Add(up);
        Outputs.Add(right);
    }

    void Start()
    {
        rigid = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        v = new Vector3((float)right.Value, 0, (float)up.Value);
        if (v.magnitude>1)
        {
            v.Normalize();
        }
        rigid.position += v * Speed * Time.deltaTime;
    }
}
