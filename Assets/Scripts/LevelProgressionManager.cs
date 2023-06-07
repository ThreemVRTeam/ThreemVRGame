using System;
using UnityEngine;

[Serializable, ] public struct Puzzle
{
    [HideInInspector] public string puzzleName;
    [HideInInspector] public int number;

    public GameObject objectsParent;
}

[ExecuteInEditMode] public class LevelProgressionManager : MonoBehaviour
{
    public Puzzle[] puzzles;
    private int currentPuzzle = 0;

    private void Awake()
    {
        for (int i = 0; i < puzzles.Length; i++)
        {
            if (Application.isPlaying)
                break;

            puzzles[i].number = i;

            if (i == 0)
                puzzles[i].puzzleName = "Tutorial";
            else if (i == puzzles.Length - 1)
                puzzles[i].puzzleName = "Final Puzzle";
            else
                puzzles[i].puzzleName = "Puzzle " + i.ToString();
        }
    }

    public void ProgressGame()
    {
        puzzles[currentPuzzle].objectsParent.SetActive(true);
        if (currentPuzzle == puzzles.Length)
            currentPuzzle++;
    }
}