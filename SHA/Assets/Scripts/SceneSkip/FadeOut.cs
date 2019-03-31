using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeOut : MonoBehaviour {
    private Renderer rend;
    private Color color;
    float C;

    void Start()
    {
        rend = GetComponent<Renderer>();
        C = 1;
    }

    void Update()
    {
        C = C - Time.deltaTime * 1f;
        rend.material.color = new Color(1f, 1f, 1f, C);
        if (C < 0)
        {
            Destroy(gameObject);
        }
    }
}
