using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// マウスに対する影の動きについてのスクリプト
public class ShadowSelect : MonoBehaviour
{

    Collider2D col;
    Rigidbody2D rb;

    public GameObject whiteFrash;
    public GameObject whiteSelect;
    public GameObject mapping;
    public string TagName = "GrassPosition";
    public bool selectON;          // CursorColliderから命令（選択対象決定）
    public bool frashDelete;       // CursorColliderから命令（フラッシュを消す）

    private Vector3 positionV3;    // 位置座標
    private Vector3 posWorld;      // スクリーン座標をワールド座標に変換した位置座標

    bool One = true;               // whiteFrashのInstantiateを一回呼ぶ
    bool Two = false;              // whiteSelect,mappingのInstantiateを一回呼ぶ
    bool Three = false;            // 選択した影を移動させるかどうか
    bool KeyX = false;             // すでに選択したがどうか → 解除許可
    bool WFobjBool = false;        // whiteFrashのクローンがいるかどうか
    bool shadowMouseOver = false;  // マウスオーバーしたかどうか

    void Start()
    {
        col = GetComponent<Collider2D>();
        rb = GetComponent<Rigidbody2D>();

        col.isTrigger = true;   // Trigger ON 
        rb.gravityScale = 0f;   // 重力 = 0
        rb.simulated = false;
        rb.constraints = RigidbodyConstraints2D.FreezeAll;
        selectON = false;
        frashDelete = false;
    }

    void Update()
    {
        var map = GameObject.FindGameObjectWithTag("Mapping");
        var StartObj = GameObject.FindGameObjectWithTag(TagName);

        if (Input.GetKey(KeyCode.RightArrow) ||
            Input.GetKey(KeyCode.LeftArrow))
        {
            rb.simulated = false;
        }
        
        if (Cursor.visible == true)
        {
            rb.simulated = true;
        }else{
            // クローンを消す
            var obj2 = GameObject.FindGameObjectWithTag("WhiteFrash");
            Destroy(obj2);
            WFobjBool = false;
            Three = false;
        }

        // 選択中
        if (shadowMouseOver)
        {
            // 選択範囲に入った時に点滅する
            if (One && !map &&
                Cursor.visible == true &&
                GameObject.FindGameObjectWithTag("WhiteFrash") == false)
            {
                GameObject WFobj = Instantiate(whiteFrash,
                                   this.transform.position,
                                   Quaternion.identity);
                WFobj.transform.parent = this.transform;  // 子オブジェクトとして生成
                WFobjBool = true;
                One = false;
            }

            // 影を選択した時
            if (selectON &&
                GameObject.FindGameObjectWithTag("Mapping") == false) // + Two
            {
                Two = true;
                Three = true;

                if (WFobjBool &&
                    Cursor.visible == true ||
                    frashDelete)
                {
                    // クローンを消す
                    var obj = GameObject.FindGameObjectWithTag("WhiteFrash");
                    Destroy(obj);
                    WFobjBool = false;
                    frashDelete = false;
                }
            }

            if (Two)
            {
                GameObject WSobj = Instantiate(whiteSelect,
                                   this.transform.position,
                                   Quaternion.identity);
                GameObject MAPobj = Instantiate(mapping,
                                    this.transform.position,
                                    Quaternion.identity);
                WSobj.transform.parent = this.transform;    //子オブジェクトとして生成
                MAPobj.transform.parent = this.transform;   //子オブジェクトとして生成
                rb.constraints = RigidbodyConstraints2D.None;
                Two = false;
                KeyX = true;
            }

            // マウスを離す選択解除
            if (!selectON && KeyX)
            {
                if (Three)
                {
                    col.isTrigger = false;
                    rb.gravityScale = 0.5f;

                    if (this.transform.position.y < 0)
                    {
                        col.isTrigger = false;
                    }
                }

                // クローンを消す
                var obj2 = GameObject.FindGameObjectWithTag("WhiteFrash");
                Destroy(obj2);
                shadowMouseOver = false;
                WFobjBool = false;
                Three = false;
                KeyX = false;
            }
        }

        if (!shadowMouseOver)
        {
            if (WFobjBool)
            {
                // クローンを消す
                var obj = GameObject.FindGameObjectWithTag("WhiteFrash");
                Destroy(obj);
                WFobjBool = false;
                One = true;
            }
        }

        // 落ちた後最初の位置に戻る
        if (this.transform.position.y < -10)
        {
            this.transform.position = StartObj.transform.position;
            this.transform.rotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
            this.rb.velocity = Vector2.zero;
            col.isTrigger = true;
            rb.simulated = false;
            rb.gravityScale = 0f;
            rb.constraints = RigidbodyConstraints2D.FreezeAll;
        }
    }

    // ※OnTriggerStay2Dは接触している間に処理される。
    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Cursor" &&
            GameObject.FindGameObjectWithTag("WhiteFrash") == false)
        {
            shadowMouseOver = true;
        }
    }

    // ※OnTriggerExit2Dは接触して離れた時に処理する。
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Cursor")
        {
            if (!One)
            {
                shadowMouseOver = false;
                One = true;
            }
        }

        if (collision.gameObject.tag == "Ground")
        {
            rb.simulated = false;
        }
    }
}
