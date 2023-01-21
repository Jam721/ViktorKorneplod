using UnityEngine;
using Photon.Pun;

public class SpawnManager : MonoBehaviour
{
    public static SpawnManager Instance;
    public GameObject[] spawns;
    public GameObject Player;
    private GameObject _localPlayer;


    private void Awake()
    {
        if (Instance)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        
        SpawnLocalPlayer();
    }

    private void SpawnLocalPlayer()
    {
        Vector3 randPos = spawns[Random.Range(0, spawns.Length)].transform.position;
        _localPlayer = PhotonNetwork.Instantiate(Player.name, randPos, Quaternion.identity);
    }

    public void RespawnLocalPlayer()
    {
        Vector3 randPos = spawns[Random.Range(0, spawns.Length)].transform.position;
        _localPlayer.transform.position = randPos;
    }
}
