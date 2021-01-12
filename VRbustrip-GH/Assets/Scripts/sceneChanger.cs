using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneChanger : MonoBehaviour
{
    public Animator transition;
    public float transitionTime = 2f;
    public GameObject levelLoader;
    public string sceneName;

    private void Start()
    {
        levelLoader = GameObject.FindGameObjectWithTag("levelLoader");
        transition = levelLoader.GetComponentInChildren<Animator>();
    }

    public void SceneChange(string sceneName)
    {
        StartCoroutine(SceneChangeCoroutine(sceneName));

    }

    IEnumerator SceneChangeCoroutine(string sceneName)
    {
        transition.SetTrigger("start");

        yield return new WaitForSeconds(transitionTime);
        
        SceneManager.LoadScene(sceneName);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            StartCoroutine(SceneChangeCoroutine(sceneName));
        }
    }
}