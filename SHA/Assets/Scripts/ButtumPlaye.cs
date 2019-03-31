using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;    //シーン切り替えのための準備

public class ButtumPlaye : MonoBehaviour {

    public GameObject FadeIn;
    bool one = true;

    /// ボタンをクリックした時の処理
    public void OnClick()
    {
        StartCoroutine("Action");
    }

    private IEnumerator Action()
    {
        if (one)
        {
            Instantiate(FadeIn);
            one = false;
        }
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("1_DarkForest");
        Destroy(gameObject);
    }
}
