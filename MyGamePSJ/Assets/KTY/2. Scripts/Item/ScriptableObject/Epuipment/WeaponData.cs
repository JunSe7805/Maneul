using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemSO", menuName = "Create_ItemData/Weapon", order = 0)] // CreateAssetMenu(defult ���ϸ�, �޴� �̸�, ����)
public class WeaponData : EquipmentData
{
	public enum WeaponType
	{
		Shield = 0,		// ����
		Sword,			// ��
		Bow,			// Ȱ
	}

	[Header("����")]
	[Space(20)]

	[Tooltip("����Ÿ��")]
	public WeaponType weaponType;

	[Tooltip("���ݷ�")]
	public float Atk;

	public override void Use()
	{
		base.Use();
		Debug.Log("���ݷ�: " + Atk);

		//switch (weaponType)
		//{
		//	case WeaponType.Shield:
		//		Debug.Log("���ݷ�: " + Atk);
		//		break;

		//	case WeaponType.Sword:
		//		Debug.Log("���ݷ�: " + Atk);
		//		break;

		//	case WeaponType.Bow:
		//		Debug.Log("���ݷ�: " + Atk);
		//		break;
		//}
	}
}
