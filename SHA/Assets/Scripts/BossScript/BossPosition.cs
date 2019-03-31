using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossPosition : MonoBehaviour {

    bool Position = false;

    void Update()
    {
        if (Position)
        {
            //オブジェクトの座標
            float x = Random.Range(-5.0f, 5.0f);
            float y = Random.Range(-0.5f, -4.0f);

            this.transform.position = new Vector3(x, y, this.transform.position.z);
            Position = false;
        }
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Boss")
        {
            Position = true;
        }
    }
}
