using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
	public ItemData itemData;
	public int amount = 1;

	public SlotInfo _itemInfo = new SlotInfo();

	private void Start()
	{
		_itemInfo.item = itemData;
		_itemInfo.amount = amount;
	}

	private void OnTriggerEnter(Collider col)
	{
		// �÷��̾�� ��Ұ� && (�κ��丮�� �� ���� �ʾҰų� or (�κ� ��á�µ� && �������̰� && ��ųʸ��� �ִٸ�))
		if (col.CompareTag("Player") && (!InventoryManager.instance.fullInven || (InventoryManager.instance.fullInven && itemData.isStackable && ItemDictionary.CheckData(itemData.itemNum))))
		{
			// ������ ����(�ø��� �ߺ� �۵����� ���� ��ġ ���� ������ ����)
			Collider coll = GetComponent<Collider>();
			coll.enabled = false;
			Rigidbody rig = GetComponent<Rigidbody>();
			rig.isKinematic = true;


			InventoryManager.instance.AddItem(_itemInfo);
			Destroy(gameObject);
		}
	}
}
