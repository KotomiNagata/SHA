using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurSorStart : MonoBehaviour {

    public Texture2D cursor;

    void Start () {
        Cursor.visible = true;
        // カーソルのロック解除
        Cursor.lockState = CursorLockMode.None;
        Cursor.SetCursor(cursor,
                         new Vector2(cursor.width / 2, cursor.height / 2),
                         CursorMode.ForceSoftware);
    }
	
	
	void Update () {
		
	}
}
