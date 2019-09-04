using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public static Action<InputType, float, int> INPUT_ACTION;

    private float prevHorizontal;
    private float prevHorizontal1;

    // Update is called once per frame
    void Update()
    {
        if (INPUT_ACTION == null) return;

        /*
         * Controller 0 
         */

        float horizontal = Input.GetAxis("Horizontal");


        if (horizontal > .1f || horizontal < .1f)
        {
            prevHorizontal = horizontal;
            INPUT_ACTION(InputType.HORIZONTAL, horizontal, 0);
        }
        else
        {
            prevHorizontal = 0f;
            INPUT_ACTION(InputType.HORIZONTAL, 0f, 0);
        }

        if (Input.GetButtonUp("attack_up"))
        {
            INPUT_ACTION(InputType.ATTACK_UP, 1f, 0);
        }
        else

        if (Input.GetButtonUp("attack_mid"))
        {
            INPUT_ACTION(InputType.ATTACK_MID, 1f, 0);
        }
        else

        if (Input.GetButtonUp("attack_down"))
        {
            INPUT_ACTION(InputType.ATTACK_DOWN, 1f, 0);
        }

        else if (Input.GetButton("defense_up"))
        {
            INPUT_ACTION(InputType.DEFENSE_UP, 1f, 0);
        } else if (Input.GetButton("defense_mid"))
        {
            INPUT_ACTION(InputType.DEFENSE_MID, 1f, 0);
        }
        else if (Input.GetButton("defense_down"))
        {
            INPUT_ACTION(InputType.DEFENSE_DOWN, 1f, 0);
        } else
        {
            INPUT_ACTION(InputType.DEFENSE_UP, 0f, 0); // No defense
        }

        /*
         * Controller 1
         */

        float horizontal1 = Input.GetAxis("Horizontal_1");
        if (horizontal1 != prevHorizontal1)
        {
            prevHorizontal1 = horizontal1;
            INPUT_ACTION(InputType.HORIZONTAL, horizontal1, 1);
        }

        if (Input.GetButtonUp("attack_up_1"))
        {
            INPUT_ACTION(InputType.ATTACK_UP, 1f, 1);
        }
        else

        if (Input.GetButtonUp("attack_mid_1"))
        {
            INPUT_ACTION(InputType.ATTACK_MID, 1f, 1);
        }
        else

        if (Input.GetButtonUp("attack_down_1"))
        {
            INPUT_ACTION(InputType.ATTACK_DOWN, 1f, 1);
        }
        else if (Input.GetButton("defense_up_1"))
        {
            INPUT_ACTION(InputType.DEFENSE_UP, 1f, 1);
        }
        else if (Input.GetButton("defense_mid_1"))
        {
            INPUT_ACTION(InputType.DEFENSE_MID, 1f, 1);
        }
        else if (Input.GetButton("defense_down_1"))
        {
            INPUT_ACTION(InputType.DEFENSE_DOWN, 1f, 1);
        }
        else
        {
            INPUT_ACTION(InputType.DEFENSE_UP, 0f, 1); // No defense
        }
    }
}

public enum InputType
{
    ATTACK_UP, ATTACK_MID, ATTACK_DOWN,
    DEFENSE_UP, DEFENSE_MID, DEFENSE_DOWN,
    HORIZONTAL
}
