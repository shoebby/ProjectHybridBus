using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Opdracht3Collider2 : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Collider2")
        {
            Opdracht3.colliderPercentage++;
            Opdracht3.collider2Activated = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Collider2")
        {
            Opdracht3.colliderPercentage--;
            Opdracht3.collider2Activated = false;
        }
    }
}
