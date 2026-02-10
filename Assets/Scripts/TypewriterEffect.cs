using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TypewriterEffect : MonoBehaviour
{
    public Text uiText;  
    public float delay = 0.05f;

    private string originalText;  

    private void Start()
    {
        if (uiText != null)
        {
            originalText = uiText.text;  
            StartCoroutine(ShowText());
        }
        else
        {
            Debug.LogError("Text component is not assigned!");
        }
    }

    IEnumerator ShowText()
    {
        uiText.text = "";  
        foreach (char letter in originalText)
        {
            uiText.text += letter;
            yield return new WaitForSeconds(delay);
        }
    }
}
