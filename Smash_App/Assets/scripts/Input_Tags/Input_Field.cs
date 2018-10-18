using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Input_Field : MonoBehaviour {
    [SerializeField] InputField inputField;

    public void submitPlayerName(int x)
    {
        string text = inputField.text;
        switch (x)
        {
            case 1:
                GameState.state.matchData.setP1Name(text);
                break;
            case 2:
                GameState.state.matchData.setP2Name(text);
                break;
        }
        addPlayerToList(text); 
    }

	public void addPlayerToList(string text)
    {
        GameState.analyticsData.addPlayerToList(text);
    }
}
