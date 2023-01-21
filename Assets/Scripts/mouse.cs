using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouse : MonoBehaviour
{
    private void Update() {
        if (Input.GetKeyUp (KeyCode.Escape)) 
		{
			Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
		}
        if (Input.GetMouseButton(0) && Cursor.lockState == CursorLockMode.None)
        {
            Cursor.visible = false;
            
        }
    }
}
