using UnityEngine;

public class GameObjectStateSaver : MonoBehaviour
{
    [SerializeField] private bool _saveStateOnFixedUpdate = true;
    private float counter = 0;
    private float autosaveCycleTime = 5;
    
    private void FixedUpdate()
    {
        if (_saveStateOnFixedUpdate)
        {
            GameStateTracker.SaveGameObjectState(gameObject);

            if (counter >= autosaveCycleTime)
            {
                GameStateTracker.SaveState(gameObject.name);
                counter = 0;
            }
            else
            {
                counter += Time.fixedDeltaTime;
            }
        }
    }
}