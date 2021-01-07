using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentMove : MonoBehaviour
{
    //Position
    private Vector3 currentPosition;
    private Vector3 desiredPosition;

    //Speed
    private float moveSpeed;

    void Update()
    {
        currentPosition = transform.position;
        moveSpeed = StaticVariables.moveSpeed;
        desiredPosition = (currentPosition + new Vector3(0, 0 , moveSpeed));
    }
    private void LateUpdate()
    {
        transform.position = desiredPosition;
    }
}
