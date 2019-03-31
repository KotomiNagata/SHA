using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowBridge : MonoBehaviour {

    public GameObject Obj1;
    public GameObject Obj2;

    bool g1 = false;
    bool g2 = false;
    bool g3 = false;

    bool one = true;
    bool two = true;
	
	void Update () {

        if(g1 && g2)
        {
            if(one)
            {
                Instantiate(Obj1);
                one = false;
            }
        }

        if(g2 && g3)
        {
            if(two)
            {
                Instantiate(Obj2);
                two = false;
            }
        }

        if(!g1 && !g3 || !g2)
        {
            if(!one)
            {
                var obj = GameObject.FindGameObjectWithTag("Bridge");
                Destroy(obj);
                one = true;
            }
            if(!two)
            {
                var obj = GameObject.FindGameObjectWithTag("Bridge");
                Destroy(obj);
                two = true;
            }
        }
	}

    // ※OnTriggerStay2Dは接触している間に処理される.
    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ground1")
        {
            g1 = true;
        }
        if (collision.gameObject.tag == "Ground2")
        {
            g2 = true;
        }
        if (collision.gameObject.tag == "Ground3")
        {
            g3 = true;
        }
    }

    // ※OnTriggerExit2Dは接触して離れた時に処理する.
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ground1")
        {
            g1 = false;
        }
        if (collision.gameObject.tag == "Ground2")
        {
            g2 = false;
        }
        if (collision.gameObject.tag == "Ground3")
        {
            g3 = false;
        }
    }
}
