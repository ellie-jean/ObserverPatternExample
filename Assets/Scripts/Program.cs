// Authors: Ellie McDonald, Lance Graham, Trevor West and Rebecca Henry
// 03/28/2021

using System;
using UnityEngine;
using UnityEngine.AI;

public class Program : MonoBehaviour
{
    // Positions of the infected and uninfected hosts
    Vector3 infectedHostPosition = new Vector3(10, 0, 10);
    Vector3 nonInfectedHostPosition = new Vector3(-10, 0, -10);

    private float scale = 2f;
    void Start()
    {
        // Creates the "People" that will be infected
        for (int index = 0; index < 8; index++)
        {
            GameObject aPerson = GameObject.CreatePrimitive(PrimitiveType.Capsule);
            aPerson.AddComponent<NavMeshAgent>();
            aPerson.AddComponent<Person>();
            aPerson.AddComponent<PersonDestination>();
            aPerson.GetComponent<Renderer>().material = Resources.Load<Material>("NonInfectedColor");
            aPerson.transform.position = new Vector3(0, 0, 0);
            aPerson.transform.localScale = new Vector3(scale, scale, scale);
        }

        // Creates that host that will infect people
        GameObject anInfected = GameObject.CreatePrimitive(PrimitiveType.Cube);
        anInfected.name = "Infected Host";
        anInfected.AddComponent<NavMeshAgent>();
        anInfected.AddComponent<VirusHost>().Infected = true;
        anInfected.GetComponent<Renderer>().material = Resources.Load("InfectedColor") as Material;
        anInfected.transform.position = infectedHostPosition;
        anInfected.transform.localScale = new Vector3(scale, scale, scale);

        // Create the host that was heal/uninfect people
        GameObject aHealer = GameObject.CreatePrimitive(PrimitiveType.Cube);
        aHealer.name = "Healing Host";
        aHealer.AddComponent<NavMeshAgent>();
        aHealer.AddComponent<VirusHost>().Infected = false;
        aHealer.GetComponent<Renderer>().material = Resources.Load("NonInfectedColor") as Material;
        aHealer.transform.position = nonInfectedHostPosition;
        aHealer.transform.localScale = new Vector3(scale, scale, scale);
    }
}
