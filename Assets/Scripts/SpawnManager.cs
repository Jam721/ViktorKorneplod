using UnityEngine;
using Photon.Pun;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] spawns;
    public GameObject Player;


    private void Awake() {
        Vector3 randPos = spawns[Random.Range(0, spawns.Length)].transform.position;

        PhotonNetwork.Instantiate(Player.name, randPos, Quaternion.identity);
    }

    
}
