using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Displays the version number

public class UIVersionNumber : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Text text = GetComponent<Text>();

        if (text) {
            text.text = "v." + Application.version;
        }
    }
}
