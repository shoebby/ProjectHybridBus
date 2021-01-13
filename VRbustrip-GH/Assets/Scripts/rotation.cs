using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotation : MonoBehaviour
{
    void Update()
    {
        transform.Rotate(0, 15, 0 * Time.deltaTime); //rotates 50 degrees per second around z axis
    }
}
