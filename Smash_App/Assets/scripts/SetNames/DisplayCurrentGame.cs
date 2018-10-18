using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayCurrentGame : MonoBehaviour {
    [SerializeField] Text textComponent;
	void Awake()
    {
        textComponent.text = GameState.state.matchData.getThisGame().ToString();
    }
}
