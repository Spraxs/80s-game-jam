using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defense : MonoBehaviour
{
    private PlayerManager playerManager;
    private AnimationHandler animationHandler;

    public Player player; // Refrence to current player object

    private bool canDefense = true;

    // Start is called before the first frame update
    void Start()
    {
        animationHandler = GetComponent<AnimationHandler>();
        playerManager = PlayerManager.GetInstance();

        InputManager.INPUT_ACTION += ReceiveInput;
    }

    private void DefenseUp()
    {
        animationHandler.PlayAnimation("isBlocking");

        if (player.defenseType == DefenseType.UP) return;

        player.defenseType = DefenseType.UP;

        Debug.Log("Defense: " + player.defenseType);
    }

    private void DefenseMid()
    {
        animationHandler.PlayAnimation("isBlocking");

        if (player.defenseType == DefenseType.MID) return;
        player.defenseType = DefenseType.MID;

        Debug.Log("Defense: " + player.defenseType);
    }

    private void DefenseDown()
    {
        animationHandler.PlayAnimation("isBlocking");

        if (player.defenseType == DefenseType.DOWN) return;
        player.defenseType = DefenseType.DOWN;

        Debug.Log("Defense: " + player.defenseType);
    }

    public void DefenseStop(float delay)
    {
        animationHandler.ResetAnimation("isBlocking");

        if (!canDefense) return;

        if (player.defenseType == DefenseType.NONE) return;
        player.defenseType = DefenseType.NONE;

        Debug.Log("Defense: " + player.defenseType);

        StartCoroutine(Cooldown(delay));
    }

    private IEnumerator Cooldown(float delay)
    {
        canDefense = false;

        yield return new WaitForSeconds(delay);

        canDefense = true;
    }

    public void ReceiveInput(InputType inputType, float value, int controllerId)
    {
        if (playerManager.GetPlayerAmount() <= 1) return;
        if (controllerId != player.GetId()) return;
        if (!canDefense) return;

        if (inputType == InputType.ATTACK_UP || inputType == InputType.ATTACK_MID || inputType == InputType.ATTACK_DOWN && value > 0) return;

        if (inputType == InputType.DEFENSE_UP && value > 0)
        {
            DefenseUp();
        }
        else

        if (inputType == InputType.DEFENSE_MID && value > 0)
        {
            DefenseMid();
        }
        else

        if (inputType == InputType.DEFENSE_DOWN && value > 0)
        {
            DefenseDown();
        } else if (inputType == InputType.DEFENSE_UP && value == 0)
        {
            DefenseStop(0f);
        }
    }
}
