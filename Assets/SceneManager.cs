using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManager : MonoBehaviour
{
    // Start is called before the first frame update
    public void LoadScene(string sceneName)
    {
        StartCoroutine(LoadSceneAsync(sceneName));
    }

    private IEnumerator LoadSceneAsync(string sceneName)
    {
        AsyncOperation asyncLoad = UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(sceneName);
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }

    private void UnloadScene(string sceneName)
    {
        UnityEngine.SceneManagement.SceneManager.UnloadSceneAsync(sceneName);
    }

    // Function to load the start scene
    public void LoadStartScene()
    {
        UnloadScene("SampleScene");
        LoadScene("StartScene");
    }

    // Function to load the game scene
    public void LoadGameScene()
    {
        UnloadScene("StartScene");
        LoadScene("SampleScene");
    }

    // Function to exit the game
    public void ExitGame()
    {
        Application.Quit();
    }
}
