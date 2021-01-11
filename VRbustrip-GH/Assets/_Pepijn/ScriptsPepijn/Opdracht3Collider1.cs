using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Opdracht3Collider1 : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Collider1")
        {
            Opdracht3.colliderPercentage++;
            Opdracht3.collider1Activated = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Collider1")
        {
            Opdracht3.colliderPercentage--;
            Opdracht3.collider1Activated = false;
        }
    }
}
