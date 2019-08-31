using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public static GameManager instance = null;

    public GameObject NextPhasePanel;
    private Animator NextPhasePanelAnimator;


    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }

        //DontDestroyOnLoad(gameObject);
    }


    public void ShowPanel()
    {
        NextPhasePanelAnimator = NextPhasePanel.GetComponent<Animator>();
        NextPhasePanel.SetActive(true);
        NextPhasePanelAnimator.SetBool("NextPhaseAnime", true);
    }

    public void NextScene()
    {

        if (SceneManager.GetActiveScene().buildIndex < 20)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        
    }

}
