using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TimedExplosion : MonoBehaviour
{
    private float _timeToExplode = 3f;
    private float _radius = 2f;
    
    private void FixedUpdate()
    {
        if (_timeToExplode <= 0)
        {
            foreach (var gameObject in GetDestroyedGameObjects())
            {
                gameObject.SetActive(false);
            }
            AudioPlayer audioPlayer = gameObject.AddComponent<AudioPlayer>();
            
            audioPlayer.Source = gameObject.AddComponent<AudioSource>();
            audioPlayer.Source.clip = Resources.Load<AudioClip>("Audio/Effects/expl01.wav");
            audioPlayer.Play();
            
            Destroy(gameObject);
        }
        else
        {
            _timeToExplode -= Time.fixedDeltaTime;
        }
    }
    
    private IEnumerable<GameObject> GetDestroyedGameObjects()
    {
        var gameObjects = FindObjectsOfType<GameObject>();
        foreach (var gameObject in gameObjects)
        {
            if (gameObject.name.ToLower() == "Destructable" && gameObject.TryGetComponent<Tilemap>(out var destroyable) && destroyable.enabled)
            {
                var tiles = destroyable.GetTilesBlock(destroyable.cellBounds);

                foreach (var tile in tiles)
                {
                    var tileGameObject = tile.GameObject();
                    if (Vector2.Distance(tileGameObject.transform.position, transform.position) <= _radius)
                    {
                        yield return tileGameObject;
                    }    
                }
            }
        }
    }
}
