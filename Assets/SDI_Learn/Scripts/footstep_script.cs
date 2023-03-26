using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class footstep_script : MonoBehaviour
{
    public AK.Wwise.Event footevent; // выбираем ивент Wwise
    public LayerMask lm;



    private void Awake()
    {
        
    }
    private void Playfootstep() 
    {
        if (Physics.Raycast(transform.position, Vector3.down, out RaycastHit hit, 0.3f, lm)) // запускаем рейкаст из объекта нужной ноги вниз
        {
            AkSoundEngine.SetSwitch("surface_type", hit.collider.tag, gameObject); // выставляем свитч нужной свитч-группы в положение такое же как тэг поверхности, на которую наступила нога, применяем свитч для нужной ноги
          //  footevent.Post(gameObject); // запускаем ивент для из нужной ноги
            print(hit.collider.tag);
        }
    }


}
