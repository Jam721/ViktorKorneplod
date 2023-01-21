using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class enemy : MonoBehaviour
{
	// Скорость врага
	public float speed;

	// Точка и позиция
	public int positionOfPatrol;
	public Transform point;
	bool moveingRight;

	// Герой
	public Transform player;
	public static int heroHp = 10;

	// Дистанция остановки
	public float stoppingDistance;

	// Три состояния
	bool chill = false;
	public static bool angry = false;
	bool goBack = false;

	// Панель
	public GameObject panel;

	public GameObject monsterAudio;




	private void Start() 
	{
		player = GameObject.FindGameObjectWithTag("Player").transform;
	}

	private void Update()
	{
		
		if (Vector3.Distance(transform.position, point.position) < positionOfPatrol && angry == false)
		{
			chill = true;
		}
		if (Vector3.Distance(transform.position, player.position)<stoppingDistance)
		{
			angry = true;
			chill = false;
			goBack = false;
		}
		if (Vector3.Distance(transform.position, player.position)>stoppingDistance)
		{
			goBack = true;
			angry = false;
		}

		if (chill == true)
		{
			Chill();
		}
		else if (angry == true)
		{
			Angry();
			monsterAudio.SetActive(true);
		}
		else if (goBack == true)
		{
			GoBack();
		}
		
	}

	void Chill()
	{
		if (transform.position.x > point.position.x + positionOfPatrol)
		{
			moveingRight = false;
		}
		else if (transform.position.x < point.position.x - positionOfPatrol)
		{
			moveingRight = true;
		}

		if (moveingRight)
		{
			transform.position = new Vector3(transform.position.x + speed * Time.deltaTime, transform.position.y, transform.position.z);
		}
		else
		{
			transform.position = new Vector3(transform.position.x - speed * Time.deltaTime, transform.position.y, transform.position.z);
		}
	}

	void Angry()
	{
		transform.position = Vector3.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
	}

	void GoBack()
	{
		transform.position = Vector3.MoveTowards(transform.position, point.position, speed * Time.deltaTime);
	}

	private IEnumerator OnTriggerEnter(Collider other){
		if (other.CompareTag("Player"))
		{
			heroHp--;
			speed = speed / 10f;
			yield return new WaitForSeconds(1f);
			speed = speed * 10f;
		}
		if (heroHp<=0)
		{
			panel.SetActive(true);
		}
	}
}
