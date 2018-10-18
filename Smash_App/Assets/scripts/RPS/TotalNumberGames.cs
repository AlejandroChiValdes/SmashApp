using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TotalNumberGames : MonoBehaviour {

    Text textComponent;

    void Awake()
    {
        textComponent = GetComponent<Text>();
        textComponent.text = GameState.state.matchStaticData.getMaxGames().ToString(); // Converts the integer maxGames value to a string
    }

}
