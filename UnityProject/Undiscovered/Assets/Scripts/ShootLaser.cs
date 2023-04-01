using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootLaser : MonoBehaviour
{
    public Material mat;
    LaserBeam beam;
    // Start is called before the first frame update
    void Update()
    {
        //this is horribly inefficient but this is a sprint, not a polish contest
        Destroy(GameObject.Find("LaserVisuals"));
        beam = new LaserBeam(transform.position, -transform.up, mat);
    }

    // Update is called once per frame
    
}
