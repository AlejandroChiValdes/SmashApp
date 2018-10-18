using System.Collections;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Collections.Generic;
using UnityEngine;


public class EditNameModalPanel : MonoBehaviour {

    public static EditNameModalPanel modalPanel;

    public Dropdown existingTags;
    public Button submit;
    public InputField customTag;
    public GameObject modalPanelObject;
    // Keeps track of the current name the user inputted. Will change between the dropdown name value and the input name value, depending
    // on if the user does the former, the latter, or both. This will make sure to keep track of the latest name they've chosen.
    // Either player 1 or player 2
    string currentName;
    
    // CURRENT BUG: PLAYER 2 NAME REPLACES PLAYER 1 NAME FOR SOME REASON

    void Awake()
    {
        Instance();
    }
    public static EditNameModalPanel Instance()
    {
        if (!modalPanel)
        {
            modalPanel = FindObjectOfType(typeof(EditNameModalPanel)) as EditNameModalPanel;
            if (!modalPanel)
                Debug.LogError("ModalPanel object not found.");

        }
        return modalPanel;
    }

    // confirm / cancel: takes a string (the question) , a 'yes' event, a 'no' event
    public void EnablePanel ()//, UnityAction confirmEvent, UnityAction cancelEvent)
    {
        modalPanel.modalPanelObject.SetActive(true);
       
        // Add listeners for the input name field
        clearAllInputs(modalPanel);
        existingTags.gameObject.SetActive(true); // buttons are now clickable
        customTag.gameObject.SetActive(true);
        submit.gameObject.SetActive(true);
        // Set the current player name to the last name that they picked
        refreshCurrentPlayerName();
    }

    void refreshCurrentPlayerName()
    {
        currentName = GameState.state.matchData.getCurrentPlayer();
    }

    static string returnDefaultName()
    {
        return "Player " + (GameState.state.matchData.getCurrentPlayerIndex() + 1).ToString();
    }

    public void updateDropdownName(Dropdown dropDown)
    {
        // sets current name to whatever the chosen dropdown name is.
        modalPanel.currentName = dropDown.captionText.text;
    }

    public void updateInputFieldName(InputField input)
    {
        // sets current name to whatever the input field value is.
        modalPanel.currentName = input.text;
        // Add player name to overall player name list.
        GameState.analyticsData.addPlayerToList(input.text);
    }

    public void updatePlayerName(Button button)
    {
        // Sets current player name in the GameState to whatever the modalPanel's last stored name was before pressing 'OK'
        GameState.state.matchData.setCurrentPlayerName(modalPanel.currentName);
        //print(modalPanel.currentName);
        //print(GameState.state.matchData.getCurrentPlayerIndex());
        modalPanel.modalPanelObject.SetActive(false);

    }

    public void changeDropDownName(int x)
    {
       modalPanel.currentName = modalPanel.existingTags.captionText.text;
    }

    static void clearAllInputs(EditNameModalPanel m)
    {
        m.currentName = GameState.state.matchData.getCurrentPlayer();
        m.existingTags.captionText.text = m.currentName;
        m.customTag.text = "";
    }

    bool returnFalse()
    {
        return false;
    }

    void ClosePanel()
    {
        modalPanelObject.SetActive(false);
    }
}
