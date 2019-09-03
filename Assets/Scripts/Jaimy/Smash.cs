using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Smash : MonoBehaviour
{
    private PlayerManager playerManager;
    private GameRules gameRules;
    private AnimationHandler animationHandler;

    public Player player; // Refrence to current player object

    private Defense defense;

    [SerializeField] private AudioClip blockClip;
    [SerializeField] private AudioClip upHitClip;
    [SerializeField] private AudioClip midHitClip;
    [SerializeField] private AudioClip downHitClip;

    [SerializeField] private AudioClip attackUpClip;
    [SerializeField] private AudioClip attackMidClip;
    [SerializeField] private AudioClip attackDownClip;

    private bool canAttackUp = true;
    private bool canAttackMid = true;
    private bool canAttackDown = true;

    private bool canAttack = true;

    // Start is called before the first frame update
    void Start()
    {
        animationHandler = GetComponent<AnimationHandler>();
        defense = GetComponent<Defense>();
        gameRules = GameRules.GetInstance();
        playerManager = PlayerManager.GetInstance();

        InputManager.INPUT_ACTION += ReceiveInput;
    }

    private void PlayBlockEffect(Player player)
    {
        SoundManager.Instance.Play(blockClip);

        player.GetGameObject().GetComponent<AnimationHandler>().PlayAnimation("isBlocking2");

    }

    public void DamageUp()
    {
        SoundManager.Instance.Play(attackUpClip);

        Player target = GetTarget();

        if (target == null) return;

        if (target.defenseType == DefenseType.UP)
        {
            PlayBlockEffect(target);
            return;
        }

        if (player.IsInRange(target, gameRules.attackRange) && player.IsFacingPlayer(target))
        {

            SoundManager.Instance.Play(upHitClip);

            target.Damage(gameRules.attackUpDamage, player);
        }
    }

    private void AttackUp()
    {
        if (!canAttackUp) return;

        StartCoroutine(Cooldown(DefenseType.UP, gameRules.attackMidDelay));

        animationHandler.PlayAnimation("isHeavy");
    }

    private void DamageMid()
    {
        SoundManager.Instance.Play(attackMidClip);

        Player target = GetTarget();
        if (target == null) return;

        if (target.defenseType == DefenseType.MID)
        {
            PlayBlockEffect(target);
            return;
        }

        if (player.IsInRange(target, gameRules.attackRange) && player.IsFacingPlayer(target))
        {

            SoundManager.Instance.Play(midHitClip);

            target.Damage(gameRules.attackMidDamage, player);
        }
    }

    private void AttackMid()
    {
        if (!canAttackMid) return;

        StartCoroutine(Cooldown(DefenseType.UP, gameRules.attackMidDelay));

        animationHandler.PlayAnimation("isPunching");
    }

    private void DamageDown()
    {
        SoundManager.Instance.Play(attackDownClip);

        Player target = GetTarget();
        if (target == null) return;

        if (target.defenseType == DefenseType.DOWN)
        {
            PlayBlockEffect(target);
            return;
        }

        if (player.IsInRange(target, gameRules.attackRange) && player.IsFacingPlayer(target))
        {
            SoundManager.Instance.Play(downHitClip);

            target.Damage(gameRules.attackDownDamage, player);
        }
    }

    private void AttackDown()
    {
        if (!canAttackDown) return;

        StartCoroutine(Cooldown(DefenseType.DOWN, gameRules.attackDownDelay));

        animationHandler.PlayAnimation("isKicking");
    }

    private Player GetTarget()
    {
        Player player = null;

        float distance = 99999;

        playerManager.GetPlayers().ForEach(p =>
        {
            if (p.GetId() != this.player.GetId())
            {
                float pDis = Vector3.Distance(p.GetGameObject().transform.position,
                    this.player.GetGameObject().transform.position);

                if (distance > pDis)
                {
                    distance = pDis;
                    player = p;
                }
            }
        });

        return player;
    }

    private IEnumerator Cooldown(DefenseType defenseType, float delay)
    {
        switch (defenseType)
        {
            case DefenseType.UP:
                canAttackUp = false;
                break;

            case DefenseType.MID:
                canAttackMid = false;
                break;

            case DefenseType.DOWN:
                canAttackDown = false;
                break;
        }

        yield return new WaitForSeconds(delay);

        switch (defenseType)
        {
            case DefenseType.UP:
                canAttackUp = true;
                break;

            case DefenseType.MID:
                canAttackMid = true;
                break;

            case DefenseType.DOWN:
                canAttackDown = true;
                break;
        }
    }

    private void ResetDefense()
    {
        defense.DefenseStop(gameRules.defenseDelay);
    }

    private IEnumerator GeneralCooldown()
    {
        canAttack = false;

        yield return new WaitForSeconds(gameRules.attackDelay);

        canAttack = true;
    }

    public void ReceiveInput(InputType inputType, float value, int controllerId)
    {
        if (playerManager.GetPlayerAmount() <= 1) return;
        if (!canAttack) return;

        if (inputType == InputType.ATTACK_UP && value > 0 && controllerId == player.GetId())
        {
            ResetDefense();
            AttackUp();
            StartCoroutine(GeneralCooldown());
        } else

        if (inputType == InputType.ATTACK_MID && value > 0 && controllerId == player.GetId())
        {
            ResetDefense();
            AttackMid();
            StartCoroutine(GeneralCooldown());
        } else

        if (inputType == InputType.ATTACK_DOWN && value > 0 && controllerId == player.GetId())
        {
            ResetDefense();
            AttackDown();
            StartCoroutine(GeneralCooldown());
        }
    }
}