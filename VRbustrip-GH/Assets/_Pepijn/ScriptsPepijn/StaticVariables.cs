using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticVariables : MonoBehaviour
{
    public static float moveSpeed;
    public static bool fasterMovement;
    public float fasterMoveTime;

    [SerializeField]
    public float speed;
    public float fasterSpeed;

    private float timer;
    public void Update()
    {
        if(!fasterMovement)
        {
            moveSpeed = speed;
            if (Input.GetKeyDown("space"))
            {
                fasterMovement = true;
            }
        }
        else
        {
            if (timer < 0)
            {
                fasterMovement = false;
                timer = fasterMoveTime;

            }
            else
            {
                timer -= Time.deltaTime;
                moveSpeed = fasterSpeed;
            }
        }
    }
}
