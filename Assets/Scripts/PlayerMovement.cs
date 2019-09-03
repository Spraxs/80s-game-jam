using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 2f;
    // Update is called once per frame
    void Update()
    {     //(Input.GetAxis("Horizontal") < 0)
        if (Input.GetAxis("Horizontal") < 0)
        {
            MoveLeft();
        }
        //(Input.GetAxis("Horizontal") > 0)
        if (Input.GetKey(KeyCode.RightArrow))
        {
            MoveRight();
        }
    }

    private void MoveLeft()
    {
        transform.Translate(-speed * Time.deltaTime, 0, 0);
    }
    private void MoveRight()
    {
        transform.Translate(speed * Time.deltaTime,0,0);
    }
}
