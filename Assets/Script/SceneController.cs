using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class SceneController : MonoBehaviour
{
    public Slider loadingSlider;
    public GameObject loadingScreen;

    public void SceneLoader(string sceneName)
    {
        StartCoroutine(LoadingScreen(sceneName));
    }
    IEnumerator LoadingScreen(string sceneName)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneName);
        loadingScreen.SetActive(true);
        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / 0.9f);
            loadingSlider.value = progress;
            yield return null;

        }
    }


    public void QuitGame()
    {
        Application.Quit();
        
    }
    
}
