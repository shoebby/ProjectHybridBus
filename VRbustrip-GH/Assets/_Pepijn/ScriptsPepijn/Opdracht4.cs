using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Opdrach4 : MonoBehaviour
{
    public GameObject cube;
    public bool opdracht4IsFinisht;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            opdracht4IsFinisht = true;
        }
    }
}
