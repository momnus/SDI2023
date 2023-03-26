using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class slider_sfx : MonoBehaviour
{
    /// <summary>
    /// Наш скрипт универсальный, мы можем его закидывать на несколько одинаковых слайдеров громкости
    /// </summary>
    private UnityEngine.UI.Slider ourSlider; // приватная переменная для доступа к слайдеру
    public AK.Wwise.RTPC Vol; // параметр громкости WWise  

    void Start()
    {
        ourSlider = gameObject.GetComponent<UnityEngine.UI.Slider> (); // переменной слайдера добавляем доступ к компоненту слайдера
        ourSlider.value = 1f;
    }

    /// <summary>
    /// Мы можем менять громкость каждый фрейм, но правельнее будет менять громкость только в случае ее изменения (функцию ValueChange)
    /// </summary>
    /// 

    //void Update()
    //{
    //    vcaController.getVolume(out vcaVolume);
    //    vcaController.setVolume(ourSlider.value);
    //}

    public void VolumeChange () // Создаем новую функцию, которую нужно обязательно подключить в компоненте слайдера On Value Changed
    {
        Vol.SetGlobalValue(ourSlider.value); // устанавливаем громкость шины VCA в такое же значение, как значение нашего слайдера
    }

}
