using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuNav : MonoBehaviour
{
    public GameObject PlayMenu;
    public GameObject PauseMenu;
    public EnemyManager Enemy;
    public GameObject RetryUI;
    public GameObject Pausebutton;

    

    public void play()
    {
        PlayMenu.SetActive(false);
        Enemy.Spawn();
        Pausebutton.SetActive(true);
    }

    public void Pause()
    {
        PauseMenu.SetActive(true);
        Time.timeScale = 0f;
    }

    public void Continue()
    {
        PauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }

    public void Endgame()
    {
        RetryUI.SetActive(true);

    }

    public void Retry()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
