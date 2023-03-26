using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTrigger : MonoBehaviour
{
	public AK.Wwise.Event EnterSound;			// ������� �� ������ �����
	public AK.Wwise.Event ExitSound;       // ������� �� ��������� �����


	private void OnTriggerEnter(Collider other) //�����, ������� ������ �������� ��� ����� � ���������. � ������� ������� ����������, �� ������� ���������
	{
		if (other.CompareTag("Player"))	// �������� - ���� � ������� ������� ����� � ��������� ������ ��� "Player", �� ����� ��������� �������� � �������� �������
		{
            EnterSound.Post(gameObject);	//�������� ��� ���� �� ������� � ��������
		}
	}

	private void OnTriggerExit(Collider other) // �� ��� ����������� ����, �� ������ ��� ������ �� ����������
	{
		if (other.CompareTag("Player"))
		{
            ExitSound.Post(gameObject);
		}
	}

}
