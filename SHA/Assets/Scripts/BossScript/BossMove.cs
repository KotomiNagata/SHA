using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMove : MonoBehaviour
{
    PlayerBoss player;
    BossPosition posC;
    SubBoss1 sb;
    float speed = 2f;
    bool one = true;

    public GameObject bossDamage;

    void Start()
    {
        player = FindObjectOfType<PlayerBoss>();
        posC = FindObjectOfType<BossPosition>();
        sb = FindObjectOfType<SubBoss1>();
    }


    void Update()
    {
        Move();
        Right();
    }

    void Move()
    {
        GameObject target = GameObject.Find("BossPosition");
        float step = Time.deltaTime * speed;
        transform.position = Vector3.MoveTowards(
            transform.position,
            target.transform.position,
            step);
        if(FindObjectOfType<PlayerBoss>() == true)
        {
            player.GetComponent<PlayerBoss>().running = true;
        }
    }

    void Right()
    {
        Vector3 scale = transform.localScale;

        if (this.transform.position.x > posC.transform.position.x)
        {
            scale.x = 2; //（右向き）
        }
        else
        {
            scale.x = -2; //（左向き）
        }
        // 代入し直す
        transform.localScale = scale;
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "SubBoss")
        {
            if(sb.state == "ATTACK")
            {
                if (one)
                {
                    Instantiate(bossDamage);
                    one = false;
                }
                sb.playerAttack = true;
                Destroy(gameObject);
            }
        }
    }
}
