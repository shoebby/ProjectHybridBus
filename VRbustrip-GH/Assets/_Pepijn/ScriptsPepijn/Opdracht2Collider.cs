using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Opdracht2Collider : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Interactible")
        {
            Opdracht2Main.colliderInt++;
        }
    }
}
