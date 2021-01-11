using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Opdracht3Collider : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Collider")
        {
            Opdracht3.colliderPercentage++;
            Opdracht3.colliderActivated = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Collider")
        {
            Opdracht3.colliderPercentage--;
            Opdracht3.colliderActivated = false;
        }
    }
}
