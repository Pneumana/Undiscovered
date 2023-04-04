using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatController : MonoBehaviour
{
    public float speed;
    public float maxSpeed;

    public float TurnSpeed;
    public float decayspeed;

    public float acceleration;

    public float maxReverseSpeed;

    Rigidbody2D body;
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        body.velocity = Vector2.up;
        float x = 0;
        float y = 4;
        if (Input.GetKey(KeyCode.UpArrow))
        {
            y = 6.5f;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            y = 1.5f;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            x= -2f;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            x = 2f;
        }
        
        body.velocity = new Vector2(x,y) * speed;
    }
}
