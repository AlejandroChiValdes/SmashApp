using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class displayWinner : MonoBehaviour {
    [SerializeField] Text winnerText;
	// Use this for initialization
	void Awake()
    {
        winnerText.text = GameState.state.matchData.getWinner();
    }
}
