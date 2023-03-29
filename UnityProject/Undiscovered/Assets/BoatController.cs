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
        
        if (Input.GetKey(KeyCode.UpArrow))
        {
            if(speed < maxSpeed)
            {
                speed+= Time.deltaTime  * acceleration;
            }
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            if (speed > maxReverseSpeed)
            {
                speed -= Time.deltaTime * acceleration;
            }
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            body.rotation += Time.deltaTime * TurnSpeed;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            body.rotation -= Time.deltaTime * TurnSpeed;
        }
        if (!Input.GetKey(KeyCode.UpArrow))
        {
            if (speed > 0)
            {
                speed -= Time.deltaTime * decayspeed;
            }
        }
        if (!Input.GetKey(KeyCode.DownArrow))
        {
            if (speed < 0)
            {
                speed += Time.deltaTime * decayspeed;
            }
        }
        body.velocity = transform.up * speed;
    }
}
