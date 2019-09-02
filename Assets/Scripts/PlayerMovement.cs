using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 1.5f;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Horizontal") < 0)
        {
            MoveLeft();
        }
        if (Input.GetAxis("Horizontal") > 0)
        {
            MoveRight();
        }
    }

    private void MoveLeft()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;
    }
    private void MoveRight()
    {
        transform.position += Vector3.right * speed * Time.deltaTime;
    }
}
