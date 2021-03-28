// Authors: Ellie McDonald, Lance Graham, Trevor West and Rebecca Henry
// 03/28/2021

using System;
using UnityEngine;
using UnityEngine.AI;

public class PersonDestination : MonoBehaviour
{
    // Game objects of the hosts
    GameObject infectHost;
    GameObject nonInfectedHost;

    // Positions of the host
    Vector3 infectedHostPosition;
    Vector3 nonInfectedHostPosition;

    // Current location and destination of the given "person"
    Vector3 currectDesition;
    Vector3 currectLocation;

    // Start is called before the first frame update
    void Start()
    {
        // Setting the host game objects
        infectHost = GameObject.Find("Infected Host");
        nonInfectedHost = GameObject.Find("Healing Host");

        // Setting the host's position
        infectedHostPosition = GameObject.Find("Infected Host").transform.position;
        nonInfectedHostPosition = GameObject.Find("Healing Host").transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        NavMeshAgent myNavMeshAgent = this.GetComponent<NavMeshAgent>();
        currectLocation = this.transform.position;

        // If person infected, go to the healer/uninfected host
        if (this.GetComponent<Person>().Infected)
        {
            myNavMeshAgent.SetDestination(nonInfectedHostPosition);
            currectDesition = nonInfectedHostPosition;
        }
        // If person is not infected, go to the infected host
        else if (!(this.GetComponent<Person>().Infected))
        {
            myNavMeshAgent.SetDestination(infectedHostPosition);
            currectDesition = infectedHostPosition;
        }

        // Calculating how far the capsule is away from it's destination
        double distance = Math.Abs(Math.Pow(Math.Pow((currectDesition.x - currectLocation.x), 2) + Math.Pow((currectDesition.z - currectLocation.z), 2), .5));

        // Capsule is moving towards healer host, is within 2 meters
        if (distance < 2 && this.GetComponent<Person>().Infected) 
        {
            nonInfectedHost.GetComponent<VirusHost>().AddObserver(this.GetComponent<Person>());
        }
        // Capsule is moving towards healer host, but isn't close enough to be a observer of the healer
        else if (distance > 3 && this.GetComponent<Person>().Infected)
        {
            nonInfectedHost.GetComponent<VirusHost>().RemoveObserver(this.GetComponent<Person>());
        }
        // Capsule is moving towards the infected host, is within 2 meters
        else if (distance < 2 && !(this.GetComponent<Person>().Infected)) 
        {
            infectHost.GetComponent<VirusHost>().AddObserver(this.GetComponent<Person>());
        }
        // Capsule is moving towards infected host, but isn't close enough to be a observer of the healer
        else if (distance > 3 && !(this.GetComponent<Person>().Infected)) 
        {
            infectHost.GetComponent<VirusHost>().RemoveObserver(this.GetComponent<Person>());
        }

    }
}
