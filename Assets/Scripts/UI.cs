using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{
    public Animation startAnimation;
    public Transform mainMenu;

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
        startAnimation.Play();
        yield return new WaitForSeconds(startAnimation.clip.length);
        mainMenu.gameObject.SetActive(false);
    }

    public void ReturnToMainMenu()
    {
        mainMenu.gameObject.SetActive(true);
    }
}