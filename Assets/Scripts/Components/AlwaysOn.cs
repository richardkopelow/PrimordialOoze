using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlwaysOn : BodyPart {

    protected override void Awake()
    {
        base.Awake();
        DrivenNeuron n = new DrivenNeuron();
        n.Drive(1);
        Inputs.Add(n);
    }
}
