using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Opdracht1 : MonoBehaviour
{
    private int triggerCounter;
    public GameObject cube;
    public bool opdracht1IsFinisht;
    public static bool Opdracht1HasFisnished;
    private void Update()
    {
        if (triggerCounter == 2)
        {
            cube.transform.localScale = new Vector3(0.006f, 0.007f, 0.0003f);
        }
        else if (triggerCounter == 4)
        {
            cube.transform.localScale = new Vector3(0.006f, 0.007f, 0.0055f);
        }
        else if (triggerCounter == 8)
        {
            cube.transform.localScale = new Vector3(0.006f, 0.007f, 0.0085f);
            opdracht1IsFinisht = true;
            triggerCounter++;
            StaticVariables.fasterMovement = true;
        }
        else if (triggerCounter > 8)
        {
            cube.transform.localScale = new Vector3(0.006f, 0.007f, 0.0085f);
        }
    }
    private void Start()
    {
        opdracht1IsFinisht = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Interactible")
        {
            triggerCounter++;
            Debug.Log("hi");
        }
    }
}
