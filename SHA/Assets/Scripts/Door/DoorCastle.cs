using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorCastle : MonoBehaviour {

    DoorBingo dr;
    AudioSource sound01;
    public bool open = false;
    public bool right = true;
    public GameObject doorIn;

    bool one = true;

    void Start ()
    {
        dr = FindObjectOfType<DoorBingo>();
        sound01 = GetComponent<AudioSource>();
    }
	
	void Update () {

        if(open)
        {
            if(right)
            {
                GetComponent<Rigidbody2D>().velocity = transform.right.normalized * 2;
                sound01.PlayOneShot(sound01.clip);
                if (this.transform.position.x > 22)
                {
                    Destroy(gameObject);
                }
            }
            if (!right)
            {
                GetComponent<Rigidbody2D>().velocity = transform.right.normalized * -2;
                if (this.transform.position.x < 12)
                {
                    if(one)
                    {
                        Instantiate(doorIn);
                        one = false;
                    }
                    Destroy(dr.gameObject);
                    Destroy(gameObject);
                }
            }
        }
		
	}
}
