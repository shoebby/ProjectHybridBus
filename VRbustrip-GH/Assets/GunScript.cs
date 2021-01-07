using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunScript : MonoBehaviour
{
    public float bulletSpeed = 40;
    public GameObject bullet;
    public Transform barrel;
    public AudioSource source;
    public AudioClip gunShotClip;

    public void Fire()
    {
        GameObject spawnedBullet = Instantiate(bullet, barrel.position, barrel.rotation);
        spawnedBullet.GetComponent<Rigidbody>().velocity = bulletSpeed * barrel.forward;
        source.PlayOneShot(gunShotClip);
        Destroy(spawnedBullet, 2);
    }
}
