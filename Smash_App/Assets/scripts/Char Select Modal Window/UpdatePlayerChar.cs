using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdatePlayerChar : MonoBehaviour {

    public Image img;

    public void updatePlayerChar(Image i)
    {
        //build string for current player's character image

       string imageLoc;
        //If the user inputted a specific image name to be changed, then use that as the image name
        imageLoc = "p" + (GameState.state.matchData.getCurrentPlayerIndex() + 1).ToString() + "_char";
        //Replace the image with the player's chosen character image
        Image imageDestination = GameObject.Find(imageLoc).GetComponent<Image>();
        imageDestination.sprite = Resources.Load<Sprite>("Melee Character Sprites\\" + i.name) as Sprite;
        ResizeCharIcon.resizeImageCustom(85.0f, 170.0f,imageDestination);
        imageDestination.sprite = Resources.Load<Sprite>("Melee Character Sprites\\" + i.name) as Sprite;
    }

    public void updatePlayerCharFixedImg(Image i)
    {
        // build string for current player's character image
        //string imageLoc;
        // If the user inputted a specific image name to be changed, then use that as the image name
        //imageLoc = "p" + (GameState.state.matchData.getCurrentPlayerIndex() + 1).ToString() + "_char";
        // Replace the image with the player's chosen character image
        //GameObject.Find(imageLoc).GetComponent<Image>().sprite = Resources.Load<Sprite>("Melee Character Sprites\\" + i.name) as Sprite;
        ResizeCharIcon.resizeImage(img);
        img.sprite = Resources.Load<Sprite>("Melee Character Sprites\\" + i.name) as Sprite;
    }

    //public void updateImageName(Image i, string s)
    //{
    //    updatePlayerChar(i, s);
    //}
}
