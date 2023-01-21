using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class heartBullet : MonoBehaviour
{
    public GameObject heart;
    public Camera mainCamera;
    public Transform spawn;

    public float shootForce;

    

    private void Update() 
    {
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
        
    }
    private void Shoot()
    {
        Ray ray = mainCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;
        Vector3 targetPoint;
        if(Physics.Raycast(ray, out hit))
        {
            targetPoint = hit.point;
        }
        else
        {
            targetPoint = ray.GetPoint(75);
        }

        Vector3 dirWithout = targetPoint - spawn.position;

        GameObject currentBullet = PhotonNetwork.Instantiate(heart.name, spawn.position, Quaternion.identity);

        currentBullet.transform.forward = dirWithout.normalized;

        currentBullet.GetComponent<Rigidbody>().AddForce(dirWithout.normalized * shootForce, ForceMode.Impulse);
    }

    

}
