using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CurrentGame : MonoBehaviour {
    Text textComponent;
	void Awake()
    {
        textComponent = GetComponent<Text>();
        textComponent.text = GameState.state.matchStaticData.getCurrentGame();
    }
}
