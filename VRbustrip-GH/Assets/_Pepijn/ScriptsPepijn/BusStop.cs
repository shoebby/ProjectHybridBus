using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BusStop : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "BusStop")
        {
            StaticVariables.moveSpeed = 0;
        }
    }
}
