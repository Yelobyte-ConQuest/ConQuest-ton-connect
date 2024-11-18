using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class RedeemCode : MonoBehaviour
{
    // Input field for the player to enter the code
    public TMP_InputField codeInputField;

    // Button to submit the code
    public Button redeemButton;

    // Text to display the player's points
    public TMP_Text pointsText;
    public TMP_Text pointsAddText;

    // Animated game object
    public Animator Score;

    // A dictionary to store valid codes and their corresponding points
    private Dictionary<string, (int points, GameObject uiElement)> validCodes = new Dictionary<string, (int, GameObject)>()
    {
        
        { "HG428", (1000, null) }, // Placeholder for special UI element 1
        { "IK222", (300, null) }, // Placeholder for special UI element 2
        { "GA024", (200, null) },
        { "ES124", (200, null) },
        { "CU083", (300, null) },
        { "GK234", (500, null) },
        { "EC093", (300, null) },
        { "OE430", (200, null) },
        { "TS220", (200, null) },
        { "CV450", (500, null) },
    };

    // Variable to track the player's total points
    private int playerPoints = 0000;
    private int playerAddPoints = 0000;

    void Start()
    {
        
        // Initialize the points display
        UpdatePointsText();

        


        // Add a listener to the redeem button
        redeemButton.onClick.AddListener(Redeem);


        validCodes["HG428"] = (1000, GameObject.Find("Holy Grail"));
        validCodes["IK222"] = (300, GameObject.Find("Ikenga"));
        validCodes["GA024"] = (200, GameObject.Find("Gye Nyame Amulet"));
        validCodes["ES124"] = (200, GameObject.Find("Enchanted Scroll of Secrets"));
        validCodes["CU083"] = (300, GameObject.Find("Crystal of Unity"));
        validCodes["GK234"] = (500, GameObject.Find("Golden Key of Opportunity"));
        validCodes["EC093"] = (300, GameObject.Find("Elixir of Creativity"));
        validCodes["OE430"] = (200, GameObject.Find("Orb of Enlightenment"));
        validCodes["TS222"] = (200, GameObject.Find("Talisman of Strength"));
        validCodes["CV450"] = (500, GameObject.Find("Crown of Victory"));

        // Ensure all UI elements start as inactive
        foreach (var code in validCodes)
        {
            if (code.Value.uiElement != null)
            {
                code.Value.uiElement.SetActive(false);
            }
        }
    }

    void Redeem()
    {
        string enteredCode = codeInputField.text;

        if (validCodes.ContainsKey(enteredCode))
        {
            // Add points for the redeemed code
            playerPoints += validCodes[enteredCode].points;
            playerAddPoints = validCodes[enteredCode].points;

            // Activate the associated UI element, if any
            if (validCodes[enteredCode].uiElement != null)
            {
                validCodes[enteredCode].uiElement.SetActive(true);
            }

            // Remove the code from the dictionary to prevent re-use
            validCodes.Remove(enteredCode);

            // Update the points display
            UpdatePointsText();

            Score.Play("Add");

            // Provide feedback to the player
            Debug.Log("Code redeemed successfully!");
        }
        else
        {
            // Provide feedback for an invalid or already used code
            Debug.Log("Invalid code or already redeemed.");
        }

        // Clear the input field
        codeInputField.text = "";
    }

    void UpdatePointsText()
    {
        pointsText.text = playerPoints.ToString();
        pointsAddText.text = playerAddPoints.ToString();
        
    }
}
