using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseCamera : MonoBehaviour
{
    public GameObject target;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        var newy = transform.position.y + (3.9f * Time.deltaTime);
        
        var destination = new Vector3(target.transform.position.x, transform.position.y, transform.position.z);
        transform.position = Vector3.Slerp(transform.position, destination, Time.deltaTime * 5);
        transform.position = new Vector3(transform.position.x, newy, transform.position.z);
    }
}
