using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 2f;

    public Player player;

    private float horizontal;
    private SpriteRenderer spriteRenderer;
    private AnimationHandler animationHandler;

    void Start()
    {
        animationHandler = GetComponent<AnimationHandler>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        InputManager.INPUT_ACTION += ReceiveInput;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (horizontal != 0)
        {
            animationHandler.PlayAnimation("isWalking");
        }
        else
        {
            animationHandler.ResetAnimation("isWalking");
        }

        if (horizontal < 0)
        {
            spriteRenderer.flipX = false;
            //transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
            transform.Translate(-speed * Time.deltaTime, 0, 0);
        } else
        if (horizontal > 0)
        {
            spriteRenderer.flipX = true;
            //transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
            transform.Translate(speed * Time.deltaTime, 0, 0);
        }
    }

    private void MoveLeft()
    {
        
    }
    private void MoveRight()
    {

    }

    public void ReceiveInput(InputType inputType, float value, int controllerId)
    {
        if (inputType == InputType.HORIZONTAL && controllerId == player.GetId())
        {
            if (horizontal != value) horizontal = value;
        }
    }
}
