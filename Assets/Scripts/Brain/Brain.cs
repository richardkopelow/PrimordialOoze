using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Brain
{
    private Genome genome;
    private List<Link> links;
    private Neuron[] neurons;

    public Brain(Genome genome, List<Neuron> inputs, List<Neuron> outputs)
    {
        this.genome = genome;
        links = new List<Link>();
        neurons = new Neuron[genome.MaxNeurons];
        for (int i = 0; i < inputs.Count; i++)
        {
            neurons[i] = inputs[i];
        }
        for (int i = 0; i < outputs.Count; i++)
        {
            neurons[i + inputs.Count] = outputs[i];
        }

        foreach (Gene gene in genome)
        {
            try
            {
                Link link = new Link();
                link.Weight = gene.Weight;
                if (neurons[gene.Input] == null)
                {
                    neurons[gene.Input] = new Neuron();
                }
                Neuron input = neurons[gene.Input];
                link.Input = input;
                if (neurons[gene.Output] == null)
                {
                    neurons[gene.Output] = new Neuron();
                }
                Neuron output = neurons[gene.Output];
                output.Inputs.Add(link);
                links.Add(link);
            }
            catch
            {
                UnityEngine.Debug.Log("Error");
            }
        }
    }

    public void Update()
    {
        foreach (Link link in links)
        {
            link.Update();
        }
        foreach (Neuron neuron in neurons)
        {
            if (neuron!=null)
            {
                neuron.Update();
            }
        }
    }
}
