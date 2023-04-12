using Mono.Cecil;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuCamera : MonoBehaviour
{
    public Vector3 target;
    public float bob;
    public float sinTime;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (sinTime <= 360)
        {
            sinTime += 0.75f*Time.deltaTime;
        }
        if (sinTime > 360)
        {
            sinTime = 0;
        }
        var newPos = Vector2.Lerp(transform.position, target, Time.deltaTime);
        transform.position = new Vector3(newPos.x, newPos.y + ((Mathf.Sin(sinTime) / 180f) * 0.1f), -10);
    }
    public void GoToCredits()
    {
        target = new Vector3(-15.5f, 0);
    }
    public void ReturnToMenu()
    {
        target = new Vector3(0,0);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void StartGame()
    {
        SceneManager.LoadScene("Intro", LoadSceneMode.Single);
    }
}
