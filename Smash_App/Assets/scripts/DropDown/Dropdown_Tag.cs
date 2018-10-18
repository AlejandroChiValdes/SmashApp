using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dropdown_Tag : MonoBehaviour
{
    [SerializeField] public Dropdown dropDown; // SerializeField allows us to attach a dropdown component straight from the editor rather 
    // than dealing with the GetComponent method
    
    //public void setPlayerName(int x)
    //{
    //    //dropDown = GetComponent<Dropdown>();
    //    dropDown.RefreshShownValue();
    //    dropDown.Hide();
    //    string text = dropDown.captionText.text;
    //    switch (x)
    //    {
    //        case 1:
    //            GameState.state.matchData.setP1Name(text);
    //            break;
    //        case 2:
    //            GameState.state.matchData.setP2Name(text);
    //            break;
    //    } 
    //}

    public void setPlayerName()
    {
        //dropDown = GetComponent<Dropdown>();
        dropDown.RefreshShownValue();
        dropDown.Hide();
        string text = dropDown.captionText.text;
        switch (GameState.state.matchData.getCurrentPlayerIndex())
        {
            case 0:
                GameState.state.matchData.setP1Name(text);
                break;
            case 1:
                GameState.state.matchData.setP2Name(text);
                break;
        }
    }
}
