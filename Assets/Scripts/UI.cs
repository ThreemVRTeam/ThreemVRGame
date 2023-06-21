using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI : MonoBehaviour
{
    Animation startAnimation;
    Transform mainMenu;

    public void ExitGame()
    {
        Application.Quit();
    }
    public void StartGame()
    {
        startAnimation.Play();
    }

    public IEnumerator StartRoutine()
    {
        StartGame();
        yield return new WaitForSeconds(startAnimation.clip.length);
        mainMenu.gameObject.SetActive(false);
    }

    public void ReturnToMainMenu()
    {
        //SetActiveTrue
    }
}