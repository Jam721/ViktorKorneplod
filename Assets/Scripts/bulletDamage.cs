using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletDamage : MonoBehaviour
{

    private void OnTriggerEnter(Collider other) {
        if (other.tag == "Player")
        {
            enemy.heroHp --;
        }
    }
}
