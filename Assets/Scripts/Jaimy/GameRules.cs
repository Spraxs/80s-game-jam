﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameRules : MonoBehaviour
{

    [SerializeField]
    public float attackUpDamage;

    [SerializeField]
    public float attackMidDamage;

    [SerializeField]
    public float attackDownDamage;

    [SerializeField] public float attackRange;

    [SerializeField] public float knockBackX;

    [SerializeField] public float knockBackY;

    private static GameRules instance;

    void Awake()
    {
        instance = this;
    }

    public static GameRules GetInstance()
    {
        return instance;
    }
}