using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


public class Simulation : MonoBehaviour
{
    public Transform Body;
    private Genome[] fittestGenomes;

    private List<Transform> creatures;
    private int simCount;

    private void Start()
    {
        fittestGenomes = new Genome[10];
        for (int i = 0; i < fittestGenomes.Length; i++)
        {
            fittestGenomes[i] = new Genome();
            fittestGenomes[i].Randomize();
        }

        StartCoroutine(SimTick());
    }

    IEnumerator SimTick()
    {
        creatures = new List<Transform>();
        foreach (Genome genome in fittestGenomes)
        {
            for (int i = 0; i < 10; i++)
            {
                Transform b = Instantiate<Transform>(Body);
                creatures.Add(b);
                Genome g = genome.Clone();
                g.Mutate();
                b.GetComponent<Body>().Genome = g;
            }
            {
                Transform b = Instantiate<Transform>(Body);
                creatures.Add(b);
                Genome g = genome.Clone();
                b.GetComponent<Body>().Genome = g;
            }
        }
        for (int i = 0; i < 10; i++)
        {
            Transform b = Instantiate<Transform>(Body);
            creatures.Add(b);
            Genome g = new Genome();
            g.Randomize();
            b.GetComponent<Body>().Genome = g;
        }
        yield return new WaitForSeconds(20 + simCount);

        fittestGenomes = creatures.OrderBy(t => t.position.x).Take(5).Select(t => t.GetComponent<Body>().Genome).ToArray();
        foreach (Transform cr in creatures)
        {
            Destroy(cr.gameObject);
        }
        StartCoroutine(SimTick());
        Debug.Log("NextGen");
        simCount++;
    }
}