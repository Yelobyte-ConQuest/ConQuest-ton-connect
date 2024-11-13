using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Connect : MonoBehaviour
{

    public GameObject connectButton;
    public GameObject enterButton;
    public TMP_Text errorText;

    public void connectWallet()
    {
        connectButton.SetActive(false);
        enterButton.SetActive(true);
        errorText.text = "Connection Successful";
    }

    public void startApp()
    {
        SceneManager.LoadScene("Main");
    }


}
