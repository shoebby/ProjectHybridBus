using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentDelete : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject);
    }
}
