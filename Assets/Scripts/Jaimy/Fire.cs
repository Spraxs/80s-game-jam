using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    [SerializeField]
    private GameObject parent;

    [SerializeField]
    private float speed;

    [SerializeField] private float movementRange;

    [SerializeField]
    private float range;

    [SerializeField]
    private float maxDistanceDelta;

    // Update is called once per frame
    void FixedUpdate()
    {

        Vector3 position = transform.position;

        bool first = true;

        while (Vector3.Distance(position, transform.position) > range || first)
        {
            first = false;
            position = transform.position;

            Vector3 newPos = transform.position;

            float x = Random.Range(movementRange * -1, movementRange);
            float y = Random.Range(movementRange * -1, movementRange);



            Vector3 movement = new Vector3(x, y, 0f);

            movement *= speed;

            position += movement;
        }



        if (Vector3.Distance(position, transform.position) < range)
        {



            transform.position = Vector3.MoveTowards(transform.position, position, maxDistanceDelta);
        }
    }
}
