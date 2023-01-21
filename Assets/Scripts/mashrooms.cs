using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class mashrooms : MonoBehaviour
{
    public Text text;
    public static int intText=0;

    public Text textHp;

    public AudioSource auio;


    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player"))
        {
            intText++;
            Destroy(gameObject);
            auio.Play();
        }
    }

    private void Update() {
        text.text = intText.ToString();
        textHp.text = enemy.heroHp.ToString();
    }
}
