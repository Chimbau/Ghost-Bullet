using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MenuControl : MonoBehaviour
{
    public string nextScene;
    public static bool isPaused;
    public GameObject pauseMenuUI;

    private void Update() {
        if(Input.GetKeyDown(KeyCode.Escape)) {
            if(isPaused){
                Resume();
            } else {
                Pause();
            }
        }
    }
    
    public void changeScene () {
        SceneManager.LoadScene(nextScene);
    }

    public void quitApplication () {
        Application.Quit();
    }

    public void Resume() {
        pauseMenuUI.SetActive(false);
        isPaused = false;
        Time.timeScale = 1f;
    }

    public void Pause() {
        pauseMenuUI.SetActive(true);
        isPaused = true;
        Time.timeScale = 0f;
    }
}

