using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
///  Для переключения между двумя различными состояниями (вариантами музыки, атмосфер и т.д.) удобно использовать тонкий коллайдер.
///  Это можно сделать, создав простую фигуру Quad в Unity, и затем повесить на неё этот скрипт и включить галочку trigger на компоненте Collider.
/// </summary>

public class ChangeState : MonoBehaviour
{
    bool trigger;                               // булевая переменная - наш переключатель (значения "да/нет")
    public AK.Wwise.State State1;               // наш первый State из Wwise
    public AK.Wwise.State State2;               // наш второй State из Wwise

    // Start is called before the first frame update
    void Start()    // на старте выставляем
    {
        trigger = true;        // Ставим наше значение переключатель в значение "да"
    }

    /*
     *
     *
    */


    private void OnTriggerEnter(Collider other) // метод реации на пересечение триггера
    {
        if (other.CompareTag("Player"))     //проверка, что тег объекта, который пересекает триггер, "Player".
        { trigger = !trigger;               // логичерская операция смены значения у переключателя. 
                                            //Восклиц. знак перед переменной обозначает обратное значение переменной, 
                                            // то есть если триггер был со значением "да", то он меняется на "нет" и наоборот
        }
    }
    // Update is called once per frame
    void Update() // метод Update выполняет дейтвия, которые там прописаны при каждом обновлении кадров ( например, каждые 60 кадров при fps=60)
    {
        Change();   // методы можно вкладывать друг в друга, это удобно, чтобы не городить большой огород из непонятных систем. 
                    // Тут мы каждый кадр обновляем функцию Change
    }

    private void Change()   // написанный нами метод. Тут мы указываем, какие значения State должны быть при смене значений переключателя
    {
        if (trigger)        { State1.SetValue(); }  // если переключатель в значении "да", то у нас State1 из Wwise
        if (!trigger)       { State2.SetValue(); }  // если переключатель в значении "нет", то у нас State2 из Wwise
    }
}
