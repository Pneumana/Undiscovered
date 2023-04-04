using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;
using static UnityEngine.Rendering.DebugUI.Table;

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
            if (powered && coyoteFrames > 0)
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
            coyoteFrames--;
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
        Vector2 belowReflection = new Vector2(pos.x + (0.6f * rot.x), pos.y);
        RaycastHit2D hit = Physics2D.Raycast(belowReflection, -transform.up);

        if (hit)
        {
            laserLocals.Add(hit.point);
            //linerenderer.transform.position = transform.position;
            particlesystem.transform.position = hit.point;
            UpdateLaser();
            if(hit.collider.gameObject.name == "Mirror")
            {
                //reflect laser
                Debug.Log("laser hits mirror");
                hit.collider.gameObject.GetComponent<ShootLaser>().powered = true;
                hit.collider.gameObject.GetComponent<ShootLaser>().coyoteFrames = 10;
            }
        }
        else
        {
            laserLocals.Add(ray.GetPoint(30));
            UpdateLaser();
        }
    }
    // Update is called once per frame

}
