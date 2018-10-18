using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class colorChange {

    public static colorChange changeColor = new colorChange();

	
	// Update is called once per frame
	void Update ()
    {
        checkButtonPress();
    }

    public void banStage(Button button)
    {
        Color newColor = new Color(0.8f, 0.0f, 0.0f, 1.0f);
        ColorBlock cb = button.colors;
        cb.normalColor = newColor;
        cb.highlightedColor = newColor;
        button.colors = cb;
    }

    public void chooseStage(Button button)
    {
        Color newColor = new Color(0.0f, 0.8f, 0.0f, 1.0f);
        ColorBlock cb = button.colors;
        cb.normalColor = newColor;
        cb.highlightedColor = newColor;
        button.colors = cb;


    }

    private void checkButtonPress()
    {
        
    }
}
