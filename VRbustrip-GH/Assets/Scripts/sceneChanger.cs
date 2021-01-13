using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.SceneManagement;

public class sceneChanger : MonoBehaviour
{
    public Animator transition;
    public float transitionTime = 2f;
    public GameObject levelLoader;
    public string sceneName;

    public XRNode inputSource;
    private bool buttonPressed = false;

    private void Start()
    {
        levelLoader = GameObject.FindGameObjectWithTag("levelLoader");
        transition = levelLoader.GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        InputDevice device = InputDevices.GetDeviceAtXRNode(inputSource);
        device.TryGetFeatureValue(CommonUsages.secondaryButton, out buttonPressed);

        if (buttonPressed)
        {
            StartCoroutine(SceneChangeCoroutine("destination"));
        }
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