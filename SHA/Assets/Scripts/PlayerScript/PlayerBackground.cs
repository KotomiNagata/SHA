using UnityEngine;

public class PlayerBackground : MonoBehaviour {
    
    Animator animator;
    Rigidbody2D rb;

    public float speed = 5;     // 移動スピード
    public float jump = 100;    // ジャンプの威力
    bool isGrounded = false;    // 地面についているかどうか
    public bool right = true;   // 右に向いているかどうか
    public bool move;           // Backgroundからプレイヤーの走行を許可
    bool playerJump = true;     // ジャンプしてもいいかどうか 
    int run = 0;                // 左右の移動管理

    private Vector3 M_pos;      // マウスの位置取得
    private Vector3 M_WorldPos; // マウスの位置をワールドに変換するための準備

    string state;             // 見た目の切り替え
    string prevState;         // 前の状態を保存

	void Start () {
        this.rb = GetComponent<Rigidbody2D>();
        this.animator = GetComponent<Animator>();
	}

    void Update()
    {
        ChangeAnimation();               // アニメーション設定
        Movement();                      // 移動設定
        M_pos = Input.mousePosition;     // マウスの位置座標をVector3で取得
        // M_WorldPos = Camera.main.ScreenToWorldPoint(M_pos);

        move = false;
    }

    void Movement()
    {
        // 静止状態
        if (right)
        {
            state = "StandRight";
            right = true;
            run = 0;
        }
        if (!right)
        {
            state = "StandLeft";
            right = false;
            run = 0;
        }

        // 右ボタンを押したら右に進む
        if (Input.GetKey(KeyCode.RightArrow))
        {
            state = "RunRight";
            right = true;
            if (move)
            {
                run = 1;
            }
        }

        // 左ボタンを押したら左に進む
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            state = "RunLeft";
            right = false;

            if (move)
            {
                run = -1;
            }
        }

        if (isGrounded)
        {
            // 上ボタンを押したらジャンプする
            if (Input.GetKey(KeyCode.UpArrow) && playerJump == true)
            {
                rb.AddForce(Vector2.up * jump);

                if (right)
                {
                    state = "JumpRight";
                    right = true;
                }
                if (!right)
                {
                    state = "JumpLeft";
                    right = false;
                }
                isGrounded = false;
            }

            // カーソルが表れている間、能力発動時のアニメーション設定とプレイヤー移動設定
            if (Cursor.visible == true)
            {
                run = 0;
                playerJump = false;
                move = false;

                Vector2 P_pos = this.gameObject.transform.position; // Playerの位置情報を取得
                if (P_pos.x + 7 < M_pos.x / 36.5)
                {
                    state = "SpecialRight";
                    right = true;
                }
                if (M_pos.x / 36.5 < P_pos.x + 7)
                {
                    state = "SpecialLeft";
                    right = false;
                }
            }

            if(Cursor.visible == false)
            {
                playerJump = true;
            }

        }

        if (!isGrounded)
        {
            // 上昇中
            if (rb.velocity.y > 0)
            {
                if (right)
                {
                    state = "JumpRight";
                    right = true;
                }
                if (!right)
                {
                    state = "JumpLeft";
                    right = false;
                }
            }
            // 下降中
            else if (rb.velocity.y < 0)
            {
                if (right)
                {
                    state = "FallRight";
                    right = true;
                }
                if (!right)
                {
                    state = "FallLeft";
                    right = false;
                }
            }
        }

        //移動
        rb.velocity = new Vector2(run * speed, rb.velocity.y);
    }

    void ChangeAnimation()
    {
        if (prevState != state)
        {
            switch (state)
            {
                case "StandRight":
                    animator.SetBool("isStandRight", true); //t
                    animator.SetBool("isStandLeft", false);
                    animator.SetBool("isRunRight", false);
                    animator.SetBool("isRunLeft", false);
                    animator.SetBool("isJumpRight", false);
                    animator.SetBool("isFallRight", false);
                    animator.SetBool("isJumpLeft", false);
                    animator.SetBool("isFallLeft", false);
                    animator.SetBool("isDamageRight", false);
                    animator.SetBool("isDamageLeft", false);
                    animator.SetBool("isSpecialRight", false);
                    animator.SetBool("isSpecialLeft", false);
                    break;

                case "StandLeft":
                    animator.SetBool("isStandRight", false);
                    animator.SetBool("isStandLeft", true);   //t
                    animator.SetBool("isRunRight", false);
                    animator.SetBool("isRunLeft", false);
                    animator.SetBool("isJumpRight", false);
                    animator.SetBool("isFallRight", false);
                    animator.SetBool("isJumpLeft", false);
                    animator.SetBool("isFallLeft", false);
                    animator.SetBool("isDamageRight", false);
                    animator.SetBool("isDamageLeft", false);
                    animator.SetBool("isSpecialRight", false);
                    animator.SetBool("isSpecialLeft", false);
                    break;

                case "RunRight":
                    animator.SetBool("isStandRight", false);
                    animator.SetBool("isStandLeft", false);
                    animator.SetBool("isRunRight", true);  //t
                    animator.SetBool("isRunLeft", false);
                    animator.SetBool("isJumpRight", false);
                    animator.SetBool("isFallRight", false);
                    animator.SetBool("isJumpLeft", false);
                    animator.SetBool("isFallLeft", false);
                    animator.SetBool("isDamageRight", false);
                    animator.SetBool("isDamageLeft", false);
                    animator.SetBool("isSpecialRight", false);
                    animator.SetBool("isSpecialLeft", false);
                    break;

                case "RunLeft":
                    animator.SetBool("isStandRight", false);
                    animator.SetBool("isStandLeft", false);
                    animator.SetBool("isRunRight", false);
                    animator.SetBool("isRunLeft", true);  //t
                    animator.SetBool("isJumpRight", false);
                    animator.SetBool("isFallRight", false);
                    animator.SetBool("isJumpLeft", false);
                    animator.SetBool("isFallLeft", false);
                    animator.SetBool("isDamageRight", false);
                    animator.SetBool("isDamageLeft", false);
                    animator.SetBool("isSpecialRight", false);
                    animator.SetBool("isSpecialLeft", false);
                    break;

                case "JumpRight":
                    animator.SetBool("isStandRight", false);
                    animator.SetBool("isStandLeft", false);
                    animator.SetBool("isRunRight", false);
                    animator.SetBool("isRunLeft", false);
                    animator.SetBool("isJumpRight", true);  //t
                    animator.SetBool("isFallRight", false);
                    animator.SetBool("isJumpLeft", false);
                    animator.SetBool("isFallLeft", false);
                    animator.SetBool("isDamageRight", false);
                    animator.SetBool("isDamageLeft", false);
                    animator.SetBool("isSpecialRight", false);
                    animator.SetBool("isSpecialLeft", false);
                    break;

                case "FallRight":
                    animator.SetBool("isStandRight", false);
                    animator.SetBool("isStandLeft", false);
                    animator.SetBool("isRunRight", false);
                    animator.SetBool("isRunLeft", false);
                    animator.SetBool("isJumpRight", false);
                    animator.SetBool("isFallRight", true);  //t
                    animator.SetBool("isJumpLeft", false);
                    animator.SetBool("isFallLeft", false);
                    animator.SetBool("isDamageRight", false);
                    animator.SetBool("isDamageLeft", false);
                    animator.SetBool("isSpecialRight", false);
                    animator.SetBool("isSpecialLeft", false);
                    break;

                case "JumpLeft":
                    animator.SetBool("isStandRight", false);
                    animator.SetBool("isStandLeft", false);
                    animator.SetBool("isRunRight", false);
                    animator.SetBool("isRunLeft", false);
                    animator.SetBool("isJumpRight", false);
                    animator.SetBool("isFallRight", false);
                    animator.SetBool("isJumpLeft", true);  //t
                    animator.SetBool("isFallLeft", false);
                    animator.SetBool("isDamageRight", false);
                    animator.SetBool("isDamageLeft", false);
                    animator.SetBool("isSpecialRight", false);
                    animator.SetBool("isSpecialLeft", false);
                    break;

                case "FallLeft":
                    animator.SetBool("isStandRight", false);
                    animator.SetBool("isStandLeft", false);
                    animator.SetBool("isRunRight", false);
                    animator.SetBool("isRunLeft", false);
                    animator.SetBool("isJumpRight", false);
                    animator.SetBool("isFallRight", false);
                    animator.SetBool("isJumpLeft", false);
                    animator.SetBool("isFallLeft", true);  //t
                    animator.SetBool("isDamageRight", false);
                    animator.SetBool("isDamageLeft", false);
                    animator.SetBool("isSpecialRight", false);
                    animator.SetBool("isSpecialLeft", false);
                    break;

                case "DamageRight":
                    animator.SetBool("isStandRight", false);
                    animator.SetBool("isStandLeft", false);
                    animator.SetBool("isRunRight", false);
                    animator.SetBool("isRunLeft", false);
                    animator.SetBool("isJumpRight", false);
                    animator.SetBool("isFallRight", false);
                    animator.SetBool("isJumpLeft", false);
                    animator.SetBool("isFallLeft", false);
                    animator.SetBool("isDamageRight", true);  //t
                    animator.SetBool("isDamageLeft", false);
                    animator.SetBool("isSpecialRight", false);
                    animator.SetBool("isSpecialLeft", false);
                    break;

                case "DamageLeft":
                    animator.SetBool("isStandRight", false);
                    animator.SetBool("isStandLeft", false);
                    animator.SetBool("isRunRight", false);
                    animator.SetBool("isRunLeft", false);
                    animator.SetBool("isJampRight", false);
                    animator.SetBool("isFallRight", false);
                    animator.SetBool("isJampLeft", false);
                    animator.SetBool("isFallLeft", false);
                    animator.SetBool("isDamageRight", false);
                    animator.SetBool("isDamageLeft", true);  //t
                    animator.SetBool("isSpecialRight", false);
                    animator.SetBool("isSpecialLeft", false);
                    break;

                case "SpecialRight":
                    animator.SetBool("isStandRight", false);
                    animator.SetBool("isStandLeft", false);
                    animator.SetBool("isRunRight", false);
                    animator.SetBool("isRunLeft", false);
                    animator.SetBool("isJumpRight", false);
                    animator.SetBool("isFallRight", false);
                    animator.SetBool("isJumpLeft", false);
                    animator.SetBool("isFallLeft", false);
                    animator.SetBool("isDamageRight", false);
                    animator.SetBool("isDamageLeft", false);
                    animator.SetBool("isSpecialRight", true);  //t
                    animator.SetBool("isSpecialLeft", false);
                    break;

                case "SpecialLeft":
                    animator.SetBool("isStandRight", false);
                    animator.SetBool("isStandLeft", false);
                    animator.SetBool("isRunRight", false);
                    animator.SetBool("isRunLeft", false);
                    animator.SetBool("isJumpRight", false);
                    animator.SetBool("isFallRight", false);
                    animator.SetBool("isJumpLeft", false);
                    animator.SetBool("isFallLeft", false);
                    animator.SetBool("isDamageRight", false);
                    animator.SetBool("isDamageLeft", false);
                    animator.SetBool("isSpecialRight", false);
                    animator.SetBool("isSpecialLeft", true);  //t
                    break;

            }
            // 状態の変更を判定するために状態を保存しておく
            prevState = state;
        }
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        // 地面に足がついているかどうか
        if (collision.gameObject.tag == "Ground")
        {
            if (!isGrounded)
                isGrounded = true;
        }

        // エネミーにぶつかったかどうか
        if (collision.gameObject.tag == "Enemy")
        {
            if (run == 1)
            {
                state = "DamageRight";
            }
            if (run == -1)
            {
                state = "DamageLeft";
            }
        }

    }

}
