﻿using System;
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

        ResetAll();
    }

    /*
     * Case sensitive
     */
    public void PlayAnimation(string name)
    {

        ResetAll();

        animator.SetBool(name, true);
    }

    /*
     * Case sensitive
     */
    public void PlayAnimationIfNotPlaying(string stateName, string[] stateNames)
    {
        foreach (string sName in stateNames)
        {
            if (animator.GetBool(sName)) return;
        }

        animator.SetBool(stateName, true);
    }

    public void ResetAll()
    {
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
        animator.SetBool(stateName, false);
    }
}
