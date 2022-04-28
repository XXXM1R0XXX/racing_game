
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class paused : MonoBehaviour
{
    public float gg = 0;
    [SerializeField]
    GameObject pause;
    [SerializeField]
    GameObject menu;
    [SerializeField]
    GameObject lose;
    [SerializeField]
    GameObject win;

    void Start()
    {
        pause.SetActive(false);
        menu.SetActive(true);
        lose.SetActive(false);
        win.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pause.SetActive(true);
            Time.timeScale = 0;
        }
        if(gg==1)
        {
            win.SetActive(true);
            Time.timeScale = 0;
            gg = 0;
        }
        if (gg == 2)
        {
            lose.SetActive(true);
            Time.timeScale = 0;
            gg = 0;
        }
    }

    public void PauseOff()
    {
        pause.SetActive(false);
        Time.timeScale = 1;
        lose.SetActive(false);
        win.SetActive(false);
    }   

    public void Menu()
    {
        menu.SetActive(true);
        lose.SetActive(false);
        win.SetActive(false);
    }
    public void PlayGame()
    {
        menu.SetActive(false);
        lose.SetActive(false);
        win.SetActive(false);
    }
    public void Exit()
    {
        Application.Quit();
    }
}
