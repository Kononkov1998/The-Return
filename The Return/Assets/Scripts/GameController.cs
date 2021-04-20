using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class GameController : MonoBehaviour
{
    public Player player;
    public TMP_InputField textEntryField;
    public TextMeshProUGUI logText;
    public TextMeshProUGUI currentText;
    [TextArea]
    public string introText;
    public Action[] actions;

    void Start()
    {
        logText.text = introText;
        DisplayLocation();
        textEntryField.ActivateInputField();
    }

    public void DisplayLocation(bool additive = false)
    {
        var description = player.currentLocation.description + "\n";
        description += player.currentLocation.GetConnectionsText();
        description += player.currentLocation.GetItemsText();

        if (additive)
        {
            currentText.text += $"\n{description}";
        }
        else
        {
            currentText.text = description;
        }
    }

    public void TextEntered()
    {
        LogCurrentText();
        ProcessInput(textEntryField.text);

        textEntryField.text = string.Empty;
        textEntryField.ActivateInputField();
    }

    private void LogCurrentText()
    {
        logText.text += "\n\n" + currentText.text;
        logText.text += "\n\n<color=#00FF61>" + textEntryField.text + "</color>";
    }

    private void ProcessInput(string input)
    {
        input = input.ToLower();

        char[] separator = { ' ' };
        string[] separatedWords = input.Split(separator);

        foreach (Action action in actions)
        {
            if (action.keyword.ToLower() == separatedWords[0])
            {
                if (separatedWords.Length > 1)
                {
                    action.RespondToInput(this, separatedWords[1]);
                }
                else
                {
                    action.RespondToInput(this, "");
                }
                return;
            }
        }

        currentText.text = "Nothing happens! Having trouble? Type 'Help'";
    }
}
