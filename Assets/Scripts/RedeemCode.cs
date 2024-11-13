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
    private int playerPoints = 0;

    void Start()
    {
        
        // Initialize the points display
        UpdatePointsText();

        // Add a listener to the redeem button
        redeemButton.onClick.AddListener(Redeem);


        validCodes["HG428"] = (1000, GameObject.Find("SpecialUIElement1"));
        validCodes["IK222"] = (300, GameObject.Find("SpecialUIElement2"));
        validCodes["GA024"] = (200, GameObject.Find("SpecialUIElement3"));
        validCodes["ES124"] = (200, GameObject.Find("SpecialUIElement4"));
        validCodes["CU083"] = (300, GameObject.Find("SpecialUIElement5"));
        validCodes["GK234"] = (500, GameObject.Find("SpecialUIElement6"));
        validCodes["EC093"] = (300, GameObject.Find("SpecialUIElement7"));
        validCodes["OE430"] = (200, GameObject.Find("SpecialUIElement8"));
        validCodes["TS222"] = (200, GameObject.Find("SpecialUIElement9"));
        validCodes["CV450"] = (500, GameObject.Find("SpecialUIElement10"));

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

            // Activate the associated UI element, if any
            if (validCodes[enteredCode].uiElement != null)
            {
                validCodes[enteredCode].uiElement.SetActive(true);
            }

            // Remove the code from the dictionary to prevent re-use
            validCodes.Remove(enteredCode);

            // Update the points display
            UpdatePointsText();

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
    }
}
