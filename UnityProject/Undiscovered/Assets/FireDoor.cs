using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class FireDoor : MonoBehaviour
{
    public GameObject DoorUp;
    public GameObject DoorDown;
    public GameObject[] torches;
    public int litTorches;
    public bool opened;

    public float lowerTime;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void UpdateTorches()
    {
        litTorches = 0;
        foreach(GameObject torch in torches)
        {
            if (torch.GetComponent<Light2D>().enabled)
            {
                litTorches++;
            }
        }
    }
    void Open()
    {
        if (lowerTime <= 5)
        {
            DoorUp.transform.position += DoorUp.transform.up * Time.deltaTime;
            DoorDown.transform.position -= DoorUp.transform.up * Time.deltaTime;
            lowerTime += Time.deltaTime;
        }
    }
    // Update is called once per frame
    void Update()
    {
       if(litTorches == torches.Length)
        {
            Open();
        }
    }
}
