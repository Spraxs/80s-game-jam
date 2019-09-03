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

        float horizontal = Input.GetAxis("horizontal");
        if (horizontal != prevHorizontal)
        {
            prevHorizontal = horizontal;
            INPUT_ACTION(InputType.HORIZONTAL, horizontal, 0);
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

        /*
         * Controller 1
         */

        float horizontal1 = Input.GetAxis("horizontal_1");
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
    }
}

public enum InputType
{
    ATTACK_UP, ATTACK_MID, ATTACK_DOWN, DEFENSE_UP, DEFENSE_MID, DEFENSE_DOWN, HORIZONTAL
}
