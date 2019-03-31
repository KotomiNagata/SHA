using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;                 // Sliderを入れるための準備

public class MP : MonoBehaviour {

    Slider mpSlider;
    CursorSetting cursor;
    private float maxMP = 5f;  // 最大MP
    private float nowMP;       // MP
    float minusMP = 1f;

    void Start () {
        mpSlider = this.gameObject.GetComponent<Slider>();
        cursor = FindObjectOfType<CursorSetting>();
        mpSlider.value = maxMP;
        nowMP = maxMP;
    }
	
	void Update () {

        mpSlider.value = nowMP;

        if (Cursor.visible == true)
        {
            nowMP = nowMP - Time.deltaTime * minusMP;
            if(nowMP <= 0f)
            {
                cursor.cursorOFF = true;
            }
        }
        if (Cursor.visible == false)
        {
            nowMP = maxMP;
        }
    }
}
