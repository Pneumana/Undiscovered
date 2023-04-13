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
            var fireFX = Instantiate(GameObject.Find("FireParticles"));
            fireFX.transform.position = collision.gameObject.transform.position;
            GameObject.Find("FireDoor").GetComponent<FireDoor>().UpdateTorches();
        }
        if(collision.gameObject.tag == "PutOutFire")
        {
            gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.right * 2;
            var flamemission = transform.Find("Light 2D").gameObject.transform.Find("Flames").gameObject.GetComponent<ParticleSystem>().emission;
            flamemission.rateOverTimeMultiplier = 0;
            flamemission.rateOverDistanceMultiplier = 0;
            var sparks = transform.Find("Light 2D").gameObject.transform.Find("Sparks").transform.gameObject.GetComponent<ParticleSystem>().emission;
            sparks.rateOverTimeMultiplier = 0;
            stick2Player = false;
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
