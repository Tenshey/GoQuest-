using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXManager : MonoBehaviour {

    public AudioSource playerHurt;
    public AudioSource playerDead;
    public AudioSource playerAttack;
    private static bool sfxExists;

	// Use this for initialization
	void Start () {

        if (!sfxExists)
        {
            sfxExists = true;
            DontDestroyOnLoad(transform.root.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
