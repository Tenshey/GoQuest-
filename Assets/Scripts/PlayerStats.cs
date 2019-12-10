using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour {

    public int currentLevel;

    public int currentExp;

    public int[] toLevelUp;

    public int[] HPLevels;

    public int[] attackLevels;

    public int[] defenceLevels;

    public int currentHP;
    public int currentAttack;
    public int currentDefence;

    private PlayerHelathManager thePlayerHealth;

	// Use this for initialization
	void Start () {
        currentAttack = attackLevels[1];
        currentHP = HPLevels[1];
        currentDefence = defenceLevels[1];

        thePlayerHealth = FindObjectOfType<PlayerHelathManager>();
		
	}

    // Update is called once per frame
    void Update() {
        if (currentExp >= toLevelUp[currentLevel])
        {
            LevelUp();
            
        }

		
	}

    public void AddExp(int expToAdd)
    {
        currentExp += expToAdd;
    }

    public void LevelUp()
    {
        currentLevel++;
        currentHP = HPLevels[currentLevel];

        thePlayerHealth.playerMaxHealth = currentHP;
        //add hp when lvlup
        thePlayerHealth.playerCurrentHealth += currentHP - HPLevels[currentLevel - 1];

        currentAttack = attackLevels[currentLevel];
        currentDefence = defenceLevels[currentLevel];
    }
}
    