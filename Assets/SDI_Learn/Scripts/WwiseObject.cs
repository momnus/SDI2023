using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[CreateAssetMenu(fileName = "WwiseObject", menuName = "WwiseInfos/WwiseObject", order = 0)]
// Derive Class from Scriptable Object
public class WwiseObject : ScriptableObject
{
    // Link Wwise Event to Object
    public AK.Wwise.Event wwiseEvent;
    [Tooltip("Fade time in ms")]
    public int fade;
    public AkCurveInterpolation FadeCurve;
    // Post Wwise Event
        public void PostWwiseEvent(GameObject caller)
    {
        // Successful Post
        if (wwiseEvent.IsValid())
        {
          // Debug.Log("Played Wwise Event: " + wwiseEvent);
            wwiseEvent.Post(caller);
        }

        // Unsuccessful Post
        else
        {
            Debug.LogWarning("Warning: Missing Event for Wwise Object: " + name);
        }
    }

    public void StopWwiseEvent(GameObject caller)
    {
        // Successful Post
        if (wwiseEvent.IsValid())
        {
            Debug.Log("Played Wwise Event: " + wwiseEvent);
            wwiseEvent.Stop(caller,fade, FadeCurve);
        }

        // Unsuccessful Post
        else
        {
            Debug.LogWarning("Warning: Missing Event for Wwise Object: " + name);
        }
    }

}