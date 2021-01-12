using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Opdracht2Main : MonoBehaviour
{
    public static bool opdracht2HasFinished;
    public GameObject cube;
    public GameObject collisionPrefab;
    public static int colliderInt;
    public GameObject[] collisionPlaces;

    private void Awake()
    {
        foreach(GameObject place in collisionPlaces)
        {
            Instantiate(collisionPrefab, place.transform.position, Quaternion.identity);
        }
    }
    private void Update()
    {
        if (Opdracht1.Opdracht1HasFisnished)
        {
            if (colliderInt == 2)
            {
                cube.transform.localScale = new Vector3(0.006f, 0.007f, 0.0003f);
            }
            else if (colliderInt == 4)
            {
                cube.transform.localScale = new Vector3(0.006f, 0.007f, 0.0055f);
            }
            else if (colliderInt == 8)
            {
                cube.transform.localScale = new Vector3(0.006f, 0.007f, 0.0085f);
                opdracht2HasFinished = true;
                StaticVariables.fasterMovement = true;
                colliderInt++;
            }
            else if (colliderInt > 8)
            {
                cube.transform.localScale = new Vector3(0.006f, 0.007f, 0.0085f);
            }
        }
    }
}
