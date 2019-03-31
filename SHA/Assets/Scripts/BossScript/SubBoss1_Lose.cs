using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SubBoss1_Lose : MonoBehaviour {

    private Renderer rend;
    private Color color;
    int colorRed = 0;
    float C;

    void Start () {
        rend = GetComponent<Renderer>();
        StartCoroutine("Lose");
    }

    void Update()
    {
        Unappean();
    }

    private IEnumerator Lose()
    {
        yield return new WaitForSeconds(3f);
        Destroy(gameObject);
    }

    void Unappean()
    {
        switch (colorRed)
        {
            case 0:
                C = C - Time.deltaTime * 20f;
                rend.material.color = new Color(1f, 1f, 1f, C);
                if (C < 0)
                {
                    colorRed = 1;
                }
                break;

            case 1:
                C = C + Time.deltaTime * 20f;
                rend.material.color = new Color(1f, 1f, 1f, C);
                if (0.5 < C)
                {
                    colorRed = 0;
                }
                break;
        }
    }
}
