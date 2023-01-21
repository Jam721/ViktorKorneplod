using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startBoss : MonoBehaviour
{
    public GameObject boss;
    private void Update() {
        if (mashrooms.intText == 5)
        {
            boss.SetActive(true);
        }
    }
}
