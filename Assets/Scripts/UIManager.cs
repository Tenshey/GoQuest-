using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class UIManager : MonoBehaviour {

    public Slider healthBar;
    public Text HPText;
    public PlayerHelathManager playerHealth;
    private static bool UIExists;

    public Text LevelText;
   

    private PlayerStats thePS;
    



	// Use this for initialization
	void Start () {
        if (!UIExists)
        {
            UIExists = true;
            DontDestroyOnLoad(transform.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        thePS = GetComponent<PlayerStats>();
    }
	
	// Update is called once per frame
	void Update () {
        healthBar.maxValue = playerHealth.playerMaxHealth;
        healthBar.value = playerHealth.playerCurrentHealth;
        HPText.text = "HP: " + playerHealth.playerCurrentHealth + "/" + playerHealth.playerMaxHealth;
        LevelText.text = "Lvl: " + thePS.currentLevel;
        
    }
}
