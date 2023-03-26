using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class AnimSounds 
{
    [Tooltip("soundName string must be like string in Animation")]
    public string soundName;
    public AK.Wwise.Event animSound;
    public GameObject soundGO;
    public bool mute = false;

}

public class Animation_SFX : MonoBehaviour
{
	[SerializeField] private AnimSounds[] sounds;
	private GameObject _go;

	
	
	void PlaySFX(string Event)
	{
	foreach (var sound in sounds) 
		{ if (sound.soundName == Event) 
			{
                if (sound.mute) { return; }
				_go = sound.soundGO;
				  if (!_go) { _go = gameObject; }
				   sound.animSound.Post(_go);
				Debug.Log("GO: " + _go); // + ", event:" + sound.animSound.Name + ", name: " + sound.soundName);
            } 
		}
	}
}