using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PhysMatSwitches
{
    public PhysicMaterial SwitchMaterial;
    public AK.Wwise.Switch MatSwitch;
}
[DisallowMultipleComponent]
public class PhysMatSwitch : MonoBehaviour
{
    [SerializeField] private AK.Wwise.Switch DefaultSwitch;
    [SerializeField] private PhysMatSwitches[] switches;
    [SerializeField] private GameObject[] TouchPoint;



    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.collider.sharedMaterial == null) { DefaultSwitch.SetValue(gameObject); }
        foreach (var material in switches)

        {
            if (material.SwitchMaterial == hit.collider.sharedMaterial)
            {
                if (TouchPoint.Length != 0)
                {
                    for (int i = 0; i < TouchPoint.Length; i++)
                    {
                        if (TouchPoint[i] == null) 
                        { 
                            Debug.Log("Forgot to set TouchPoint");
                            return;
                        }
                        material.MatSwitch.SetValue(TouchPoint[i]);
                        print("TouchPoint: " + TouchPoint[i] + ", material: " + material.MatSwitch.Name);

                    }
                }
                else
                {
                    material.MatSwitch.SetValue(gameObject);
                    print("test");
                }
                //   print("Material: " + hit.collider.sharedMaterial);
                //  print("Switch: " + material.MatSwitch.Name);

            }
        }
    }
}
