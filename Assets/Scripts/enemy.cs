using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Photon.Pun;

public enum EnemyStatus
{
	Chill,
	Angry,
	GoBack
}

public class enemy : MonoBehaviourPun
{
	[SerializeField] private float scanRadius = 20;
	[SerializeField] private LayerMask scanLayerMask;
	
	// Скорость врага
	public float speed;

	// Точка и позиция
	public int positionOfPatrol;
	public Transform point;
	bool moveingRight;

	// Герой
	private move _targetPlayer;
	public static int heroHp = 10;

	// Состояние
	private EnemyStatus _enemyStatus;

	// Панель
	public GameObject panel;

	public GameObject monsterAudio;
	
	// Кешированный трансформ
	private Transform _transform;
	
	// Массив для сканирования
	private Collider[] _scannedPlayers;
	
	private void Awake()
	{
		_transform = transform;
		_scannedPlayers = new Collider[6];
	}

	private void Update()
	{
		if (!photonView.IsMine)
		{
			return;
		}

		_targetPlayer = FindNearestPlayer();
		
		if (_targetPlayer)
		{
			_enemyStatus = EnemyStatus.Angry;
		}
		else if (Vector3.Distance(_transform.position, point.position) < positionOfPatrol)
		{
			_enemyStatus = EnemyStatus.Chill;
		}
		else
		{
			_enemyStatus = EnemyStatus.GoBack;
		}
	}

	private void FixedUpdate()
	{
		if (!photonView.IsMine)
		{
			return;
		}
		
		switch (_enemyStatus)
		{
			case EnemyStatus.Angry:
				if (_targetPlayer)
				{
					Angry(_targetPlayer);
				}
				break;
			case EnemyStatus.Chill:
				Chill();
				break;
			case EnemyStatus.GoBack:
				GoBack();
				break;
		}
	}

	move FindNearestPlayer()
	{
		var playerScanCount = Physics.OverlapSphereNonAlloc(_transform.position, scanRadius, _scannedPlayers, scanLayerMask);

		var minDistance = scanRadius;
		move targetPlayer = null;

		for (int i = 0; i < playerScanCount; i++)
		{
			var player = _scannedPlayers[i].GetComponent<move>();
			if (!player)
			{
				continue;
			}
			
			var playerPosition = player.transform.position;
			var distance = Vector3.Distance(playerPosition, _transform.position);
			
			if (distance < minDistance)
			{
				minDistance = distance;
				targetPlayer = player;
			}
		}

		return targetPlayer;
	}

	void Chill()
	{
		var position = _transform.position;
		var pointPosition = point.position;
		
		if (position.x > pointPosition.x + positionOfPatrol)
		{
			moveingRight = false;
		}
		else if (position.x < pointPosition.x - positionOfPatrol)
		{
			moveingRight = true;
		}

		if (moveingRight)
		{
			transform.position = new Vector3(position.x + speed * Time.deltaTime, position.y, position.z);
		}
		else
		{
			transform.position = new Vector3(position.x - speed * Time.deltaTime, position.y, position.z);
		}
	}

	void Angry(move targetPlayer)
	{
		var targetOwnerPlayer = targetPlayer.GetComponent<PhotonView>().Owner;
		if (!Equals(targetOwnerPlayer, photonView.Owner))
		{
			photonView.RPC("PlayAngySound", targetOwnerPlayer);
		}
		else
		{
			PlayAngySound();
		}

		transform.position = Vector3.MoveTowards(transform.position, targetPlayer.transform.position, speed * Time.deltaTime);
	}

	[PunRPC]
	private void PlayAngySound()
	{
		monsterAudio.SetActive(true);
	}

	void GoBack()
	{
		transform.position = Vector3.MoveTowards(transform.position, point.position, speed * Time.deltaTime);
	}

	private IEnumerator OnCollisionEnter(Collision other){
		if (other.collider.CompareTag("Player"))
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
