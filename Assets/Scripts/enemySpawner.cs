using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class enemySpawner : MonoBehaviour
{
    public GameObject enemy1;
    public GameObject enemySpawn;

    public int hp;

    private void Awake() {
        PhotonNetwork.Instantiate(enemy1.name, enemySpawn.transform.position, Quaternion.identity);
        hp = GetComponent<monsterHp1>().hp;
    }

    
}
