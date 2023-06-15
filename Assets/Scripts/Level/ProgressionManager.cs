using System;
using UnityEngine;

namespace Level
{
    [Serializable] public struct Puzzle
    {
        [HideInInspector] public string name;
        [HideInInspector] public int index;

        public GameObject objectsParent;
    }

    [ExecuteInEditMode]
    public class ProgressionManager : MonoBehaviour
    {
        [Tooltip("Place each of the elements for a puzzle inside an empty parent and reference the parent here.")]
        public Puzzle[] puzzles;
        private int currentPuzzle = 0;

        private void Awake()
        {
            UpdatePuzzleElementDetails();
        }

        public void ProgressGame()
        {
            puzzles[currentPuzzle].objectsParent.SetActive(true);
            if (currentPuzzle == puzzles.Length)
                currentPuzzle++;
        }

        public void UpdatePuzzleElementDetails()
        {
            for (int i = 0; i < puzzles.Length; i++)
            {
                if (Application.isPlaying)
                    break;

                puzzles[i].index = i;

                if (i == 0)
                    puzzles[i].name = "Tutorial";
                else if (i == puzzles.Length - 1)
                    puzzles[i].name = "Final Puzzle";
                else
                    puzzles[i].name = "Puzzle " + i.ToString();
            }
        }

    }
}

namespace Level.CustomInspector
{
#if UNITY_EDITOR
    using UnityEditor;

    [CustomEditor(typeof(ProgressionManager)), Serializable]
    public class ProgressionManagerEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            ProgressionManager script = (ProgressionManager)target;

            EditorGUILayout.BeginHorizontal();
                EditorGUILayout.Space();
                if (GUILayout.Button("Refresh Names", EditorStyles.miniButton, GUILayout.MaxWidth(120))) script.UpdatePuzzleElementDetails();
                EditorGUILayout.Space();
            EditorGUILayout.EndHorizontal();

            EditorGUILayout.Space();
        }
    }
#endif
}