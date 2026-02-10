using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneNavigator : MonoBehaviour
{
    public string homeScene = "HomeScene";
    public Image sceneImage; 
    public Sprite[] sceneSprites; 
    
    private int currentSceneIndex;
    private string[] scenes;

    void Start()
    {
        
        scenes = new string[SceneManager.sceneCountInBuildSettings];
        for (int i = 0; i < scenes.Length; i++)
        {
            scenes[i] = System.IO.Path.GetFileNameWithoutExtension(SceneUtility.GetScenePathByBuildIndex(i));
        }
        
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        UpdateSceneImage();
    }

    public void LoadNextScene()
    {
        currentSceneIndex = (currentSceneIndex + 1) % scenes.Length;
        SceneManager.LoadScene(scenes[currentSceneIndex]);
    }

    public void LoadPreviousScene()
    {
        currentSceneIndex = (currentSceneIndex - 1 + scenes.Length) % scenes.Length;
        SceneManager.LoadScene(scenes[currentSceneIndex]);
    }

    public void LoadHomeScene()
    {
        SceneManager.LoadScene(homeScene);
    }
    public void LoadSpecificScene(string SceneName)
    {
        SceneManager.LoadScene(SceneName);
    }

    public void UpdateSceneImage()
    {
        if (sceneImage != null && sceneSprites.Length > currentSceneIndex)
        {
            sceneImage.sprite = sceneSprites[currentSceneIndex];
        }
    }
}