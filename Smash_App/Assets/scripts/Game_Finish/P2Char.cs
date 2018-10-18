using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class P2Char : MonoBehaviour {

    [SerializeField] Image img;
    void Awake()
    {
        print(GameState.state.matchData.getPlayerChar(1));
        img.sprite = Resources.Load<Sprite>("Melee Character Sprites\\m" + GameState.state.matchData.getPlayerChar(1)) as Sprite;
    }
}
