using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class boss : MonoBehaviour
{
    public GameObject[] bullet;

    public Transform point;
    public Transform heroPos;

    private int timer;

    
    
    

    private void OnTriggerStay(Collider other) {
        int i = Random.Range(0,3);
        if (other.tag == "Player")
        {
            transform.LookAt(other.transform.position);
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y,0);
            if (timer == 200)
            {
                RaycastHit hit;
                if (Physics.Raycast(point.transform.position, point.transform.position, out hit))
                {
                    GameObject b = Instantiate(bullet[i], point.transform.position, Quaternion.identity);
                    b.GetComponent<Rigidbody>().AddForce(hit.normal * 350, ForceMode.Impulse);
                }
                timer = 0;
            }
            timer ++;
        }
    }
    

    

    
}
