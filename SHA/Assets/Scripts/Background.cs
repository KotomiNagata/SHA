using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 背景の動きの設定(Playerに命令あり)
public class Background : MonoBehaviour {

    Rigidbody2D rb;
    int run = 0;
    PlayerBackground player;

    // スクロールするスピード
    public float speed = 5f;
    public float rightWall = -6.6f;
    public float leftWall = 6.6f;
    public bool Front = false;    // Backgroundの中のFrontに当てはまるか
    bool playerRun;

	void Start()
	{
        this.rb = GetComponent<Rigidbody2D>();
        player = FindObjectOfType<PlayerBackground>();
	}

	void Update()
    {
        if (Cursor.visible == false)
        {
            if (Front)
            {
                BF();
            }

            if (!Front)
            {
                Usually();
            }
        }

        if (playerRun)
        {
            player.GetComponent<PlayerBackground>().move = true;
        }

    }

    void BF()
    {
        run = 0;
        playerRun = false;

        if (Input.GetKey(KeyCode.RightArrow))
        {
            run = -1;
            playerRun = false;
            if (transform.position.x < rightWall || player.transform.position.x < -4)
            {
                run = 0;
                playerRun = true;
            }
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            run = 1;
            playerRun = false;
            if (leftWall < transform.position.x || player.transform.position.x > -4)
            {
                run = 0;
                playerRun = true;
            }
        }

        rb.velocity = new Vector2(run * speed, rb.velocity.y);

    }

    void Usually()
    {
        run = 0;
       
        if (Input.GetKey(KeyCode.RightArrow))
        {
            run = -1;
            if (transform.position.x < rightWall || player.transform.position.x < -4)
            {
                run = 0;
            }
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            run = 1;
            if (leftWall < transform.position.x || player.transform.position.x > -4)
            {
                run = 0;
            }
        }

        rb.velocity = new Vector2(run * speed, rb.velocity.y);

    }

}
