using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BoatController : MonoBehaviour
{
    public float speed;
    public float maxSpeed;

    public float TurnSpeed;
    public float decayspeed;

    public float acceleration;

    public float maxReverseSpeed;
    private bool dead;
    Rigidbody2D body;
    public float boost;
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!dead)
        {
            body.velocity = Vector2.up;
            float x = 0;
            float y = 4;
            if (Input.GetKey(KeyCode.W))
            {
                y = 4.5f;
            }
            if (Input.GetKey(KeyCode.S))
            {
                y = 1.5f;
            }
            if (Input.GetKey(KeyCode.A))
            {
                x = -2f;
            }
            if (Input.GetKey(KeyCode.D))
            {
                x = 2f;
            }
            if (boost > 0)
            { y *= 1.2f; boost -= Time.deltaTime; }

            body.velocity = new Vector2(x, y) * speed;
        }
        else
        {
            body.velocity = new Vector2(0, 4f) * speed;
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            UpdateManager.instance.takenIdol = false;
            SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
        }
        //cheats
        if (Input.GetKeyDown(KeyCode.F1))
        {
            SceneManager.LoadScene("Victory", LoadSceneMode.Single);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "WinGame")
        {
            SceneManager.LoadScene("Victory", LoadSceneMode.Single);
        }
        if (collision.gameObject.tag == "Flammable")
        {
            boost = 1;
            Destroy(collision.gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Floor" && boost <= 0)
        {
            Debug.Log("hit an object");
            GetComponent<Animator>().SetTrigger("DIE");
            dead = true;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.name == "ScaleDownPlayer")
        {
            transform.localScale = new Vector3(transform.localScale.x - (Time.deltaTime * 1), transform.localScale.y - (Time.deltaTime * 1), 1);
        }
    }

    public void ResetScene()
    {
        //triggered by animation event
        Debug.Log("died");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name, LoadSceneMode.Single);
    }
}
