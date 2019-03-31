using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowBingoPiece : MonoBehaviour {

	void Update () {
		if(!GameObject.Find("1"))
        {
            Destroy(gameObject);
        }
	}
}
