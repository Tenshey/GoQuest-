using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public GameObject GameOverScreen;

    public bool isDead;


    // Use this for initialization
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        if (isDead)

        {
            GameOverScreen.SetActive(true);
            Time.timeScale = 0f;
        }
        else
        {
            GameOverScreen.SetActive(false);
            Time.timeScale = 1f;
        }
    }

        public void Exit()
        {
            Application.Quit();
        }

        public void Restart()
        {
            System.Diagnostics.Process.Start(Application.dataPath.Replace("_Data", ".exe"));
            Application.Quit();
        }

    } 
