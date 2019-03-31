using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destory : MonoBehaviour {

	
	void Update () {
		if(GameObject.Find("blackBG_FadeOut"))
        {
            Destroy(gameObject);
        }
	}
}
