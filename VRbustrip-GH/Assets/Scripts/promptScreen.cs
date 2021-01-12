using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class promptScreen : MonoBehaviour
{
    public string[] prompts;
    public string displayedPrompt;
    public TextMeshPro displaySpace;
    public float switchTime = 5f;

    private void Start()
    {
        displaySpace = GetComponent<TextMeshPro>();

        StartCoroutine(PromptAndWait());
    }

    IEnumerator PromptAndWait()
    {
        while (true)
        {
            displayedPrompt = prompts[Random.Range(0, prompts.Length)];
            displaySpace.text = displayedPrompt;
            yield return new WaitForSeconds(switchTime);
        }
    }
}
