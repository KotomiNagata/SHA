using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowBingo : MonoBehaviour {

    DoorBingo door;

    Vector3 pos;

    public GameObject shadow;
    public float minX;
    public float maxX;
    public float minY;
    public float maxY;

    bool one = true;
    bool Xcrear = false;
    bool Ycrear = false;

    void Start()
    {
        door = FindObjectOfType<DoorBingo>();
    }

    void Update () {
        pos = this.transform.position;

        if (minX < pos.x && pos.x < maxX)
        {
            Xcrear = true;
        }else{
            Xcrear = false;
        }

        if(minY < pos.y && pos.y < maxY)
        {
            Ycrear = true;
        }else{
            Ycrear = false;
        }

        if(Xcrear && Ycrear)
        {
            if (one)
            {
                Instantiate(shadow);
                door.answer = true;
                one = false;
            }
            Destroy(gameObject);
        }
	}
}
