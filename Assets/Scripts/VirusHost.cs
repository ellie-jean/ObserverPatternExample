// Authors: Ellie McDonald, Lance Graham, Trevor West and Rebecca Henry
// 03/28/2021

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirusHost : MonoBehaviour, ISubject
{
    public bool Infected { get; set; }

    private List<IObserver> aListOfObservers = new List<IObserver>();

    // Add an observer to the subjects radar
    public void AddObserver(IObserver anObserver)
    {
        aListOfObservers.Add(anObserver);
        anObserver.React(this.Infected);
    }

    // Not use cases yet
    public void Notify()
    {
        foreach (IObserver anObserver in aListOfObservers)
        {
            anObserver.React(this.Infected);
        }
    }

    // remove an observer to the subjects radar
    public void RemoveObserver(IObserver anObserver)
    {
        aListOfObservers.Remove(anObserver);

    }
}
