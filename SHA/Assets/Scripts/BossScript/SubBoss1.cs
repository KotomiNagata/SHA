using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubBoss1 : MonoBehaviour
{
    Rigidbody2D rb;
    BossLife life;
    Key key;
    AudioSource sound01;

    public GameObject lose;
    public float walking = 1;
    public float running = 5;
    public bool playerAttack = false; //PlayerBoss,Bossから命令
    float AttackMove;           // 攻撃移動の準備
    int run = 0;                // 左右の移動管理
    bool one = false;           // Invoke管理
    bool two = false;           // 攻撃の方向管理
    bool three = true;          // ボス死ぬクローンを１回作る

    public float timeOut = 5f;  // 指定した時間
    private float timeElapsed;  // 現在の時間

    Animator animator;          // アニメーション設定
    public string state;               // 見た目の切り替え
    string prevState;           // 前の状態を保存

    void Start()
    {
        this.animator = GetComponent<Animator>();
        this.rb = GetComponent<Rigidbody2D>();
        life = FindObjectOfType<BossLife>();
        key = FindObjectOfType<Key>();
        sound01 = GetComponent<AudioSource>();
        state = "USUALLY";
    }


    void Update()
    {
        ChangeAnimation();
        SubBossAttack();
        timeElapsed += Time.deltaTime;

        if (life.bossLose)
        {
            if(three)
            {
                Instantiate(lose, this.transform.position, Quaternion.identity);
                three = false;
            }
            Destroy(gameObject);
        }
    }

    void SubBossAttack()
    {
        Vector3 scale = transform.localScale;

        if (this.transform.position.x > key.transform.position.x)
        {
            run = -1;
        }
        if (this.transform.position.x < key.transform.position.x)
        {
            run = 1;
        }


        // 攻撃パターン変更
        if (timeElapsed >= timeOut)
        {
            one = !one;
            timeElapsed = 0.0f;
        }

        // 歩行パターン
        if (!one)
        {
            state = "USUALLY";
            AttackMove = 0;

            sound01.Stop();
            rb.velocity = new Vector2(run * walking, rb.velocity.y);
            two = true;
        }
        // 攻撃パターン
        if (one)
        {
            state = "ATTACK";
            if (two)
            {
                sound01.PlayOneShot(sound01.clip);
                if (run == 1)
                {
                    AttackMove = 1;
                    scale.x = -1.5f;
                }
                if (run == -1)
                {
                    AttackMove = -1;
                    scale.x = 1.5f;
                }
                two = false;
            }

            // すみっこまで走ったら歩行パターンへ移行
            if (this.transform.position.x < -6 ||
               this.transform.position.x > 4.8)
            {
                one = false;
                timeElapsed = 0.0f;
            }

            // もしPlayerかBossに当たったら歩行パターンへ移行
            if (playerAttack)
            {
                one = false;
                timeElapsed = 0.0f;
                playerAttack = false;
            }

            rb.velocity = new Vector2(AttackMove * running, rb.velocity.y);
            transform.localScale = scale;   // 左右方向を代入しなおす
        }
    }


    void ChangeAnimation()
    {
        if (prevState != state)
        {
            switch (state)
            {
                case "USUALLY":
                    animator.SetBool("isUsually", true);
                    animator.SetBool("isAttack", false);
                    break;

                case "ATTACK":
                    animator.SetBool("isUsually", false);
                    animator.SetBool("isAttack", true);
                    break;
            }
            // 状態の変更を判定するために状態を保存しておく
            prevState = state;
        }
    }
}
