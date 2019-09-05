using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defense : MonoBehaviour
{
    private PlayerManager playerManager;
    private AnimationHandler animationHandler;

    [SerializeField] private AudioClip blockUpClip;
    [SerializeField] private AudioClip blockDownClip;

    [SerializeField] private float noiceDelay;

    private bool canMakeNoice = true;

    public Player player; // Refrence to current player object

    private bool canDefense = true;

    private string[] stateNames = { "isBlocking2" };

    // Start is called before the first frame update
    void Start()
    {
        animationHandler = GetComponent<AnimationHandler>();
        playerManager = PlayerManager.GetInstance();

        InputManager.INPUT_ACTION += ReceiveInput;
    }

    private void DefenseUp()
    {
        animationHandler.PlayAnimationIfNotPlaying("isBlocking", stateNames);

        if (player.defenseType == DefenseType.UP) return;

        PlayBlockSoundUp();

        player.defenseType = DefenseType.UP;

        Debug.Log("Defense: " + player.defenseType);
    }

    private void DefenseMid()
    {
        animationHandler.PlayAnimationIfNotPlaying("isBlocking", stateNames);

        if (player.defenseType == DefenseType.MID) return;

        PlayBlockSoundUp();

        player.defenseType = DefenseType.MID;

        Debug.Log("Defense: " + player.defenseType);
    }

    private void DefenseDown()
    {
        animationHandler.PlayAnimationIfNotPlaying("isBlocking", stateNames);

        if (player.defenseType == DefenseType.DOWN) return;

        PlayBlockSoundUp();

        player.defenseType = DefenseType.DOWN;

        Debug.Log("Defense: " + player.defenseType);
    }

    public void DefenseStop(float delay)
    {

        animationHandler.ResetAnimation("isBlocking");

        if (!canDefense) return;

        if (player.defenseType == DefenseType.NONE) return;

        PlayBlockSoundDown();

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

    private void PlayBlockSoundUp()
    {
        if (canMakeNoice)
        {
            StartCoroutine(NoiceCooldown());
            SoundManager.Instance.Play(blockUpClip);
        }
    }

    private void PlayBlockSoundDown()
    {
        if (canMakeNoice)
        {
            StartCoroutine(NoiceCooldown());
            SoundManager.Instance.Play(blockDownClip);
        }
    }

    private IEnumerator NoiceCooldown()
    {
        canMakeNoice = false;

        yield return new WaitForSeconds(noiceDelay);

        canMakeNoice = true;
    }

    public void ReceiveInput(InputType inputType, float value, int controllerId)
    {

        if (playerManager.GetPlayerAmount() <= 1) return;
        if (!canDefense) return;

        if (inputType == InputType.ATTACK_UP || inputType == InputType.ATTACK_MID || inputType == InputType.ATTACK_DOWN && value > 0) return;

        if (inputType == InputType.DEFENSE_UP && value > 0 && controllerId == player.GetId())
        {
            DefenseUp();
        }
        else

        if (inputType == InputType.DEFENSE_MID && value > 0 && controllerId == player.GetId())
        {
            DefenseMid();
        }
        else

        if (inputType == InputType.DEFENSE_DOWN && value > 0 && controllerId == player.GetId())
        {
            DefenseDown();
        } else if (inputType == InputType.DEFENSE_UP && value == 0 && controllerId == player.GetId())
        {
            DefenseStop(0f);
        }
    }
}
