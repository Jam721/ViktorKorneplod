using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class bulletLife : MonoBehaviour
{
    private int bulletLif = 30;
    int timer = 0;



    private void Awake() {
       
        Destroy(gameObject, bulletLif);
        
    }
    
    private IEnumerator OnCollisionEnter(Collision other) {
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
    }

    

    
    
}
