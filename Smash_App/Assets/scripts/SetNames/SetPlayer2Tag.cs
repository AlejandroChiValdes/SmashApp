using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetPlayer2Tag : MonoBehaviour {
    Text textComponent;

    void Awake()
    {
        textComponent = GetComponent<Text>();
        textComponent.text = GameState.state.matchData.getP2Name();
    }
 
}
