using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSpeedRTPC : MonoBehaviour
{
    [SerializeField] private AK.Wwise.RTPC speedRTPC;
    private ThirdPersonController controller;
    // Start is called before the first frame update
    void Awake()
    {
        controller = GetComponent<ThirdPersonController>();
        if (controller == null)
        {
            controller = GetComponentInParent<ThirdPersonController>();
            print(controller.gameObject.name);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (controller._speed > 0) 
        { 
            speedRTPC.SetGlobalValue(controller._speed);
         //  Debug.Log("speed: " + controller._speed);    
        }
    }
}
