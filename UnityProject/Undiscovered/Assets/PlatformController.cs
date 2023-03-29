using System.Collections;
using System.Collections.Generic;
using UnityEditor.Il2Cpp;
using UnityEngine;

public class PlatformController : MonoBehaviour
{
    public Rigidbody2D body;
    public GameObject floorDetector;

    public static PlatformController Player;

    public float movementSpeed;
    public float jumpPower;

    float y = 0;
    float x = 0;

    public bool isGrounded;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        Player = GetComponent<PlatformController>();
    }

    // Update is called once per frame
    void Update()
    {
        x = 0;
        y = body.velocity.y;
        if (Input.GetKey(KeyCode.A))
        {
            x = -1;
        }
        if (Input.GetKey(KeyCode.D))
        {
            x = 1;
        }
        if (Input.GetKey(KeyCode.Space) && isGrounded)
        {
            Debug.Log("Jumps");
            body.velocity = new Vector3(body.velocity.x, jumpPower);
            isGrounded = false;
        }
        
        if (!Input.GetKey(KeyCode.Space) && !isGrounded)
        {
            body.velocity = new Vector3(body.velocity.x, Mathf.Min(body.velocity.y,0));
        }
        body.velocity = new Vector3(x * movementSpeed, body.velocity.y);
    }
    
    public void LandOnGround()
    {
        Debug.Log("Landed");
        isGrounded = true;
        body.gravityScale = 2;
    }
}
