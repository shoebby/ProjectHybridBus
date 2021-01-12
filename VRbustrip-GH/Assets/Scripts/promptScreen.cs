using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class promptScreen : MonoBehaviour
{
    public string[] prompts;
    public string[] opdrachten;
    public string displayedTekst;
    public TextMeshPro displaySpace;
    public float switchTimePrompt = 5f;
    public float switchTimeOpdracht = 10f;
    private int counter = 0;

    private void Awake()
    {
        displaySpace = GetComponent<TextMeshPro>();
    }
    private void Start()
    {
        StartCoroutine(PromptAndWait());
    }

    IEnumerator PromptAndWait()
    {
        while (true)
        {
            if(counter == 2)
            {
                displayedTekst = opdrachten[((counter / 2) - 1)];
                displaySpace.text = displayedTekst;
                yield return new WaitForSeconds(switchTimeOpdracht);
            }
            else if(counter == 4)
            {
                displayedTekst = opdrachten[((counter / 2) - 1)];
                displaySpace.text = displayedTekst;
                yield return new WaitForSeconds(switchTimeOpdracht);
            }
            else if(counter == 6)
            {
                displayedTekst = opdrachten[((counter / 2) - 1)];
                displaySpace.text = displayedTekst;
                yield return new WaitForSeconds(switchTimeOpdracht);
            }
            else
            {
                displayedTekst = prompts[Random.Range(0, prompts.Length)];
                displaySpace.text = displayedTekst;
                yield return new WaitForSeconds(switchTimePrompt);
            }
            counter++;
        }
    }
}
