using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameFinish : MonoBehaviour
{

    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            End();
        }
    }

    //　ゲーム終了ボタンを押したら実行する
    public void End()
    {

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#elif UNITY_WEBPLAYER
        Application.OpenURL("http://www.yahoo.co.jp/");
#else
        Application.Quit();
#endif
    }
}
