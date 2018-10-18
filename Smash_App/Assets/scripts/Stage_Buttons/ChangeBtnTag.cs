using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeBtnTag {

    //public static ChangeBtnTag btnTag = new ChangeBtnTag();

    public static void changeBtnTag(Button btn)
    {
        btn.tag = "Banned";
    }
}
