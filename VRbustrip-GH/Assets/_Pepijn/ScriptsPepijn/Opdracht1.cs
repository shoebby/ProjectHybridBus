using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Opdracht1 : MonoBehaviour
{
    private int triggerCounter;
    public GameObject cube;
    public bool opdracht1IsFinisht;
    private void Update()
    {
        if (triggerCounter == 2)
        {
            cube.transform.localScale = new Vector3(0.3f, 0.3f, 0.1f);
        }
        else if (triggerCounter == 4)
        {
            cube.transform.localScale = new Vector3(0.6f, 0.3f, 0.1f);
        }
        else if (triggerCounter == 6)
        {
            cube.transform.localScale = new Vector3(1f, 0.3f, 0.1f);
            opdracht1IsFinisht = true;
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
