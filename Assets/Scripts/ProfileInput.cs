using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ProfileInput : MonoBehaviour
{
    public TMP_InputField inputName; // Assign this in the Inspector
    public TMP_Text profileName; // Assign this in the Inspector
    public TMP_InputField inputEmail; // Assign this in the Inspector
    public TMP_Text profileEmail; // Assign this in the Inspector
    public TMP_Text errorText; // Assign this in the Inspector
    private const string UsernameKey = "Username";
    private const string EmailKey = "Email";
    public GameObject MainPanel; // Assign this in the Inspector
    public GameObject profilePanel; // Assign this in the Inspector


    void Start()
    {
        // PlayerPrefs.DeleteAll();
        LoadProfileInfo();
    }


    // This method will be called when the button is clicked
    public void UpdateProfileInfo()
    {
        if (inputName != null && profileName != null)
        {
            if (string.IsNullOrWhiteSpace(inputName.text))
            {
                ShowError("Username cannot be empty!");
            }
            else
            {
                string username = inputName.text;
                profileName.text = username;
                PlayerPrefs.SetString(UsernameKey, username); // Store the username
                PlayerPrefs.Save(); // Ensure the data is written to disk

                ClearError();
                ShowMainPanel();
            }

            
        }

        if (inputEmail != null && profileEmail != null)
        {
            if (string.IsNullOrWhiteSpace(inputEmail.text))
            {
                ShowError("Email cannot be empty!");
            }
            else
            {
                string email = inputEmail.text;
                profileEmail.text = email;
                PlayerPrefs.SetString(EmailKey, email); // Store the username
                PlayerPrefs.Save(); // Ensure the data is written to disk
               
                ClearError();
                
            }

            
        }

    }


    private void ShowError(string message)
    {
        if (errorText != null)
        {
            errorText.text = message;
            errorText.gameObject.SetActive(true); // Make sure the error text is visible
        }
    }

    private void ClearError()
    {
        if (errorText != null)
        {
            errorText.text = "";
            errorText.gameObject.SetActive(false); // Hide the error text
        }
    }


    private void LoadProfileInfo()
    {
        if (PlayerPrefs.HasKey(UsernameKey))
        {
            string username = PlayerPrefs.GetString(UsernameKey);
            profileName.text = username;
            inputName.text = username; // Optional: Display the stored name in the input field
        }

        if (PlayerPrefs.HasKey(EmailKey))
        {
            string username = PlayerPrefs.GetString(UsernameKey);
            profileEmail.text = username;
            inputEmail.text = username; // Optional: Display the stored name in the input field
            ShowMainPanel(); // Show the panel if a username is stored
        }

        else
        {
            ShowError("enter your Info!");
        }
    }


    private void ShowMainPanel()
    {
        if (MainPanel != null)
        {
            MainPanel.SetActive(true); // Make sure the profile panel is visible
            profilePanel.SetActive(false);
        }
    }


}
