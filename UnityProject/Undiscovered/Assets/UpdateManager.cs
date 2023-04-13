using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;

public class UpdateManager : MonoBehaviour
{
    public static UpdateManager instance;
    public bool takenIdol = false;
    // Start is called before the first frame update
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
        else if (this != instance)
            Destroy(this);
    }
    private void OnEnable()
    {
            SceneManager.sceneLoaded += OnSceneLoaded;
    }
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Debug.Log("OnSceneLoaded: " + scene.name);
        
        Debug.Log(mode);
    }
    void OnDisable()
    {
        Debug.Log("OnDisable");
        SceneManager.sceneLoaded -= OnSceneLoaded;
        if(takenIdol)
            restartChase();
    }
    public void restartChase()
    {
        //set player pos, activate golem, light all lights
        GameObject[] torches = GameObject.FindGameObjectsWithTag("Flammable");
        foreach (GameObject t in torches)
        {
            if(t.GetComponent<Light2D>() != null)
            {
                t.GetComponent<Light2D>().enabled = true;
            }
        }
        GameObject.Find("LaserEndpoint").GetComponent<Light2D>().enabled = true;
        GameObject.Find("LaserEndpoint1").GetComponent<Light2D>().enabled = true;
        GameObject.Find("LaserDoor").GetComponent<FireDoor>().UpdateTorches();
        GameObject.Find("LaserDoor1").GetComponent<FireDoor>().UpdateTorches();
        GameObject.Find("FireDoor").GetComponent<FireDoor>().UpdateTorches();
        GameObject.Find("Golem").GetComponent<GolemAdvance>().isActive = true;
        GameObject.Find("Player").transform.position = GameObject.Find("Idol").transform.position;
        GameObject.Find("Grapple").transform.position = GameObject.Find("Player").transform.position;
        GameObject.Destroy(GameObject.Find("PreventEscape"));

        /*        GameObject.Find("LaserDoor").GetComponent<FireDoor>().lowerTime = 5;
                GameObject.Find("LaserDoor1").GetComponent<FireDoor>().lowerTime = 5;
                GameObject.Find("FireDoor").GetComponent<FireDoor>().lowerTime = 5;*/
    }
}
