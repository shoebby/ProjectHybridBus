using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentSpawnScript : MonoBehaviour
{
    [SerializeField]
    private GameObject[] environments1;
    [SerializeField]
    private GameObject[] environments2;
    [SerializeField]
    private GameObject[] environments3;
    [SerializeField]
    private GameObject BusStop;
    private int lastInstantiated = 1000;
    private int instantiateInt;
    private int environmentInt;
    private void InstantiateEnvironment()
    {
        if (environmentInt < 8)
        {
            while (instantiateInt == lastInstantiated)
            {
                instantiateInt = Random.Range(0, 3);
            }
            lastInstantiated = instantiateInt;
            Instantiate(environments1[instantiateInt], transform.position, Quaternion.identity);
        }
        else if (environmentInt < 16)
        {
            while (instantiateInt == lastInstantiated)
            {
                instantiateInt = Random.Range(0, 3);
            }
            lastInstantiated = instantiateInt;
            Instantiate(environments2[instantiateInt], transform.position, Quaternion.identity);
        }
        else if (environmentInt < 24)
        {
            while (instantiateInt == lastInstantiated)
            {
                instantiateInt = Random.Range(0, 3);
            }
            lastInstantiated = instantiateInt;
            Instantiate(environments3[instantiateInt], transform.position, Quaternion.identity);
        }

        else if(environmentInt < 25)
        {
            Instantiate(BusStop, transform.position, Quaternion.identity);
            environmentInt = 0;
        }
        environmentInt++;
    }

    public void OnTriggerExit(Collider other)
    {
        InstantiateEnvironment();
    }
}
