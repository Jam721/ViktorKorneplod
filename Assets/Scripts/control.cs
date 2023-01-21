using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;

public class control : MonoBehaviour
{
    public GameObject enem;
    
    public void Quit()
    {
        Application.Quit();
    }

    public void ReloadScene()
    {
        PhotonNetwork.LoadLevel("base");
        mashrooms.intText = 0;
        enemy.heroHp = 10;
        GetComponent<enemy>().monsterAudio.SetActive(false);
        GetComponent<monsterHp1>().pos.Stop();
        GetComponent<move>().player.GetComponent<Rigidbody>().isKinematic = false;
    }


}
