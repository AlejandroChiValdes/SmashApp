using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using UnityEngine.SceneManagement;

public class ToCharSelect : MonoBehaviour {

    public Button yes;
    public Button no;
    public GameObject modalPanelObject;

    public static ToCharSelect modalPanel;


    void Awake()
    {
        Instance();
    }
    public static ToCharSelect Instance()
    {
        if (!modalPanel)
        {
            modalPanel = FindObjectOfType(typeof(ToCharSelect)) as ToCharSelect;
            if (!modalPanel)
                Debug.LogError("ModalPanel object not found.");

        }
        return modalPanel;
    }

    // confirm / cancel: takes a string (the question) , a 'yes' event, a 'no' event
    public void openCharSelectWindow()//, UnityAction confirmEvent, UnityAction cancelEvent)
    {
        modalPanelObject.SetActive(true);

        yes.gameObject.SetActive(true); // buttons are now clickable
        no.gameObject.SetActive(true);
    }

    public void toCharSelect()
    {
        quit();
        SceneManager.LoadScene("Char_Switch");
    }

    public void toWinScreen()
    {
        quit();
        SceneManager.LoadScene("Game_Finish");
    }

    void quit()
    {
        modalPanelObject.SetActive(false);
        
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
