using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour {

    public Transform target;  // ターゲットへの参照
    public bool playerFall = false;   // PlayerFreeから
    Vector3 pos;

    void Start () {
		
	}
	

	void Update () {

        GetComponent<Transform>().position = pos;
        pos.x = target.position.x;
        // 自分の座標にtargetの座標を代入する
        pos.x = target.position.x;
        pos.z = -10;

        if (13.3 < pos.x || pos.x < 0)
        {
            pos.x = this.transform.position.x;
        }

        if(playerFall)
        {
            pos.x = 0;
            pos.z = -10;
            playerFall = false;
        }

    }
}
