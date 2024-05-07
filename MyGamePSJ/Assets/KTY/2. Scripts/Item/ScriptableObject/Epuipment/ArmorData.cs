using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemSO", menuName = "Create_ItemData/Armor", order = 1)] // CreateAssetMenu(defult ���ϸ�, �޴� �̸�, ����)
public class ArmorData : EquipmentData
{
	public enum ArmorType // �� �ʿ��Ѱ�?
	{
		Cloth = 0,		// õ
		Leather,        // ����
		Plate,          // �Ǳ�
	}

	[Header("��")]
	[Space(20)]

	[Tooltip("��Ÿ��")]
	public ArmorType armorType;

	[Tooltip("����")]
	public float Def;

	[Tooltip("�ִ� ü�� ������")]
	public float MaxHpPlus;

	public override void Use()
	{
		base.Use();
		Debug.Log("����: " + Def + "\nü��+: " + MaxHpPlus);
	}
}
