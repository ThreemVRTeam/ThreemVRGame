using System;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

[Serializable] public struct Puzzle
{
    [HideInInspector] public string identifier;
    [HideInInspector] public int number;

    public GameObject objectsParent;
}

[ExecuteInEditMode] public class LevelProgressionManager : MonoBehaviour
{
    [Tooltip("Place each of the elements for a puzzle inside an empty parent and reference the parent here.")]
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

    /// <summary>
    /// Updates all the puzzle elements identifiers and numbers to appropriate ones, based on their order in the list.
    /// </summary>
    public void NamePuzzleElements()
    {
        for (int i = 0; i < puzzles.Length; i++)
        {
            if (Application.isPlaying)
                break;

            puzzles[i].number = i;

            if (i == 0)
                puzzles[i].identifier = "Tutorial";
            else if (i == puzzles.Length - 1)
                puzzles[i].identifier = "Final Puzzle";
            else
                puzzles[i].identifier = "Puzzle " + i.ToString();
        }
    }

}

#if UNITY_EDITOR
[CustomEditor(typeof(LevelProgressionManager)), Serializable]
public class LevelProgressionManagerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        LevelProgressionManager script = (LevelProgressionManager)target;

        EditorGUILayout.BeginHorizontal();
            EditorGUILayout.Space();
            if (GUILayout.Button("Refresh Names", EditorStyles.miniButton, GUILayout.MaxWidth(100))) script.NamePuzzleElements();
            EditorGUILayout.Space();
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.Space();
    }
}
#endif