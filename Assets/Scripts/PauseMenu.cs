using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

    public bool pauseExists;
    public bool isPaused;
    public string MainMenu;
    public GameObject pauseMenuCanvas;


	// Use this for initialization
	void Start () {
        if (!pauseExists)
        {
            pauseExists = true;
            DontDestroyOnLoad(transform.root.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
	
	// Update is called once per frame
	void Update () {
      
        if (isPaused)

        {
            pauseMenuCanvas.SetActive(true);
            Time.timeScale = 0f;
        }
        else
        {
            pauseMenuCanvas.SetActive(false);
            Time.timeScale = 1f;
        }

        if(Input.GetKeyDown(KeyCode.P))
        {
            isPaused = !isPaused;
        }
		

	}

    public void Reasume()
    {
        isPaused = false;
    }

    public void Exit()
    {
        Application.Quit();
    }
}
