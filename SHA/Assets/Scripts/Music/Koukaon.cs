using UnityEngine;
using System.Collections;

public class Koukaon : MonoBehaviour
{

    private AudioSource sound01;

    void Start()
    {
        sound01 = GetComponent<AudioSource>();
        sound01.PlayOneShot(sound01.clip);
    }
}

