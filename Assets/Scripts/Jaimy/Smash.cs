using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Smash : MonoBehaviour
{

    private PlayerManager playerManager;
    private GameRules gameRules;

    public Player player; // Refrence to current player object

    // Start is called before the first frame update
    void Start()
    {
        gameRules = GameRules.GetInstance();
        playerManager = PlayerManager.GetInstance();

        InputManager.INPUT_ACTION += ReceiveInput;
    }

    private void PlayBlockEffect(Player player)
    {

    }

    private void AttackUp()
    {
        

        Player target = GetTarget();
        if (target == null) return;

        if (target.defenseType == DefenseType.UP)
        {
            PlayBlockEffect(target);
            return;
        }

        target.Damage(gameRules.attackUpDamage, player);
    }

    private void AttackMid()
    {
        Player target = GetTarget();
        if (target == null) return;

        if (target.defenseType == DefenseType.MID)
        {
            PlayBlockEffect(target);
            return;
        }

        target.Damage(gameRules.attackMidDamage, player);
    }

    private void AttackDown()
    {
        Player target = GetTarget();
        if (target == null) return;

        if (target.defenseType == DefenseType.DOWN)
        {
            PlayBlockEffect(target);
            return;
        }

        target.Damage(gameRules.attackDownDamage, player);
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

    public void ReceiveInput(InputType inputType, float value, int controllerId)
    {
        if (inputType == InputType.ATTACK_UP && value > 0 && controllerId == player.GetId())
        {
            AttackUp();
        } else

        if (inputType == InputType.ATTACK_MID && value > 0 && controllerId == player.GetId())
        {
            AttackMid();
        } else

        if (inputType == InputType.ATTACK_DOWN && value > 0 && controllerId == player.GetId())
        {
            AttackDown();
        }
    }
}