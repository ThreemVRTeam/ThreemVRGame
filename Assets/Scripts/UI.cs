using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{
    public Animation startAnimation;
    public Transform mainMenu;
    public Transform player;
    //player must be transferred to out of bounds space to avoid clipping
    public Vector3 menuLocation = new Vector3(8,0,0);
    public Vector3 playerLocation = Vector3.zero;

    public void ExitGame()
    {
        Application.Quit();
    }
    public void StartGame()
    {
        StartCoroutine(StartRoutine());
    }
    public void ResetGame()
    {
        SceneManager.LoadScene(0);
    }

    public IEnumerator StartRoutine()
    {
        player.position = playerLocation;
        if(startAnimation != null)
        {
            startAnimation.Play();
            yield return new WaitForSeconds(startAnimation.clip.length);
        }
        mainMenu.gameObject.SetActive(false);
        yield return null;
    }

    public void ReturnToMainMenu()
    {
        mainMenu.gameObject.SetActive(true);
        player.position = menuLocation;
    }
}