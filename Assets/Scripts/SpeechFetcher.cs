using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Networking;
using System.Collections;

public class SpeechManager : MonoBehaviour
{
    public Text speechText; // Assign in Inspector
    public string apiURL = "https://randomuser.me/api/"; // Replace with actual API URL

    void Start()
    {
        StartCoroutine(FetchSpeechText());
    }

    IEnumerator FetchSpeechText()
    {
        using (UnityWebRequest request = UnityWebRequest.Get(apiURL))
        {
            yield return request.SendWebRequest();

            if (request.result == UnityWebRequest.Result.Success)
            {
                string jsonResponse = request.downloadHandler.text;
                SpeechData speechData = JsonUtility.FromJson<SpeechData>(jsonResponse);
                Debug.Log(jsonResponse);

                speechText.text = jsonResponse;
            }
            else
            {
                speechText.text = "Error loading speech text.";
                Debug.LogError("Error fetching speech: " + request.error);
            }
        }
    }
}

[System.Serializable]
public class SpeechData
{
    public string speech;
}