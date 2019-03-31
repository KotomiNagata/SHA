using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;    //シーン切り替えのための準備

public class SceneSkip : MonoBehaviour {

    PlayerFree playerF;
    PlayerBoss playerB;

    public string SceneName;
    public GameObject fadeIn;
    public bool playerFreeScript;
    public bool playerBossScript;

    bool inP = false;
    bool one = true;

    void Start()
    {
        if(playerFreeScript)
        {
            playerF = FindObjectOfType<PlayerFree>();
        }
        if(playerBossScript)
        {
            playerB = FindObjectOfType<PlayerBoss>();
        }
    }

    void Update()
    {
        if(inP)
        {
            StartCoroutine("Action");
            if (playerFreeScript)
            {
                playerF.move = false;
            }
            if (playerBossScript)
            {
                playerB.running = false;
            }
        }
    }

    private IEnumerator Action()
    {
        if(one)
        {
            Instantiate(fadeIn);
            one = false;
        }
        yield return new WaitForSeconds(2f);
        //シーン切り替え
        SceneManager.LoadScene(SceneName);

    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            inP = true;
        }
    }

}
