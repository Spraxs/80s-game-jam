using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FakeTestMovement : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            transform.position += Vector3.right * 5f * Time.deltaTime;
        }
    }
}
