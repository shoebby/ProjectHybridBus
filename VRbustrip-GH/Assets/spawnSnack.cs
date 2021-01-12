using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnSnack : MonoBehaviour
{
    public GameObject snack;
    public Transform instantiationPos;

    private void Start()
    {
        Instantiate(snack, instantiationPos.position, instantiationPos.rotation);
    }
    public void SpawnSnack()
    {
        Instantiate(snack, instantiationPos.position, instantiationPos.rotation);
    }
}
