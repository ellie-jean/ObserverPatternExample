// Authors: Ellie McDonald, Lance Graham, Trevor West and Rebecca Henry
// 03/28/2021

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Person : MonoBehaviour, IObserver
{
    public bool Infected { get; set; } = false;

    // react to being infected or healed by a host
    public void React(bool infected)
    {
        this.Infected = infected; 

        // Change color to relect infection status
        if (this.Infected)
        {
            this.gameObject.GetComponent<Renderer>().material = Resources.Load<Material>("InfectedColor");
        }
        else if(!(this.Infected))
        {
            this.gameObject.GetComponent<Renderer>().material = Resources.Load<Material>("NonInfectedColor");
        }
    }
}
