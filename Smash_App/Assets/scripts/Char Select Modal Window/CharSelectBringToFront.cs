using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharSelectBringToFront : MonoBehaviour {

	void OnEnable()
    {
        transform.SetAsLastSibling();
    }
}
