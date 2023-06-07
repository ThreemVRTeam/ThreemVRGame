using System;
using UnityEngine;

[Serializable, ] public struct Puzzle
{
    [HideInInspector] public string identifier;
    [HideInInspector] public int number;

    public GameObject objectsParent;
}

[ExecuteInEditMode] public class LevelProgressionManager : MonoBehaviour
{
    public Puzzle[] puzzles;
    private int currentPuzzle = 0;

    private void Awake()
    {
        NamePuzzleElements();
    }

    public void ProgressGame()
    {
        puzzles[currentPuzzle].objectsParent.SetActive(true);
        if (currentPuzzle == puzzles.Length)
            currentPuzzle++;
    }

    [ContextMenu("Refresh Puzzle Names")] private void NamePuzzleElements()
    {
        for (int i = 0; i < puzzles.Length; i++)
        {
            if (Application.isPlaying)
                break;

            Puzzle puzzle = puzzles[i];
            puzzle.number = i;

            if (i == 0)
                puzzle.identifier = "Tutorial";
            else if (i == puzzles.Length - 1)
                puzzle.identifier = "Final Puzzle";
            else
                puzzle.identifier = "Puzzle " + i.ToString();
        }
    }

}