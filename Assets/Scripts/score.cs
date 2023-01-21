using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class score : MonoBehaviour
{
    public Text text;
    public int intText;


    private void Update() {
        text.text = intText.ToString();
    }

    public void Score()
    {
        intText++;
    }
}
