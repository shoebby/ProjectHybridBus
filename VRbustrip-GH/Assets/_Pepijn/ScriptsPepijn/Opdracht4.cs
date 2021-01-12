using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Opdracht4 : MonoBehaviour
{
    public GameObject cube;
    public bool opdracht4IsFinisht;
    private int counter = 0;

    private void OnTriggerExit(Collider other)
    {

        if (other.tag == "Player" && Opdracht1.Opdracht1HasFisnished && counter == 0)
        {
            opdracht4IsFinisht = true;
            StaticVariables.fasterMovement = true;
            cube.transform.localScale = new Vector3(0.006f, 0.007f, 0.0085f);
            counter++;
        }
    }
}
