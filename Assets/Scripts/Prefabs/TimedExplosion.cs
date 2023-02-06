using System;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TimedExplosion : MonoBehaviour
{
    private float _timeToExplode = 3f;
    private float _radius = 2f;
    private bool _hasExploded;
    
    private void FixedUpdate()
    {
        if (_hasExploded) return;
        if (_timeToExplode <= 0)
        {
            Logger.LogInfo("Exploding!");
            _hasExploded = true;
            try
            {
                DestroyGameObjects();
            }
            catch (Exception e)
            {
                Debug.LogException(e);
                Logger.LogError(e);
            }
            
            
            try
            {
                // AudioPlayer audioPlayer = gameObject.AddComponent<>();
                // audioPlayer.Source = gameObject.AddComponent<AudioSource>();
                // audioPlayer.Source.clip = Resources.Load<AudioClip>("Audio/Effects/expl01.wav");
                // audioPlayer.Play();
            }
            catch (Exception e)
            {
                Logger.LogError(e);
                Debug.LogException(e);
            }
        }
        else
        {
            _timeToExplode -= Time.fixedDeltaTime;
        }
    }
    
    private void DestroyGameObjects()
    {
        var grid = FindObjectOfType<Grid>();
        
        var gridChildren = grid.GetComponentsInChildren<Tilemap>();
        var destructibleTiles = gridChildren.FirstOrDefault(x => x.name == "Destructable");

        if (destructibleTiles == null)
        {
            Logger.LogWarning("No destructible tiles found");
            return;
        }
        
        var cell = destructibleTiles.WorldToCell(transform.position);
        
        RemoveCells(cell, destructibleTiles);
    }
    
    private void RemoveCells(Vector3Int cell, Tilemap destructibleTiles)
    {
        var tile =  destructibleTiles.GetTile<Tile>(cell);
        if (tile == null || tile.name != "terrain_atlas_1") return;
        
        var cells = GetCellsInRadius(cell, _radius);
        
        foreach (var c in cells)
        {
            tile = destructibleTiles.GetTile<Tile>(c);
            if (tile != null && tile.name == "terrain_atlas_1") destructibleTiles.SetTile(c, null);
        }
    }
    
    private IEnumerable<Vector3Int> GetCellsInRadius(Vector3Int cell, float radius)
    {
        var cells = new List<Vector3Int> { cell };
        
        for (var x = -5; x <= 5; x++)
        {
            for (var y = -5; y <= 5; y++)
            {
                var tempCell = new Vector3Int(cell.x + x, cell.y + y, 0);
                if (Vector3Int.Distance(cell, tempCell) <= radius) cells.Add(tempCell);
            }
        }
        return cells;
    }
}
