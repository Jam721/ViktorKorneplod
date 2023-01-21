using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class monsterHp1 : MonoBehaviourPun
{
    public int hp = 30;

    public AudioSource aud;
    public AudioSource pos;

    public GameObject game_;
    public GameObject winEc;

    public GameObject win;

    public GameObject player;


    public void Damage()
    {
        hp -= 1;
    }

    private void OnCollisionEnter(Collision other)
    {
        if (!photonView.IsMine || !other.collider.CompareTag("Bullet"))
        {
            return;
        }
        
        Damage();
        if (hp<=0)
        {
            
            PhotonNetwork.Destroy(gameObject);
		    
            
            if (gameObject.layer == 6)
            {
                win.SetActive(true);
                game_.SetActive(false);
                pos.Play();
                player.GetComponent<Rigidbody>().isKinematic = true;
                aud.Stop();
            }
        }
    }

    
}
