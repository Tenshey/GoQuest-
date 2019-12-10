﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeController : MonoBehaviour {

    private AudioSource theAudio;

    private float audioLevel;
    public float defaultAudio;

	// Use this for initialization
	void Start () {
        theAudio = FindObjectOfType<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    public void SetAudioLevel(float volume)
    {

        if(theAudio == null)
        {
            theAudio = GetComponent<AudioSource>();
        }
        audioLevel = defaultAudio * volume;
        theAudio.volume = audioLevel;
    }
}
