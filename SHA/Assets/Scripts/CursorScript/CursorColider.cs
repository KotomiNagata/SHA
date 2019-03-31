using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// カーソルのColliderについてのスクリプト
// 影を移動させる機能あり
public class CursorColider : MonoBehaviour {

    Collider2D col;
    AudioSource sound01;

    private Vector3 positionV3;        // 位置座標
    private Vector3 posWorld;          // スクリーン座標をワールド座標に変換した位置座標
    // private Vector3 ColObj;         // 選択したオブジェクトの位置取得

    public GameObject result = null;   // Colliderで当たったオブジェクトを取得するための準備
    public bool ShadowObjectIn = true; // 影のオブジェクトがあるステージなのか
    public bool BossIn;                // Bossのいるステージなのか
    public bool ShadowSelectScript = true;   // スクリプト確認
    public bool ShadowSelectScript2 = false;

    bool on = false;                   // カーソルが表示されているか
    bool OtherShaSelect = false;       // 他のオブジェクトが選ばれていないか

    void Start()
    {
        col = GetComponent<Collider2D>();
        col.enabled = !col.enabled;
        sound01 = GetComponent<AudioSource>();
    }

	void Update ()
    {
        // Vector3でマウス位置座標を取得する
        positionV3 = Input.mousePosition;
        // Z軸修正
        positionV3.z = 10f;
        // マウス位置座標をスクリーン座標からワールド座標に変換する
        posWorld = Camera.main.ScreenToWorldPoint(positionV3);
        // ワールド座標に変換されたマウス座標を代入
        gameObject.transform.position = posWorld;

        // ColliderのON,OFF切り替え
        if (Cursor.visible == true)
        {
            if (!on)
            {
                col.enabled = !col.enabled;
                on = true;
            }
        }
        if(Cursor.visible == false)
        {
            if(on)
            {
                col.enabled = !col.enabled;
                on = false;
            }
        }

        // カーソルをクリック → 押しっぱなしの流れ
        if (Input.GetMouseButton(0))
        {
            // 選択した影とカーソルの座標を一緒にする
            if (ShadowObjectIn)
            {
                sound01.PlayOneShot(sound01.clip);
                result.gameObject.transform.position = posWorld;
                if(ShadowSelectScript)
                {
                    result.GetComponent<ShadowSelect>().selectON = true;
                }
                if(ShadowSelectScript2){
                    result.GetComponent<ShadowSelect2>().selectON = true;
                }
                
            }
            if (BossIn)
            {
                sound01.PlayOneShot(sound01.clip);
                result.gameObject.transform.position = posWorld;
            }
        }

        // カーソルを離した時の流れ
        if (Input.GetMouseButtonUp(0))
        {
            if(ShadowObjectIn)
            {
                if(ShadowSelectScript)
                {
                    result.GetComponent<ShadowSelect>().selectON = false;
                }
                if(ShadowSelectScript2)
                {
                    result.GetComponent<ShadowSelect2>().selectON = false;
                }
            }
        }

    }

    // ※OnTriggerStay2Dは接触している間に処理される。
    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Shadow")
        {
            if (!OtherShaSelect)
            {
                OtherShaSelect = true;
                result = collision.transform.gameObject;
            }
        }

        if (collision.gameObject.tag == "Boss")
        {
            if (!OtherShaSelect)
            {
                OtherShaSelect = true;
                result = collision.transform.gameObject;
            }
        }
    }

    // ※OnTriggerExit2Dは接触して離れた時に処理する。
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Shadow")
        {
            if (OtherShaSelect)
            {
                OtherShaSelect = false;
                result = null;
                if(ShadowSelectScript)
                {
                    result.GetComponent<ShadowSelect>().frashDelete = true;
                }
                if(ShadowSelectScript2)
                {
                    result.GetComponent<ShadowSelect2>().frashDelete = true;
                }
            }
        }
        if (collision.gameObject.tag == "Boss")
        {
            if (OtherShaSelect)
            {
                OtherShaSelect = false;
                result = null;
            }
        }
    }

}
