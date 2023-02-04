using UnityEngine;

public class GameObjectStateSaver : MonoBehaviour
{
    [SerializeField] private bool _saveStateOnFixedUpdate = true;
        
    private void FixedUpdate()
    {
        if (_saveStateOnFixedUpdate)
        {
            GameStateTracker.SaveGameObjectState(gameObject);
        }
    }
}