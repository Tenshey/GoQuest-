using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthManager : MonoBehaviour
{

    public int enemyMaxHealth;
    public int enemyCurrentHealth;

    private PlayerStats thePlayerStats;

    public int expToGive;

    public string enemyQuestName;
    private QuestManager theQM;


    // Use this for initialization
    void Start()
    {
        enemyCurrentHealth = enemyMaxHealth;

        //wyszukaj stats gracza
        thePlayerStats = FindObjectOfType<PlayerStats>();
        theQM = FindObjectOfType<QuestManager>();
    }   

    // Update is called once per frame
    void Update()
    {
        if (enemyCurrentHealth <= 0)
        {
            theQM.enemyKilled = enemyQuestName;

            Destroy (gameObject);

            thePlayerStats.AddExp(expToGive);
        }
    }

    public void HurtEnemy(int damageToGive)
    {
        enemyCurrentHealth -= damageToGive;
    }

    public void SetMaxHealth()
    {
        enemyCurrentHealth = enemyMaxHealth;
    }
}
