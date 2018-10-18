using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickBanScreenAwake : MonoBehaviour {

    [SerializeField] Text pickBanText;

    void Awake()
    {
        //persistStaticMembers();
        togglePickBanText(pickBanText);
    }

    //void persistStaticMembers()
    //{
    //    if (pickBan == null)
    //    {
    //        pickBan = this;
    //        GameObject.DontDestroyOnLoad(gameObject);
    //    }
    //    else print(pickBan.pickBanText);

    //}

    public static void togglePickBanText(Text t)
    {
        switch(GameState.state.matchData.getCurrentPhase())
        {
            case 0:
                break;
            default:
                changeText(t);
                break;
        }
    }

    public static void changeText(Text t)
    {
        switch (GameState.state.matchStaticData.getMaxGames())
        {
            case 3:
                t.text = "ban";
                break;
            case 5:
                
                t.text = "pick";
                break;
        }
    }

}
