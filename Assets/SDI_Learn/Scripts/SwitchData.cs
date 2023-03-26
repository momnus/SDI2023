using NaughtyAttributes;
using System;
using System.Collections.Generic;
using UnityEngine;


[Serializable]
public class WWiseMaterialSwitch
{
        
        [ShowIf("ChangeHeader")][AllowNesting] public string switchName;
        public AK.Wwise.Switch materialSwitch;
        public Material[] materials;
        [Tooltip("If you want change name of list element click here")]
        public bool ChangeHeader;
}
[CreateAssetMenu(fileName = "SwitchData", menuName = "WwiseInfos/SwitchData", order = 0)]
public class SwitchData : ScriptableObject
    {
        public AK.Wwise.Switch defaultSwitch;
        public List<WWiseMaterialSwitch> MatSwitches = new List<WWiseMaterialSwitch>();
        


    /// <summary>
    /// Will pick a random clip to play in the assigned list. If you pass a material, it will try to find an
    /// override for that materials or play the default clip if none can ben found.
    /// </summary>
    /// <param name="overrideMaterial"></param>
    /// <returns> Return the choosen audio clip, null if none </returns>
    public void SetMaterialSwitch(Material overrideMaterial, GameObject GO)
        {
#if UNITY_EDITOR
// UnityEditor.EditorGUIUtility.PingObject(overrideMaterial);
#endif
         if (overrideMaterial == null) defaultSwitch.SetValue(GO);
           // Debug.Log("Set default Switch: " + defaultSwitch.Name);
         InternalSetMaterialSwitch(overrideMaterial, GO);
        }

    public void InternalSetMaterialSwitch(Material overrideMaterial, GameObject GO)
    {
        if (overrideMaterial != null)
        {
            foreach (var materialSwitch in MatSwitches)
            {
                foreach (var material in materialSwitch.materials)
                    if (material == overrideMaterial)
                    {
                        // Debug.Log("Surface: " + materialSwitch.materials);
                        //  Debug.Log("SurfaceSwitch: " + materialSwitch.materialSwitch.Name);
                        materialSwitch.materialSwitch.SetValue(GO);
                    }
            }
        }
    }
}

