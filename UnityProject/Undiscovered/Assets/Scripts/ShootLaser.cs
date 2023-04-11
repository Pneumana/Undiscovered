using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;
using static UnityEngine.Rendering.DebugUI.Table;
using UnityEngine.Rendering.Universal;

public class ShootLaser : MonoBehaviour
{
    public Material mat;
    LaserBeam beam;
    public LineRenderer linerenderer;
    public GameObject particlesystem;
    List<Vector2> laserLocals = new List<Vector2>();
    public bool isMirror;
    public bool powered;
    public int coyoteFrames;
    // Start is called before the first frame update
    private void Start()
    {
        //linerenderer.widthMultiplier = 0.2f;
    }
    void Update()
    {
        //this is horribly inefficient but this is a sprint, not a polish contest
        //Destroy(GameObject.Find("LaserVisuals"));
        //beam = new LaserBeam(transform.position, -transform.up, mat);
        if (!isMirror) {
            laserLocals.Clear();
            CastRay(transform.position, -transform.up, linerenderer);
        }
        else
        {
            if (coyoteFrames > 0)
            {
                linerenderer.widthMultiplier = 0.1f;
                laserLocals.Clear();
                CastRay(transform.position, -transform.up, linerenderer);
            }
            if(coyoteFrames <= 0)
            {
                powered = false;
                linerenderer.widthMultiplier = 0;
                particlesystem.transform.position = new Vector3(0, -10);
            }
        }
        if(coyoteFrames > 0)
        {
            coyoteFrames-= 1;
            Debug.Log("lower");
        }
    }
    void UpdateLaser()
    {
        int count = 0;
        linerenderer.positionCount = laserLocals.Count;
        foreach (Vector2 position in laserLocals)
        {
            linerenderer.SetPosition(count, position);
            count++;
        }
    }
    void CastRay(Vector2 pos, Vector2 rot, LineRenderer laser)
    {
        //laserLocals.Clear();
        laserLocals.Add(pos);
        Ray2D ray = new Ray2D(pos, -transform.up);
        Vector2 belowReflection = new Vector2(pos.x + (0.6f * rot.x), pos.y + (0.6f * rot.y));
        RaycastHit2D hit = Physics2D.Raycast(belowReflection, -transform.up);

        if (hit)
        {
            laserLocals.Add(hit.point);
            //linerenderer.transform.position = transform.position;
            particlesystem.transform.position = hit.point;
            Debug.DrawLine(transform.position,hit.point);
            UpdateLaser();
            if(hit.collider.gameObject.tag == "Mirror")
            {
                //reflect laser
                //Debug.Log("laser hits " + hit.collider.gameObject.name);
                //hit.collider.gameObject.GetComponent<ShootLaser>().powered = true;
                hit.collider.gameObject.GetComponent<ShootLaser>().coyoteFrames = 10;
            }
            if(hit.collider.gameObject.name == "LaserEndpoint")
            {
                hit.collider.gameObject.GetComponent<Light2D>().enabled = true;
                GameObject.Find("LaserDoor").GetComponent<FireDoor>().UpdateTorches();
            }
            if (hit.collider.gameObject.name == "LaserEndpoint1")
            {
                hit.collider.gameObject.GetComponent<Light2D>().enabled = true;
                GameObject.Find("LaserDoor1").GetComponent<FireDoor>().UpdateTorches();
            }
        }
        else
        {
            laserLocals.Add(ray.GetPoint(30));
            particlesystem.transform.position = ray.GetPoint(30);
            UpdateLaser();
        }
    }
    // Update is called once per frame
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "Golem")
        {
            gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.left * 2;
            
            gameObject.GetComponent<Collider2D>().isTrigger = true;
        }
    }
}
