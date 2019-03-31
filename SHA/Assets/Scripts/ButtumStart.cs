using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtumStart : MonoBehaviour
{

    public GameObject buttum;
    bool one = true;

    void Update()
    {
        StartCoroutine("Action");
    }
    private IEnumerator Action()
    {
        yield return new WaitForSeconds(2f);
        if(one)
        {
            Instantiate(buttum);
            one = false;
        }
        Destroy(gameObject);
    }
}
