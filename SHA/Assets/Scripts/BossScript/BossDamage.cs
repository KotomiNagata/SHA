using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossDamage : MonoBehaviour {

    BossLife life;

    public GameObject bossMove;
    public GameObject bossDie;

    private Renderer rend;
    private Color color;
    int colorRed = 0;
    float red;
    bool one = true;

    void Start () {
        rend = GetComponent<Renderer>();
        life = FindObjectOfType<BossLife>();
        life.minusLife = true;
    }
	
	void Update () {
        switch (colorRed)
        {
            case 0:
                red = red - Time.deltaTime * 10f;
                rend.material.color = new Color(red, 1f, 1f, 1f);
                if (red < 0.5)
                {
                    colorRed = 1;
                }
                break;

            case 1:
                red = red + Time.deltaTime * 10f;
                rend.material.color = new Color(red, 1f, 1f, 1f);
                if (1 < red)
                {
                    colorRed = 0;
                }
                break;
        }
    }

    //アニメーションが終わった後に削除
    void OnAnimationFinish()
    {
        if(life.bossLose)
        {
            if(one)
            {
                Instantiate(bossDie, this.transform.position, Quaternion.identity);
                one = false;
            }
        }else{
            if(one)
            {
                Instantiate(bossMove, this.transform.position, Quaternion.identity);
                one = false;
            }
        }
        Destroy(this.gameObject);
    }
}
