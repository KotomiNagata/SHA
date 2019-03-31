using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door_Boss1 : MonoBehaviour {

    Collider2D col;
    Rigidbody2D rb;
    AudioSource sound01;
    public bool open = false;

    void Start()
    {
        col = GetComponent<Collider2D>();
        rb = GetComponent<Rigidbody2D>();
        sound01 = GetComponent<AudioSource>();
        rb.constraints = RigidbodyConstraints2D.FreezeAll;
    }

    void Update ()
    {
        if(open)
        {
            col.isTrigger = true;   // Trigger ON 
            rb.constraints = RigidbodyConstraints2D.None;
            GetComponent<Rigidbody2D>().velocity = transform.right.normalized * 2;
            sound01.PlayOneShot(sound01.clip);

            // Y = 6 を過ぎたらオブジェクトを削除
            if (8 < transform.position.x)
            {
                Destroy(gameObject);
            }
        }
	}
}
