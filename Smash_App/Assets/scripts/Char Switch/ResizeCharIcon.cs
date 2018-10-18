using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResizeCharIcon : MonoBehaviour {
    //unused for now, will consider using if I want to set default width and height for character icon
    //static float defaultW = 150.0f;
    //static float defaultH = 100.0f;

    // used by updateplayerchar.cs, so this method needs to be static.
    static public void resizeImage(Image charIcon)
    {
        //charIcon.rectTransform.sizeDelta = new Vector2(charIcon.rectTransform.rect.width * 1.5f, charIcon.rectTransform.rect.height * 0.75f);
        charIcon.rectTransform.sizeDelta = new Vector2(200.0f, 100.0f);

    }

    static public void resizeImageCustom(float h, float w, Image charIcon)
    {
        //charIcon.rectTransform.sizeDelta = new Vector2(charIcon.rectTransform.rect.width * 1.5f, charIcon.rectTransform.rect.height * 0.75f);
        charIcon.rectTransform.sizeDelta = new Vector2(w, h);

    }
}
