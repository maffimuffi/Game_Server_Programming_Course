using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveShooter : MonoBehaviour
{
    public float Speed;
    public GameObject[] checkpoints;
    int counter = 0;
    public float distance;
    private Vector3 direction;
    private float timer;


    // Start is called before the first frame update
    void Start()
    {

    }

    void FixedUpdate()
    {

        timer += Time.deltaTime;

        if(timer > 0 && timer < 5)
        {
            Speed = 6;
        }

        if (timer > 5 && timer < 10)
        {
            Speed = 7;
        }

        if (timer > 10 && timer < 15)
        {
            Speed = 8;
        }

        if (timer > 15 && timer < 20)
        {
            Speed = 9;
        }

        if (timer > 20 && timer < 25)
        {
            Speed = 10;
        }


        direction = Vector3.zero;

        direction = checkpoints[counter].transform.position - transform.position;

        if (direction.magnitude < distance)
        {
            if (counter < checkpoints.Length - 1)
            {
                counter++;
            }
            else
            {
                counter = 0;
            }
        }
        direction = direction.normalized;
        Vector3 dir = direction;

        GetComponent<Rigidbody>().velocity = new Vector2(direction.x * Speed, direction.y * Speed);
    }
}
