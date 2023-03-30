using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTargetX : MonoBehaviour
{
    public GameObject target;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        var destination = new Vector3(target.transform.position.x, transform.position.y,transform.position.z);
        transform.position = Vector3.Slerp(transform.position, destination, Time.deltaTime * 5);
    }
}
