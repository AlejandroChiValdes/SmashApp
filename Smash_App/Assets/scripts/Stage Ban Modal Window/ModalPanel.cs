using System.Collections;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Collections.Generic;
using UnityEngine;


public class ModalPanel : MonoBehaviour {

    public Text question;
    public Button confirm;
    public Button cancel;
    public GameObject modalPanelObject;

    public static ModalPanel modalPanel;
    UnityAction preventCounterPick = new UnityAction(preventCP); // method needed to be static for some reason? maybe look into why
    UnityAction chooseCounterPick = new UnityAction(chooseCP);

    void Awake()
    {
        Instance();
    }
    public static ModalPanel Instance()
    {
        if (!modalPanel)
        {
            modalPanel = FindObjectOfType(typeof(ModalPanel)) as ModalPanel;
            if (!modalPanel)
                Debug.LogError("ModalPanel object not found.");

        }
        return modalPanel;
    }

    // confirm / cancel: takes a string (the question) , a 'yes' event, a 'no' event
    public void Choice ()//, UnityAction confirmEvent, UnityAction cancelEvent)
    {
        modalPanelObject.SetActive(true);
        


        confirm.onClick.RemoveAllListeners();
        //confirm.onClick.AddListener(confirmEvent);
        //confirm.onClick.AddListener(allowCounterPick);
        confirm.onClick.AddListener(chooseCounterPick);
        confirm.onClick.AddListener(ClosePanel);

        cancel.onClick.RemoveAllListeners(); // remove any lingering listeners on the current button
        
        //cancel.onClick.AddListener(cancelEvent); // add a listener that will trigger 'cancelEvent' when button is clicked
        cancel.onClick.AddListener(ClosePanel); // add a listener that will close the panel when button is clicked
        cancel.onClick.AddListener(preventCounterPick);
        //question.text = q; // Only need this if we're going to be substituting out the panel text multiple times. Won't need for our purposes

        //this.iconImage.SetActive(false); ONLY NEED THIS IF WE WANT TO HAVE AN ICON ON THE PANEL IN THE FUTURE
        confirm.gameObject.SetActive(true); // buttons are now clickable
        cancel.gameObject.SetActive(true);
    }

    static void chooseCP()
    {
        StageManager.chooseStage(modalPanel.confirm, true);
    }

    static void preventCP()
    {
        GameState.state.matchData.preventCounterPick();
        GameState.state.metaData.togglePanelActive();
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
