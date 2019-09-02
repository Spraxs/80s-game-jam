using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public static Action<InputType, float, int> INPUT_ACTION;

    // Update is called once per frame
    void Update()
    {
        if (INPUT_ACTION == null) return;

        if (Input.GetButtonUp("attack_up"))
        {
            INPUT_ACTION(InputType.ATTACK_UP, 1f, 0);
        } else

        if (Input.GetButtonUp("attack_mid"))
        {
            INPUT_ACTION(InputType.ATTACK_MID, 1f, 0);
        } else

        if (Input.GetButtonUp("attack_down"))
        {
            INPUT_ACTION(InputType.ATTACK_DOWN, 1f, 0);
        }
    }
}

public enum InputType
{
    ATTACK_UP, ATTACK_MID, ATTACK_DOWN, DEFENSE_UP, DEFENSE_MID, DEFENSE_DOWN
}
