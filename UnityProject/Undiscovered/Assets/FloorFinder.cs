using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorFinder : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject.tag);
        if (collision.gameObject.tag == "Floor")
        {
            PlatformController.Player.LandOnGround();
        }
    }
}