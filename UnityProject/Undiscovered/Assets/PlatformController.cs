using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEditor.Il2Cpp;
using UnityEngine;
using UnityEngine.Rendering;

public class PlatformController : MonoBehaviour
{
    public Rigidbody2D body;
    public GameObject floorDetector;
    public GameObject Grappler;

    public static PlatformController Player;

    public float movementSpeed;
    public float jumpPower;
    public float grappleRange;

    Vector3 previousPosition;
    GameObject lastGrapplePoint;
    public float lastGrappleCD;

    float y = 0;
    float x = 0;

    public bool isGrounded;
    public bool isGrappling;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        Player = GetComponent<PlatformController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!isGrappling)
            NormalControls();
        if (isGrappling)
            Grapple();
        body.velocity = new Vector3(x * movementSpeed, body.velocity.y);
        if(lastGrappleCD > 0)
            lastGrappleCD -=Time.deltaTime;
        previousPosition = transform.position;
    }
    void NormalControls()
    {
        if (isGrounded)
        {
            x = 0;
        }
        if (!isGrounded)
        {
            x = body.velocity.x;
        }
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
            body.velocity = new Vector3(body.velocity.x, Mathf.Min(body.velocity.y, 0));
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            FindGrapplePoints();
            GrappleStartBehavior();
        }
    }
    void FindGrapplePoints()
    {
        GameObject[] grapplePoints = GameObject.FindGameObjectsWithTag("GrapplePoint");
        Transform closest = null;
        var current = Mathf.Infinity;
        Grappler.transform.position = new Vector3(0, 0, 0);
        foreach(GameObject point in grapplePoints)
        {
            var distance = Vector3.Distance(transform.position, point.transform.position);
            if (distance<= grappleRange && distance<current)
            {
                if(point != lastGrapplePoint || point == lastGrapplePoint && lastGrappleCD <= 0)
                {
                    closest = point.transform;
                    current = distance;
                    
                }
            }
        }
        
        if (closest != null)
        {
            Grappler.transform.position = closest.transform.position;
            lastGrapplePoint = closest.gameObject;
            lastGrappleCD = 0.5f;
        }
    }
    void GrappleStartBehavior()
    {
        var max = Mathf.Min(Mathf.Atan2(transform.position.y - Grappler.transform.position.y, transform.position.x - Grappler.transform.position.x) * Mathf.Rad2Deg, Mathf.Atan2(Grappler.transform.position.y - transform.position.y, Grappler.transform.position.x - transform.position.x) * Mathf.Rad2Deg);
        body.rotation = (max) + Mathf.PI;
        GetComponent<BoxCollider2D>().isTrigger = true;
        body.gravityScale = 0;
        isGrappling = true;
    }
    void Grapple()
    {
        var newPos = Vector3.MoveTowards(transform.position, Grappler.transform.position, Time.deltaTime * 20);
        transform.position = newPos;
        if (transform.position == Grappler.transform.position)
        {
            //this should fling the player
            body.velocity = new Vector3(1, body.velocity.y);
            isGrappling = false;
            body.rotation = 0;
            GetComponent<BoxCollider2D>().isTrigger = false;
            body.gravityScale = 2;
        }
            
    }
    public void LandOnGround()
    {
        if (!isGrappling) { 
        Debug.Log("Landed");
        isGrounded = true;
        body.gravityScale = 2;
            }
    }
}