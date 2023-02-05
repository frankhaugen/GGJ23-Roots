using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombController : MonoBehaviour
{
     [SerializeField] private GameObject bomb;
    public int bombs = 1;
    public int maxBombs = 10;
    
    public KeyCode inputDropBomb = KeyCode.Space;


     private void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.name == "Bomb")
        {
            Destroy(collision.gameObject);
            bombs++;
        }
    }
    
    

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(inputDropBomb) && bombs > 0)
        {
            var DroppedBomb = Instantiate(bomb, transform.position, Quaternion.identity);
            DroppedBomb.name = "Bomb_armed";
            bombs--;
        }

        
    }

}
