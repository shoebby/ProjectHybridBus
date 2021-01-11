using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Opdracht3 : MonoBehaviour
{
    public GameObject cube;
    public bool opdracht3IsFinisht;
    public static int colliderPercentage;
    private int randomColliderInt;

    public static bool colliderActivated;
    public static bool collider1Activated;
    public static bool collider2Activated;

    private void Awake()
    {
        randomColliderInt = Random.Range(1, 3);
    }
    void Update()
    {
        if (colliderPercentage == 0)
        {
            cube.transform.localScale = new Vector3(0.25f, 0.3f, 0.1f);
        }
        else if (colliderPercentage == 1)
        {
            cube.transform.localScale = new Vector3(0.5f, 0.3f, 0.1f);
        }
        else if (colliderPercentage == 2)
        {
            cube.transform.localScale = new Vector3(0.75f, 0.3f, 0.1f);
        }
        else if (colliderPercentage == 3)
        {
            cube.transform.localScale = new Vector3(1f, 0.3f, 0.1f);
            opdracht3IsFinisht = true;
        }
        if(randomColliderInt == 1 && colliderActivated)
        {
            opdracht3IsFinisht = true;
        }
        else if (randomColliderInt == 1 && collider1Activated)
        {
            opdracht3IsFinisht = true;
        }
        else if (randomColliderInt == 1 && collider2Activated)
        {
            opdracht3IsFinisht = true;
        }
    }

}
