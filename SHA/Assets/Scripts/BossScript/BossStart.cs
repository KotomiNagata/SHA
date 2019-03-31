using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossStart : MonoBehaviour
{

    private PlayerBoss player;
    Animator animator;        // アニメーション設定
    AudioSource sound01;

    public float playerPosX = -4;
    public GameObject SubBoss;
    public GameObject bossMove;

    string state;             // 見た目の切り替え
    string prevState;         // 前の状態を保存
    bool one = true;                 // SubBoss呼び出しのため

    void Start()
    {
        player = FindObjectOfType<PlayerBoss>();
        sound01 = GetComponent<AudioSource>();
        this.animator = GetComponent<Animator>();

        state = "USUALLY";
    }

    private void Update()
    {
        ChangeAnimation();

        if (player.transform.position.x > playerPosX)
        {
            StartCoroutine("Action");
            player.running = false;
        }
    }

    private IEnumerator Action()
    {
        state = "HAND";
        yield return new WaitForSeconds(2f);
        state = "ATTACK";
        sound01.PlayOneShot(sound01.clip);
        yield return new WaitForSeconds(2f);
        if (one)
        {
            Instantiate(SubBoss);
            one = false;
        }
        yield return new WaitForSeconds(0.5f);
        Instantiate(bossMove, this.transform.position, Quaternion.identity);
        player.running = true;
        Destroy(gameObject);
    }

    void ChangeAnimation()
    {
        if (prevState != state)
        {
            switch (state)
            {
                case "USUALLY":
                    animator.SetBool("isUsually", true);
                    animator.SetBool("isHand", false);
                    animator.SetBool("isAttack", false);
                    break;

                case "HAND":
                    animator.SetBool("isUsually", false);
                    animator.SetBool("isHand", true);
                    animator.SetBool("isAttack", false);
                    break;

                case "ATTACK":
                    animator.SetBool("isUsually", false);
                    animator.SetBool("isHand", false);
                    animator.SetBool("isAttack", true);
                    break;
            }
            // 状態の変更を判定するために状態を保存しておく
            prevState = state;
        }
    }

}
