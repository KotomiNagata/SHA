using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossLife : MonoBehaviour {

    public int life = 3;
    public bool minusLife = false;  // ダメージ受けるごとにライフから−１
    public bool bossLose = false;   // ボスのライフがなくなったときTrueへ

	void Update ()
    {
		if(minusLife)
        {
            life = life - 1;
            minusLife = false;
        }
        if(life == 0)
        {
            bossLose = true;
        }
	}
}
