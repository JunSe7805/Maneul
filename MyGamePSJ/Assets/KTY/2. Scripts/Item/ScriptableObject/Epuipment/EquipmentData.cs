using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentData : ItemData
{
	public enum EquipmentType
	{
		Weapon = 0,     // ����
		Armor,			// ��
	}

	[Header("���")]
	[Space(20)]

	public EquipmentType equipmentType;

	[Space(20)]

	[Tooltip("���� ����")]
	public bool isWearable;

	public override void Use()
	{
		Debug.Log(this.name + " ����");
	}
}
