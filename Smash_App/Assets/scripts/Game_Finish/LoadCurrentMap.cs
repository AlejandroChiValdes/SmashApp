using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadCurrentMap : MonoBehaviour {

    [SerializeField] Image currentImage;

    void Awake()
    {
        string currentStage = GameState.state.matchData.getCurrentStage();
        //print("Current stage: " + currentStage);
        currentImage.sprite = Resources.Load<Sprite>(currentStage) as Sprite;
    }
}
