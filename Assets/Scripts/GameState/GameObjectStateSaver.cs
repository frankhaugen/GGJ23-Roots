using UnityEngine;

public class GameObjectStateSaver : MonoBehaviour
{
    [SerializeField] public bool _saveStateOnFixedUpdate = true;
    
    [SerializeField] public float autosaveCycleTime = 5;
    
    [SerializeField] private float counter = 0;
    
    private void FixedUpdate()
    {
        if (_saveStateOnFixedUpdate)
        {
            GameStateTracker.SaveGameObjectState(gameObject);

            if (counter >= autosaveCycleTime)
            {
                GameStateTracker.WriteStateToDisk(gameObject.name);
                counter = 0;
            }
            else
            {
                counter += Time.fixedDeltaTime;
            }
        }
    }
}