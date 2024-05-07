using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[CreateAssetMenu(fileName = "ItemSO", menuName = "Create_ItemData", order = 0)] // CreateAssetMenu(defult ���ϸ�, �޴� �̸�, ����)
public abstract class ItemData : ScriptableObject // �߻� Ŭ����
{
	// ������ Ÿ��
	public enum ItemType
	{
		None = 0,
		Equipment,		// ��� ������
		Consumable,		// �Һ� ������
		Others,			// ��Ÿ ������
		//Gold,			// ��ȭ: ���
	}

	[Header("������")]

	[Tooltip("������ ��ȣ")]
	public int itemNum;

	[Space(20)]

	[Tooltip("������ Ÿ��")]
	public ItemType itemType;


	[Tooltip("������ ��������Ʈ")]
	public Sprite itemSpr;

	//[Tooltip("������ 3D ��")]
	//public GameObject itemModel;


	[Tooltip("������ �̸�")]
	public string itemName;

	[Tooltip("������ ����")] [Multiline(5)]
	public string description;


	[Space(20)]
	[Tooltip("������ ����")]
	public bool isStackable;


	public virtual void Use() { }
}
