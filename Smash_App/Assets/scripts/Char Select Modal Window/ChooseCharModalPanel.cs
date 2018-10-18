using System.Collections;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Collections.Generic;
using UnityEngine;


public class ChooseCharModalPanel : MonoBehaviour {

    public static ChooseCharModalPanel modalPanel;

    //public Dropdown existingTags;
    //public Button submit;
    //public InputField customTag;
    public GameObject modalPanelObject;
    // Keeps track of the current name the user inputted. Will change between the dropdown name value and the input name value, depending
    // on if the user does the former, the latter, or both. This will make sure to keep track of the latest name they've chosen.
    
    // Either player 1 or player 2
    string currentChar;

    void Awake()
    {
        Instance();
    }

    void Instance()
    {
        if (!modalPanel)
        {
            //modalPanel = FindObjectOfType(typeof(ChooseCharModalPanel)) as ChooseCharModalPanel;
            modalPanel = this;

            if (!modalPanel)
                Debug.LogError("ModalPanel object not found.");

        }
    }

    // confirm / cancel: takes a string (the question) , a 'yes' event, a 'no' event
    public void EnablePanel()//, UnityAction confirmEvent, UnityAction cancelEvent)
    {
        modalPanel.modalPanelObject.SetActive(true);
        // Add listeners for the input name field
        //clearAllInputs(modalPanel);
        //existingTags.gameObject.SetActive(true); // buttons are now clickable
        //customTag.gameObject.SetActive(true);
        //submit.gameObject.SetActive(true);
    }



    public void updatePlayerChar(Image i)
    {
        // Sets current player name in the GameState to whatever the modalPanel's last stored name was before pressing 'OK'
        string imageName = i.name;
        GameState.state.matchData.setCurrentPlayerChar(imageName.Substring(1, imageName.Length-1));
        exit();

    }

    public void updatePlayerChar(int i, string s)
    {
        // same as method above, except input is the direct string instead of an image gameobject
        GameState.state.matchData.setPlayerChar(i, s.Substring(1, s.Length - 1));
    }

    public void exit()
    {
        modalPanel.modalPanelObject.SetActive(false);
    }

    //public void updateChar(Button b)
    //{
    //    // update the current player's character
    //    modalPanel.currentChar = b.name;
    //}

    //public void changeDropDownName(int x)
    //{
    //    modalPanel.currentName = modalPanel.existingTags.captionText.text;
    //}

    //static void clearAllInputs(ChooseCharModalPanel m)
    //{
    //    m.currentName = GameState.state.matchData.getCurrentPlayer();
    //    m.existingTags.captionText.text = m.currentName;
    //    m.customTag.text = "";
    //}

    //static void chooseCP()
    //{
    //    StageManager.chooseStage(modalPanel.confirm);
    //}

    //static void preventCP()
    //{
    //    GameState.state.matchData.preventCounterPick();
    //    GameState.state.metaData.togglePanelActive();
    //}

    //static void allowCP()
    //{
    //    GameState.state.matchData.allowCounterPick();
    //    GameState.state.metaData.togglePanelActive();
    //}

    bool returnFalse()
    {
        return false;
    }

    void ClosePanel()
    {
        modalPanelObject.SetActive(false);
    }
}
