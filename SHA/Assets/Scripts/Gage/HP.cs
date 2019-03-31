using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;                 // Sliderを入れるための準備

public class HP : MonoBehaviour {

    Slider hpSlider;
    PlayerDamage player;

    private float maxHP = 10f;  // 最大HP
    private float nowHP;       // HP

    public GameObject gameover;
    public bool HPdamage = false;
    public bool BossIn = true;

    bool one = true;

    void Start()
    {
        hpSlider = this.gameObject.GetComponent<Slider>();

        hpSlider.value = maxHP;
        nowHP = maxHP;
    }

    void Update()
    {

        hpSlider.value = nowHP;

        if(nowHP <= 0)
        {
            if(BossIn)
            {
                Destroy(FindObjectOfType<PlayerDamage>().gameObject);
            }else{
                Destroy(FindObjectOfType<PlayerFree>().gameObject);
            }
            if(one)
            {
                Instantiate(gameover);
                one = false;
            }
        }

        if(HPdamage)
        {
            nowHP = nowHP - 1;
            HPdamage = false;
        }

    }
}
