using UnityEngine;

public class CrowdManager : MonoBehaviour
{
    public GameObject[] npcCrowd;
    private int activeCount = 0;
    private bool isCrowdVisible = true; // Controls crowd visibility

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        foreach(GameObject npc in npcCrowd)
        {
            npc.SetActive(false);
        }
        
    }

    public void IncreaseCrowd()
    {
        if (activeCount < npcCrowd.Length)
        {
            npcCrowd[activeCount].SetActive(true);
            activeCount++;
        }
    }

    public void DecreaseCrowd()
    {
        if (activeCount > 0)
        {
            activeCount--;
            npcCrowd[activeCount].SetActive(false);
        }
    }

    public void ToggleCrowdVisibility()
    {
        isCrowdVisible = !isCrowdVisible; // Toggle visibility state

        for (int i = 0; i < activeCount; i++)
        {
            npcCrowd[i].SetActive(isCrowdVisible);
        }
    }
}
