using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Opdracht2Main : MonoBehaviour
{
    public bool opdracht2IsFinisht;
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
        if (colliderInt == 2)
        {
            cube.transform.localScale = new Vector3(0.3f, 0.3f, 0.1f);
        }
        else if (colliderInt == 4)
        {
            cube.transform.localScale = new Vector3(0.6f, 0.3f, 0.1f);
        }
        else if (colliderInt == 6)
        {
            cube.transform.localScale = new Vector3(1f, 0.3f, 0.1f);
            opdracht2IsFinisht = true;
        }
    }
}
