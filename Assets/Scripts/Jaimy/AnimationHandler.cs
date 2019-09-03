using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationHandler : MonoBehaviour
{
    private Animator animator;

    [SerializeField] private List<string> stateNames;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();

        ResetAllAnimations();
    }

    /*
     * Case sensitive
     */
    public void PlayAnimation(string name)
    {
        if (animator == null) return;
        ResetAllAnimations();

        animator.SetBool(name, true);
    }

    /*
     * Case sensitive
     */
    public void PlayAnimationIfNotPlaying(string stateName, string[] stateNames)
    {
        if (animator == null) return;
        foreach (string sName in stateNames)
        {
            if (animator.GetBool(sName)) return;
        }

        animator.SetBool(stateName, true);
    }

    public void ResetAllAnimations()
    {
        if (animator == null) return;
        foreach (string sName in stateNames)
        {
            animator.SetBool(sName, false);
        }
    }

    /*
     * Case sensitive
     */
    public void ResetAnimation(string stateName)
    {
        if (animator == null) return;
        animator.SetBool(stateName, false);
    }
}
