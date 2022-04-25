using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseCanvas;

    //Global Bool to make things pause
    public static bool isPaused;
    FirstPerson firstPerson;
    // Start is called before the first frame update
    void Start()
    {
        firstPerson = GameObject.Find("Player").GetComponent<FirstPerson>();
        pauseCanvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            if(isPaused)
            {
                Resuming();
            }
            else
            {
                Pausing();
            }
            
        }
    }

    public void Pausing()
    {
        pauseCanvas.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        firstPerson.CanMove = false;
    }

    public void Resuming()
    {
        pauseCanvas.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        firstPerson.CanMove = true;
    }

    public void HandleMainMenu()
    {
        Time.timeScale = 1f;
        //Go to mainmenu
        SceneManager.LoadScene("MainMenu");
    }
    
    public void Quit() 
    {
        Application.Quit();
    }
    
}
