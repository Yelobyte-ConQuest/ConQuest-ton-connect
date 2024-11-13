using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{
   
    public GameObject eventPage;
    public GameObject gameexpoPage;
    public GameObject adventurerPage;
    public GameObject treasureHuntPage;
    public GameObject LoginUI;
    public GameObject SignupUI;
    public GameObject MainPanel;
    public GameObject InputSignupUI;

    

    public void EventInfo()
    {
        eventPage.SetActive(true);
        gameexpoPage.SetActive(false);
        adventurerPage.SetActive(false);
        treasureHuntPage.SetActive(false);
        MainPanel.SetActive(false);
    }


    public void GameExpo()
    {
        eventPage.SetActive(false);
        gameexpoPage.SetActive(true);
        adventurerPage.SetActive(false);
        treasureHuntPage.SetActive(false);
    }


    public void Menu()
    {
        eventPage.SetActive(false);
        gameexpoPage.SetActive(false);
        adventurerPage.SetActive(false);
        treasureHuntPage.SetActive(false);
        MainPanel.SetActive(true);
    }

    public void AdventureGame()
    {
        eventPage.SetActive(false);
        gameexpoPage.SetActive(false);
        adventurerPage.SetActive(true);
        MainPanel.SetActive(false);
    }

    public void TreasureGame()
    {
        treasureHuntPage.SetActive(true);
        eventPage.SetActive(false);
        MainPanel.SetActive(false);
        gameexpoPage.SetActive(false);
        
       
    }

    public void Tickets()
    {
        Application.OpenURL("https://tix.africa/gameexpo24");
    }

    public void EventScene()
    {
        SceneManager.LoadScene("Events page");
    }

    public void HomeScene()
    {
        SceneManager.LoadScene("Main");
    }

    public void tropicalBlend()
    {
        SceneManager.LoadScene("TropicalBlend");
    }

    public void SubAttack()
    {
        SceneManager.LoadScene("SubAttack");
    }

    public void SignupPage()
    {
        LoginUI.SetActive(false);
        SignupUI.SetActive(true);

    }

    public void LoginPage()
    {
        LoginUI.SetActive(true);
        SignupUI.SetActive(false);

    }

    public void Enter()
    {
        InputSignupUI.SetActive(false);
        MainPanel.SetActive(true);
        

    }

    public void CloseApplication()
    {
        Application.Quit();
    }
}
