using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorBingo : MonoBehaviour {

    public GameObject doorL;
    public GameObject doorR;
    public GameObject aizu;   // 紋章の上にある影を消す合図用のオブジェクト

    public bool answer = false;

    int crear = 0;
    int Allcrear = 4;

	void Update () {
		
        if(answer)
        {
            crear = crear + 1;
            answer = false;
        }

        if(crear == Allcrear)
        {
            doorL.GetComponent<DoorCastle>().open = true;
            doorR.GetComponent<DoorCastle>().open = true;
            Destroy(aizu.gameObject);
        }

	}
}
