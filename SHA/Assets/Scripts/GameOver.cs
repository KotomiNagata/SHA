using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;    //シーン切り替えのための準備

public class GameOver : MonoBehaviour
{

    public GameObject text;
    public GameObject buttum;

    bool one = true;
    bool two = true;

    void Update()
    {
        StartCoroutine("Action");

        if (Input.GetKeyDown(KeyCode.Space))
        {
            // シーン変わる
        }
    }

    private IEnumerator Action()
    {
        yield return new WaitForSeconds(1f);
        if(one)
        {
            Instantiate(text);
            one = false;
        }
        yield return new WaitForSeconds(1f);
        if(two)
        {
            Instantiate(buttum);
            two = false;
        }
        if(Input.GetKey(KeyCode.Space))
        {
            SceneManager.LoadScene("0_Title");
        }
    }
}
