using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuOptions : MonoBehaviour
{

    public Animator credits;

    public bool creditsPlaying;

    private void Start()
    {
        creditsPlaying = false;
    }
    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) &&  creditsPlaying == true)
        {
            credits.SetBool("PlayCredits", false);
            credits.SetBool("CreditsIdle", true);
        }
    }
    public void PlayGame()
    {
        credits.SetBool("PlayGame", true);
        StartCoroutine("PlayTheGame");    
    }

    public void QuitGame()
    {
        Application.Quit();
    }


    public void Credits()
    {
        credits.SetBool("PlayCredits", true);
        credits.SetBool("CreditsIdle", false);
        creditsPlaying = true;
    }

    public IEnumerator PlayTheGame()
    {
        yield return new WaitForSeconds(1.1f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }
}
