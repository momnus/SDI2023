using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;



public class PlayExampleSFX : MonoBehaviour

{
    #region EVENTS

    [System.Serializable]
    public struct ExampleEvents
    {
        public UnityEvent OnPressStart;
        public UnityEvent OnEnable;
        public UnityEvent OnDisable;
        public UnityEvent OnDestroy;
        public UnityEvent OnCollisionEnter;
    }
    public ExampleEvents events;
    #endregion



    // Start is called before the first frame update
    void Start()
    {
      //  Debug.Log("bg.Test.OnPressStart");
        events.OnPressStart.Invoke();
    }

    void OnEnable()
    {
      //  Debug.Log("bg.Test.OnEnable");
        events.OnEnable.Invoke();
    }
    void OnDisable()
    {
      //  Debug.Log("bg.Test.OnDisable");
        events.OnDisable.Invoke();
    }

    void OnDestroy()
    {
      //  Debug.Log("bg.Test.OnDestroy");
        events.OnDestroy.Invoke();
    }
}