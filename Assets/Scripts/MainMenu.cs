using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

public class MainMenu : MonoBehaviourPunCallbacks
{
    public InputField inputFieldNameRoom;
    
    public GameObject errorPanel;

    public void CreateRoom()
    {
        if (inputFieldNameRoom.text.Length>3)
        {
            RoomOptions roomOptions = new RoomOptions();
            roomOptions.MaxPlayers = 4;
            PhotonNetwork.CreateRoom(inputFieldNameRoom.text, roomOptions);
        }
        else errorPanel.SetActive(true);
        
    }

    public void JoinRoom()
    {
        if (inputFieldNameRoom.text.Length>3)
        {
            PhotonNetwork.JoinRoom(inputFieldNameRoom.text);
        }
        else errorPanel.SetActive(true);
    }

	public override void OnJoinedRoom()
	{
		PhotonNetwork.LoadLevel("base");
	}
}
