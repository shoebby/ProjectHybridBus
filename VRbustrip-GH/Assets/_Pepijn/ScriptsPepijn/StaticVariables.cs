using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticVariables : MonoBehaviour
{
    [SerializeField]
    public static float moveSpeed = 0.1f;
    [SerializeField]
    public static float fasterMovementSpeed = 0.15f;
    [SerializeField]
    public static bool fasterMovement;
    public float fasterMoveTime;
    public float speed;

    private float timer;
    public void Update()
    {
        
        if(!fasterMovement)
        {
            if (Input.GetKeyDown("space"))
            {
                fasterMovement = true;
            }
        }
        if (fasterMovement)
        {
            if (timer < 0)
            {
                fasterMovement = false;
                timer = fasterMoveTime;
                moveSpeed = 0.1f;
            }
            else
            {
                timer -= Time.deltaTime;
                moveSpeed = fasterMovementSpeed;
            }
        }
        speed = moveSpeed;
    }
}
