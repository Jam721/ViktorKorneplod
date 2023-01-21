using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;

public class Connection : MonoBehaviourPunCallbacks
{
    private void Awake() {
        PhotonNetwork.ConnectUsingSettings();
    }
	public override void OnConnectedToMaster()
	{
		SceneManager.LoadScene("Menu");
	}
}
