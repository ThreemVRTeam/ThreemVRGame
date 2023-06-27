using System;
using System.Collections;
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
        public Animator levelTransitionAnimator = null;
        [Tooltip("Place each of the elements for a puzzle inside an empty parent and reference the parent here.")]
        public Puzzle[] puzzles;
        private int currentPuzzle = 0;

        private void Awake()
        {
            UpdatePuzzleElementDetails();
        }
        private void Start()
        {
            ProgressLogic(); 
        }

        public void ProgressLogic()
        {
            if (currentPuzzle == puzzles.Length)
            {
                EndGame();
            }
            else
            {
                if (puzzles[currentPuzzle].objectsParent != null)
                    puzzles[currentPuzzle].objectsParent.SetActive(true); Debug.Log("Set active");
                currentPuzzle++;
            }
        }

        public IEnumerator ProgressCoroutine()
        {
            
            if (levelTransitionAnimator != null)
                levelTransitionAnimator.Play("LevelTransition");
            Debug.Log("Progress Started");
            yield return new WaitForSeconds(1);
            ProgressLogic();

            yield return new WaitForSeconds(3);
            Debug.Log("Progress Finished");
            if (levelTransitionAnimator != null)
                levelTransitionAnimator.Play("EmptyState");
        }

        public void ProgressGame() => StartCoroutine(ProgressCoroutine());

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

        public void EndGame()
        {
            //Play end animation
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
            ProgressionManager script = (ProgressionManager)target;

            EditorGUILayout.Space();

            EditorGUILayout.BeginHorizontal();
                EditorGUILayout.Space();
                if (GUILayout.Button("Progress", EditorStyles.miniButton, GUILayout.MaxWidth(120))) script.StartCoroutine(script.ProgressCoroutine());
                EditorGUILayout.Space();
            EditorGUILayout.EndHorizontal();

            EditorGUILayout.Space(10);

            base.OnInspectorGUI();

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