using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class Level : MonoBehaviour
{
    [SerializeField] int waitSec = 1;
    int currentSceneIndex;

    // Start is called before the first frame update
    void Start()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        if (currentSceneIndex == 0)
        {
            StartCoroutine(WaitForTime());
        }   
    }

    IEnumerator WaitForTime()
    {
        yield return new WaitForSeconds(waitSec);
        LoadNextScene();
    }    

    public void LoadNextScene()
    {
        SceneManager.LoadScene(currentSceneIndex + 1);
    }

    public void RestartScene()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Level 1");
    }

    public void LoadMainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Start Screen");
    }

    public void LoadLooseScreen()
    {
        SceneManager.LoadScene("Loose Screen");
    }

    public void LoadOptionsScreen()
    {
        SceneManager.LoadScene("Options Screen");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
