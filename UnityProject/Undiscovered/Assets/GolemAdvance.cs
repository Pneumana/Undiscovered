using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolemAdvance : MonoBehaviour
{
    public float speed;
    public bool isActive;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isActive)
            transform.position += (Vector3.left * speed) * Time.deltaTime;
    }
}
