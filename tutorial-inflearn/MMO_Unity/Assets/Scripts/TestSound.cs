﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSound : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public AudioClip audioClip;
    public AudioClip audioClip2;
    int i = 0;
    private void OnTriggerEnter(Collider other)
    {
        //AudioSource audio = GameObject.Find("UnityChan").GetComponent<AudioSource>();
        //AudioSource audio = GetComponent<AudioSource>();
        //audio.PlayOneShot(audioClip);
        //audio.PlayOneShot(audioClip2);
        //GameObject.Destroy(gameObject);
        i++;
        if(i%2==0)
            Managers.Sound.Play(audioClip, Define.Sound.Bgm);
        else
            Managers.Sound.Play(audioClip2, Define.Sound.Bgm);
    }
}
