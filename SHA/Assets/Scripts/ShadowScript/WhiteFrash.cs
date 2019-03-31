using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // 透過度変更のため

// 影とカーソルが重なる時に光るやつのコード
public class WhiteFrash : MonoBehaviour {

    Renderer rend;
    Color color;
    float alpha;
    int state;
    public bool frash = true;

    void Start()
    {
        rend = GetComponent<Renderer>();
        alpha = 1;
        state = 0;
    }

    void Update()
    {
        switch (state)
        {
            case 0:
                alpha = alpha - Time.deltaTime * 3f;
                rend.material.color = new Color(1f, 1f, 1f, alpha);
                if (alpha < 0)
                {
                    state = 1;
                }
                break;

            case 1:
                alpha = alpha + Time.deltaTime * 3f;
                rend.material.color = new Color(1f, 1f, 1f, alpha);
                if (1 < alpha)
                {
                    state = 0;
                }
                break;
        }

        if(!frash)
        {
            Destroy(this.gameObject);
        }
    }
}
