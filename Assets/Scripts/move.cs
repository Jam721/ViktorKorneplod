using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class move : MonoBehaviour
{
	// Скорость и персонаж
	public GameObject player;
	public int speed = 5;

	// Звуки хлдьбы и бега
	public AudioSource moveAudio;
	public AudioSource runAudio;

	PhotonView view;

	public GameObject cameras;
	public move scriptMove;
	public GameObject karta;
	public GameObject canv;

	private Rigidbody rb;


	

	private void Awake() {
		view = GetComponent<PhotonView>();

		if(!view.IsMine)
		{
			cameras.SetActive(false);
			scriptMove.enabled = false;
			karta.SetActive(false);
			canv.SetActive(false);
		}
		Cursor.visible = false;
	}

	void Start () {
		player = (GameObject)this.gameObject;
		Cursor.lockState = CursorLockMode.Locked;
		rb = player.GetComponent<Rigidbody>();
	}

	private void Update() 
	{
		// Статичный курсор
		if (Input.GetKeyUp (KeyCode.Escape)) 
		{
			Cursor.lockState = CursorLockMode.None;
		}


		// Ходьба
		if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
		{
			player.transform.position += player.transform.forward * speed * Time.deltaTime;
		}
		if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
		{
			player.transform.position -= player.transform.forward * speed * Time.deltaTime;
		}
		if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
		{
			player.transform.position -= player.transform.right * speed * Time.deltaTime;
		}
		if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
		{
			player.transform.position += player.transform.right * speed * Time.deltaTime;
		}

		// Звуки шагов
		if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)) {moveAudio.mute = false;}
		else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)) {moveAudio.mute = false;}
		else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) {moveAudio.mute = false;}
		else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) {moveAudio.mute = false;}
		else {moveAudio.mute = true;}

		// Ускорение
		if ( Input.GetKey(KeyCode.LeftShift))
		{
			speed = 10;
			moveAudio.mute = true;
			runAudio.mute = false;
			
		}
		else
		{
			speed = 5;
			runAudio.mute = true;
		}
	}

	
}
