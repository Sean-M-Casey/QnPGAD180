using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenuScript : MonoBehaviour
{
    //First Varible is for the player controls script
    //Second Varible is for Pausemenu Sprite
    public PlayerControls controlScript;
    public Image pauseMenu;
    bool toggle = false;
    public GameObject textBox;


    // Start is called before the first frame update
    void Start()
    {
        pauseMenu.gameObject.SetActive(false);
    }

    // Escape if the default key for activating the pause menu 
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !textBox.activeSelf)
        {
            toggle = !toggle;
        }
        //this If statement is setting the PauseMenu active, activating the mouse & disabling the player movement  
        if (toggle == false)
        {
            Time.timeScale = 1;
            pauseMenu.gameObject.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
            controlScript.enabled = true;
        }
        else if (toggle == true)
        {
            Time.timeScale = 0;
            pauseMenu.gameObject.SetActive(true);
            Cursor.lockState = CursorLockMode.Confined;
            controlScript.enabled = false;
        }
    }

    public void ResumeButton()
    {
        toggle = !toggle;
    }
    //this is for setting which scene is going to be loaded
    public void QuitButton()
    {
        SceneManager.LoadScene("Intro_Splash_Screen");
    }
}
