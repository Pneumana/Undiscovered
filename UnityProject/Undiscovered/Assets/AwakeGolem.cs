using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AwakeGolem : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            GameObject.Find("Golem").GetComponent<GolemAdvance>().isActive = true;
            GameObject.Destroy(gameObject);
        }
    }
}
