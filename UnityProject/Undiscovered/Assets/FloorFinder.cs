using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorFinder : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log(collision.gameObject.tag);
        if (collision.gameObject.tag == "Floor" || collision.gameObject.tag == "Mirror")
        {
            Debug.Log("Stepped on floor");
            PlatformController.Player.LandOnGround();
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        //Debug.Log(collision.gameObject.tag);
        if (collision.gameObject.tag == "Floor" || collision.gameObject.tag == "Mirror")
        {
            Debug.Log("Stepped off floor");
            PlatformController.Player.NotGrounded();
        }
    }
}
