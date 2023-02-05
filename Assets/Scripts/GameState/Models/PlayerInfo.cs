using UnityEngine;

public class PlayerInfo : EntityBase
{
    public string Name { get; set; }    

    public Position Position { get; set; }
    
    public int Health { get; set; }
    
    public int MaxHealth { get; set; }
    
    public int Level { get; set; }
}