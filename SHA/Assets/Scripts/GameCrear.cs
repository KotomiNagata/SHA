using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;    //シーン切り替えのための準備

public class GameCrear : MonoBehaviour {

    public GameObject text1;
    public GameObject text2;
    public GameObject text3;
    public GameObject FadeIn;

    bool one = true;
    bool two = true;
    bool three = true;
    bool four = true;

	void Update () {
        StartCoroutine("Action");
    }

    private IEnumerator Action()
    {
        yield return new WaitForSeconds(1f);
        if (one)
        {
            Instantiate(text1);
            one = false;
        }
        yield return new WaitForSeconds(1f);
        if(two)
        {
            Instantiate(text2);
            two = false;
        }
        yield return new WaitForSeconds(1f);
        if(three)
        {
            Instantiate(text3);
            three = false;
        }
        yield return new WaitForSeconds(5f);
        if(four)
        {
            Instantiate(FadeIn);
            four = false;
        }
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("0_Title");

    }


}
