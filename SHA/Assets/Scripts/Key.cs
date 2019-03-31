using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// キーについてのスクリプト
public class Key : MonoBehaviour {

    Animator animator;
    PlayerBackground player1;
    PlayerBoss playerB;
    PlayerFree playerF;

    bool right = true;          // 右に向いているか
    public bool playerBackgroundScript = true;
    public bool playerBossScript = false;
    public bool playerFreeScript = false;
   
    string state;             // 見た目の切り替え
    string prevState;         // 前の状態を保存
    //state = "KeyUsually";

	void Start ()
    {
        this.animator = GetComponent<Animator>();
        if(playerBackgroundScript)
        {
            player1 = FindObjectOfType<PlayerBackground>();
        }
        if(playerBossScript)
        {
             playerB = FindObjectOfType<PlayerBoss>();
        }
        if (playerFreeScript)
        {
            playerF = FindObjectOfType<PlayerFree>();
        }
        state = "KeyUsually";
	}

    void Update()
    {
        Movement();
        LeftOrRight();
        ChangeAnimation();

        if (FindObjectOfType<PlayerBoss>() != true)//playerBossScript
        {
            playerB = null;
        }
    }

    void Movement()
    {
            GameObject target = GameObject.Find("KeyStopLeft");
            float speed = 3f;
            float step = Time.deltaTime * speed;
            transform.position = Vector3.MoveTowards(
                transform.position,
                target.transform.position,
                step);
    }

    // キャラの方向変換
    void LeftOrRight()
    {
        if(playerBackgroundScript)
        {
            if (this.transform.position.x > player1.transform.position.x)
            {
                right = true;
            }
            else
            {
                right = false;
            }

        }

        if (playerBossScript)
        {
            if (this.transform.position.x > playerB.transform.position.x)
            {
                right = true;
            }
            else
            {
                right = false;
            }
        }
        if (playerFreeScript)
        {
            if (this.transform.position.x > playerF.transform.position.x)
            {
                right = true;
            }
            else
            {
                right = false;
            }
        }

        if (right)
        {
            float k_size = 1f;
            Vector3 scale = this.gameObject.transform.localScale;
            gameObject.transform.localScale = new Vector3(
                k_size,
                scale.y,
                scale.z
        );
        }
        if(!right)
        {
            float k_size = -1f;
            Vector3 scale = this.gameObject.transform.localScale;
            gameObject.transform.localScale = new Vector3(
                k_size,
                scale.y,
                scale.z
        );
        }
    }

    void ChangeAnimation()
    {
        if (prevState != state)
        {
            switch (state)
            {
                case "KeyUsually":
                    animator.SetBool("isKeyUsually", false);
                    animator.SetBool("isKeyMuu", false);
                    animator.SetBool("isKeySad", false);
                    animator.SetBool("isKeySurprised", false);
                    animator.SetBool("isKeyCry", false);
                    break;

                case "KeyMuu":
                    animator.SetBool("isKeyUsually", false);
                    animator.SetBool("isKeyMuu", false);
                    animator.SetBool("isKeySad", false);
                    animator.SetBool("isKeySurprised", false);
                    animator.SetBool("isKeyCry", false);
                    break;

                case "KeySad":
                    animator.SetBool("isKeyUsually", false);
                    animator.SetBool("isKeyMuu", false);
                    animator.SetBool("isKeySad", false);
                    animator.SetBool("isKeySurprised", false);
                    animator.SetBool("isKeyCry", false);
                    break;

                case "KeySurprised":
                    animator.SetBool("isKeyUsually", false);
                    animator.SetBool("isKeyMuu", false);
                    animator.SetBool("isKeySad", false);
                    animator.SetBool("isKeySurprised", false);
                    animator.SetBool("isKeyCry", false);
                    break;

                case "KeyCry":
                    animator.SetBool("isKeyUsually", false);
                    animator.SetBool("isKeyMuu", false);
                    animator.SetBool("isKeySad", false);
                    animator.SetBool("isKeySurprised", false);
                    animator.SetBool("isKeyCry", false);
                    break;
            }
            // 状態の変更を判定するために状態を保存しておく
            prevState = state;
        }
    }
}
