using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class TorchLantern : MonoBehaviour
{
    public bool stick2Player;
    public GameObject player;

    private void Update()
    {
        if (stick2Player)
        {
            transform.position = player.transform.position;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Flammable")
        {
            Debug.Log("light torch");
            collision.gameObject.GetComponent<Light2D>().enabled = true;
        }
        if(collision.gameObject.tag == "PutOutFire")
        {
            Destroy(gameObject);
        }
        if (collision.gameObject.name == "Player")
        {
            stick2Player = true;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.gameObject.name);
        
    }
}
