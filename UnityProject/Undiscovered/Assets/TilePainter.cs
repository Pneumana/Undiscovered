using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
public class TilePainter : MonoBehaviour
{
    public Tile tile;

    public Vector3Int position;
    public ParticleSystem debris;
    public Tilemap tilemap;
    private void Update()
    {
        //kills the tile at the position
        var grid = tilemap.GetComponentInParent<Grid>();
        var tilepos = grid.WorldToCell(transform.position);
        if(tilemap.GetTile(tilepos) != null)
        {
            tilemap.SetTile(tilepos, null);
            debris.Emit(5);
        }
        
    }
}
