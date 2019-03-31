using UnityEngine;

public class PlayerDamage : MonoBehaviour {

    Rigidbody2D rb;
    SubBoss1 sb;
    HP hp;

    public GameObject player;
    public GameObject gameoverObj;
    public bool right;

    bool one = true;
    //bool two = true;
    int run = 0;
    float speed = 6;     // 移動スピード

    void Start () {
        this.rb = GetComponent<Rigidbody2D>();
        sb = FindObjectOfType<SubBoss1>();
        hp = FindObjectOfType<HP>();
        sb.playerAttack = true;

        if (right) {run = -1;}
        else {run = 1;}

        rb.velocity = new Vector2(run * speed, rb.velocity.y);
        hp.HPdamage = true;
    }

    void OnAnimationFinish()
    {
            if (one)
            {
                Instantiate(player, this.transform.position, Quaternion.identity);
                one = false;
            }
            Destroy(gameObject);
    }
}
