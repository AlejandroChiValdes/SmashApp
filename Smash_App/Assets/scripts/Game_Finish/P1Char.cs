using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class P1Char : MonoBehaviour {

    [SerializeField] Image img;
    void Awake()
    {
        print(GameState.state.matchData.getPlayerChar(0));
        img.sprite = Resources.Load<Sprite>("Melee Character Sprites\\m" + GameState.state.matchData.getPlayerChar(0)) as Sprite;
    }
}
