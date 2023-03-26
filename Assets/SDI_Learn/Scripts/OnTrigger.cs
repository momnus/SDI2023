using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTrigger : MonoBehaviour
{
	public AK.Wwise.Event EnterSound;			// событие на запуск звука
	public AK.Wwise.Event ExitSound;       // событие на остановку звука


	private void OnTriggerEnter(Collider other) //метод, который задает действия при входе в коллайдер. В скобках указана переменная, по которой проверять
	{
		if (other.CompareTag("Player"))	// проверка - если у объекта который вошел в коллайдер указан Тег "Player", то нужно совершить действия в фигурных скобках
		{
            EnterSound.Post(gameObject);	//вызываем наш звук на объекте с тригером
		}
	}

	private void OnTriggerExit(Collider other) // всё что происходило выше, но только при выходе из коллайдера
	{
		if (other.CompareTag("Player"))
		{
            ExitSound.Post(gameObject);
		}
	}

}
