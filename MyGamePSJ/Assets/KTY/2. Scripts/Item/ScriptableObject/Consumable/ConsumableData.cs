using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemSO", menuName = "Create_ItemData/Consumable", order = 12)] // CreateAssetMenu(defult ���ϸ�, �޴� �̸�, ����)
public class ConsumableData : ItemData
{
	public enum ConsumableType // �� �� �����ϱ�
	{
		Active = 0,		// ��Ƽ��?
		Potion,			// ����
		Ammo,			// ź��
		Food,			// ����
	}

	[Header("�Ҹ�ǰ")]
	[Space(20)]

	[Tooltip("�Ҹ�ǰ Ÿ��")]
	public ConsumableType consumableType;

	[Space(20)]

	[Tooltip("�Ҹ𰡴� ����")]
	public bool isEatable;

	public float coolTime;

	public override void Use()
	{
		Debug.Log(this.name + " ���");
	}
}
