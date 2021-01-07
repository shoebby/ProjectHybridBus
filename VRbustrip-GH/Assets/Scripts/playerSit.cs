using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerSit : MonoBehaviour
{
    public GameObject player;
    public GameObject standPos;
    public GameObject sitPos;


    public void SitDown()
    {
        player.GetComponent<continuousMovement>().enabled = false;
        player.transform.position = sitPos.transform.position;
        player.transform.rotation = sitPos.transform.rotation;
    }

    public void StandUp()
    {
        player.transform.position = standPos.transform.position;
        player.GetComponent<continuousMovement>().enabled = true;
    }
}
