using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "State")] // right clicking the asset menu allows you to make a 'new' menu of class 'State'
public class State : ScriptableObject {

    [TextArea(10, 14)] [SerializeField] string storyText; // 14 max height, 10 lines before we start to scroll
    [SerializeField] State[] nextStates = { };

    public string GetStateStory()
    {
        return storyText;
    }

    public State[] GetNextStates()
    {
        return nextStates;
    }
}
