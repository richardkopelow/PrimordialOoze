using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Genome : IEnumerable<Gene>
{
    public int MaxNeurons { get; set; }

    private List<Gene> genes;

    public Genome()
    {
        genes = new List<Gene>();
    }

    public Gene this[int index]
    {
        get { return genes[0]; }
    }

    public IEnumerator<Gene> GetEnumerator()
    {
        return ((IEnumerable<Gene>)genes).GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return ((IEnumerable<Gene>)genes).GetEnumerator();
    }

    public void Randomize()
    {
        MaxNeurons = (int)(Random.value * 20) + 7;
        int newGenes = (int)(Random.value * 10);
        int deleteGenes = (int)(Random.value * 5);
        for (int i = 0; i < newGenes; i++)
        {
            genes.Add(randomGene());
        }
        for (int i = 0; i < deleteGenes && genes.Count > 2; i++)
        {
            int index = (int)(Random.value * genes.Count);
            genes.RemoveAt(index);
        }
    }

    public Genome Clone()
    {
        Genome geno = new Genome();
        geno.MaxNeurons = MaxNeurons;
        geno.genes.AddRange(genes);

        return geno;
    }

    public void Mutate()
    {
        MaxNeurons += (int)(Random.value * 21) - 10;
        if (MaxNeurons<10)
        {
            MaxNeurons = 10;
        }
        for (int i = 0; i < genes.Count; i++)
        {
            Gene g = genes[i];
            g.Input %= MaxNeurons;
            g.Output %= MaxNeurons;
            genes[i] = g;
        }
        for (int i = 0; i < genes.Count / 20; i++)
        {
            int index = (int)(Random.value * genes.Count);
            Gene g = genes[index];
            g.Weight += Random.value * 0.2 - 0.1;
            genes[index] = g;
        }
        int newGenes = (int)(Random.value * 10);
        int deleteGenes = (int)(Random.value * 8);
        for (int i = 0; i < newGenes; i++)
        {
            genes.Add(randomGene());
        }
        for (int i = 0; i < deleteGenes && genes.Count > 2; i++)
        {
            int index = (int)(Random.value * genes.Count);
            genes.RemoveAt(index);
        }
    }

    private Gene randomGene()
    {
        Gene g = new Gene
        {
            Weight = Random.value * 2 - 1,
            Input = (int)(Random.value * 0.99 * (MaxNeurons)),
            Output = (int)(Random.value * 0.99 * (MaxNeurons))
        };
        return g;
    }
}
