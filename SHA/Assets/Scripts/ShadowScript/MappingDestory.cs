using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 影を選択した時のマッピングについてのスクリプト
public class MappingDestory : MonoBehaviour {

    public bool noMapping = false;

	void Update () 
    {
        if(Cursor.visible == false)
        {
            Destroy(this.gameObject);
        }
	}
}
