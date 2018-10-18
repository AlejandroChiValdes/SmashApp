using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DropDown : MonoBehaviour {
    Dropdown dropDown;
    Dropdown.OptionData newOption;

    void Awake()
    {
        setOptionsPlayerX();
    }

    void setOptionsPlayerX()
    {
        dropDown = GetComponent<Dropdown>();
        List<string> names = GameState.analyticsData.getPlayerData();
        foreach(string name in names)
        {
            newOption = new Dropdown.OptionData();
            newOption.text = name;
            //print(newOption.text);
            dropDown.options.Add(newOption);
        }
        //dropDown.captionText.text = "";
    }
}
