using System.Collections;
using System.Collections.Generic;
using System.Runtime.Remoting;
using UnityEngine;

[UnityEditor.CustomEditor(typeof(PhysMatSwitch))]
public class PhysMatSwitchInspector : UnityEditor.Editor
{
    PhysMatSwitch script;
    GameObject scriptObject;


    void OnEnable()
    {
        script = (PhysMatSwitch)target;
        scriptObject = script.gameObject;
    }

    
    public override void OnInspectorGUI()
    {

        if (ControllerColliderCheck(scriptObject)) { base.OnInspectorGUI();}

        else {
            UnityEngine.GUILayout.Space(UnityEditor.EditorGUIUtility.standardVerticalSpacing);

            using (new UnityEditor.EditorGUILayout.VerticalScope("box"))
            {
                UnityEditor.EditorGUILayout.HelpBox(
                    "Script need to be on CharacterController",
                    UnityEditor.MessageType.Error);
            }
        }
        
        
        

    }

    public static bool ControllerColliderCheck(UnityEngine.GameObject gameObject)
    {

        var collider = gameObject.GetComponent<CharacterController>();
        if (collider == null || !collider.enabled)
        {
            return false;
        }
        else return true;
        
    }
}
