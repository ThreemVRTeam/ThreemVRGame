using System.Collections.Generic;
using UnityEngine;

public class InteractionEventReciever : MonoBehaviour
{
    private enum ActivationTypes
    {
        Select,
        ProgressGame,
        PlayAnimation
    }

    [SerializeField] private List<ActivationTypes> activationEffects;

    private LevelProgressionManager progressionManager;

    private Animator animator;
    [SerializeField] private string animationTrigger;

    public void Awake()
    {
        InitialiseComponents();
    }

    public void InitialiseComponents()
    {
        for (int i = 0; i < activationEffects.Count; i++)
        {
            switch (activationEffects[i])
            {
                case ActivationTypes.ProgressGame:
                    progressionManager = GameObject.Find("GameManager").GetComponent<LevelProgressionManager>();
                    break;
                case ActivationTypes.PlayAnimation:
                    animator = GetComponent<Animator>();
                    break;
                default:
                    Debug.LogWarning(gameObject.name + " has an activation effect not set in the inspector.");
                    break;
            }
        }
    }

    public void Activate()
    {
        for (int i = 0; i < activationEffects.Count; i++)
        {
            switch (activationEffects[i])
            {
                case ActivationTypes.ProgressGame:
                    progressionManager.ProgressGame();
                    break;
                case ActivationTypes.PlayAnimation:
                    animator.SetTrigger(animationTrigger);
                    break;
                default:
                    Debug.LogWarning(gameObject.name + " has an activation effect not set in the inspector.");
                    break;
            }
        }
    }
}