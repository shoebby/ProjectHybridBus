using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playRandomClip : MonoBehaviour
{
    public AudioClip[] audioClips;
    public AudioSource source;

    public void PickRandomClip()
    {
        AudioClip chosenClip = audioClips[Random.Range(0,audioClips.Length)];
        source.PlayOneShot(chosenClip);
    }
}
