using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneChanger : MonoBehaviour
{
    public Animator transition;
    public float transitionTime = 2f;

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
}