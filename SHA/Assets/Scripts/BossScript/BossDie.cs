using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossDie : MonoBehaviour {

    Door_Boss1 door;

    void Start()
    {
        door = FindObjectOfType<Door_Boss1>();
    }

    //アニメーションが終わった後に削除
    void OnAnimationFinish()  
    {
        door.open = true;
        Destroy(gameObject);
    }
}
