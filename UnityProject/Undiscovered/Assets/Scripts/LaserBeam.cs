using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class LaserBeam
{
    Vector2 pos, rot;
    GameObject laser;
    LineRenderer beam;
    List<Vector2> laserLocals = new List<Vector2>();
    public LaserBeam(Vector2 pos, Vector2 rot, Material material)
    {
        this.beam = new LineRenderer();
        this.laser = new GameObject();
        this.laser.name = "LaserVisuals";
        this.pos = pos;
        this.rot = rot;

        this.beam = this.laser.AddComponent<LineRenderer>();
        this.beam.startWidth = 0.1f;
        this.beam.endWidth = 0.1f;
        this.beam.material = material;
        this.beam.startColor = Color.yellow;
        this.beam.endColor = Color.red;
        CastRay(pos, rot, beam);
    }
    void CastRay(Vector2 pos, Vector2 rot, LineRenderer laser)
    {
        
        laserLocals.Add(pos);
        Ray2D ray = new Ray2D(pos, rot);
        RaycastHit2D hit = Physics2D.Raycast(pos, rot);

        if (hit)
        {
            laserLocals.Add(hit.point);
            UpdateLaser();
        }
        else
        {
            laserLocals.Add(ray.GetPoint(30));
            UpdateLaser();
        }
    }
    void UpdateLaser()
    {
        int count = 0;
        beam.positionCount = laserLocals.Count;
        foreach(Vector2 position in laserLocals)
        {
            beam.SetPosition(count, position);
            count++;
        }
    }
     /*void Update()
    {
        this.beam.positionCount = 0;
        laserLocals.Clear();
        CastRay(pos, rot, beam);
    }
    public LaserBeam()
    {
        UpdateManager.OnUpdate += Update;
    }

    ~LaserBeam()
    {
        UpdateManager.OnUpdate -= Update;
    }*/
}
