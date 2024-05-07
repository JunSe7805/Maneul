using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems; // ���콺�� ũ�ν� ������ ���� �� ������ ����â�� �߰� �ϱ� ����.

public class InvenSlot : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
	public SlotInfo slotInfo; // <- ���� ���� ( ����: ������ ����, ������ ���� )

	int _id; // ������ ���� �ѹ�
	Image _img; // ������ ������ �̹���
	int _amount; // ������ ������ ����

	// ������Ƽ �����ٰ� ����
	//#region *������ ������
	//// ������ ������ ----------
	//ItemData _itemData;

	//public ItemData Item
	//{
	//	get { return _itemData; }
	//	set { _itemData = value; }
	//}
	//// ------------------------
	//#endregion

	//#region *������ ID
	//// ������ ID/Num ----------
	//int itemId;
	//public int ItemID
	//{
	//	get { return itemId; }
	//	set { itemId = value; }
	//}
	//#endregion

	//#region *������ �̹���
	//Image itemImg;

	//public Image ItemImg
	//{
	//	get { return itemImg; }
	//	set { itemImg.sprite = value.sprite; }
	//}
	//#endregion

	//#region *������ ����
	//int itemAmount = 0; // ������ ����

	//public int ItemAmount
	//{
	//	get { return itemAmount; }
	//	set { itemAmount = value; }
	//}
	//#endregion

	[HideInInspector] public bool fullSlot = false; // ���� ä���� ����

	Text amountTxt; // ���� �ؽ�Ʈ
	Button slotBtn; // ���� ��ȣ�ۿ� ��ư

	[Space(20)]
	[SerializeField] Sprite defSpr; // �ƹ��͵� ���� �� ����Ʈ ��������Ʈ

	private void Awake()
	{
		//itemImg = transform.GetChild(0).GetComponent<Image>();
		_img = transform.GetChild(0).GetComponent<Image>();
		amountTxt = transform.GetComponentInChildren<Text>();

		slotBtn = GetComponent<Button>();
	}
	// Start is called before the first frame update
	void Start()
    {
        SlotInit();
    }

    // Update is called once per frame
    void Update()
    {
        SlotUpdate();
    }

	/// <summary>
	/// �⺻ ����
	/// </summary>
	void SlotSetting()
	{
		if (slotInfo.item != null)
		{
			if (slotInfo.amount != 0) // ������ 0�� �ƴ϶��
			{
				// ���� ������ ������ ���� ���� ���� -------
				_id = slotInfo.item.itemNum;
				_img.sprite = slotInfo.item.itemSpr;
				_amount = slotInfo.amount;

				fullSlot = true;
			}
			else // ������ 0�̶��
			{
				if (ItemDictionary.CheckData(_id)) // �ش� Id�� ��ųʸ��� �����ϸ�
				{
					ItemDictionary.itemDic.Remove(_id); // ������
				}
				Refresh();
			}
		}
		else
		{
			_id = 0;
			_img.sprite = defSpr; // ���� �̹��� �⺻ �̹����� ����
			_amount = 0;
		}

		// ������ ������ 0���� ũ�� ������ Ÿ���� �������� ��
		if (slotInfo.amount > 0 && slotInfo.item.isStackable)
		{
			amountTxt.text = _amount.ToString(); // ���� ǥ��
		}
		else
		{
			amountTxt.text = "";
		}
	}

	/// <summary>
	/// ���� û��
	/// </summary>
	public void Refresh()
	{
		slotInfo = new SlotInfo(); // ���� �ʱ�ȭ (������ = null, ���� = 0)

		_img.sprite = defSpr; // ���� �̹��� �⺻ �̹����� ����

		fullSlot = false;
	}

	/// <summary>
	/// ���� Init
	/// </summary>
	void SlotInit()
	{
		SlotSetting();

		slotBtn.onClick.AddListener(ItemUse);
	}

	/// <summary>
	/// ���� Update
	/// </summary>
	void SlotUpdate()
	{
		SlotSetting();

		if (fullSlot == false)
		{
			slotBtn.enabled = false;
		}
		else
		{
			slotBtn.enabled = true;
		}
	}

	/// <summary>
	/// ���� ���
	/// </summary>
	void ItemUse()
	{
		//_itemData.Use(); // �������̵�� �Լ�
		slotInfo.item.Use();

		switch (slotInfo.item.itemType)
		{
			// ������ Ÿ���� �Ҹ��� �������� ��
			case ItemData.ItemType.Consumable:
				{
					ConsumableData consumableData = (ConsumableData)slotInfo.item;

					if (consumableData.isEatable) // �ش� �Ҹ�ǰ�� ���� �� �ִٸ�
					{
						slotInfo.amount--;

						ItemManager.instance.Consume(consumableData);
					}
				}
				break;

			// ������ Ÿ���� ������ �������� ��
			case ItemData.ItemType.Equipment:
				{
					EquipmentData equipmentData = (EquipmentData)slotInfo.item;

					ItemManager.instance.Equip(equipmentData);
				}
				break;
		}
		//// ������ Ÿ���� �Ҹ��� �������� ��
		//if (slotInfo.item.itemType == ItemData.ItemType.Consumable)
		//{
		//	ConsumableData consumableData = (ConsumableData)slotInfo.item;

		//	if (consumableData.isEatable) // �ش� �Ҹ�ǰ�� ���� �� �ִٸ�
		//	{
		//		slotInfo.amount--;
		//	}
		//}
	}

	// ����â�� ���� ����----------------------------------------------------------------------

	// ����â ����
	public void OnPointerEnter(PointerEventData eventData)
	{
		if (slotBtn.enabled)
		{
			FollowWindow.instance.Data = slotInfo.item;
			FollowWindow.instance.ShowWindow();
		}
	}

	// ����â �����
	public void OnPointerExit(PointerEventData eventData)
	{
		if (slotBtn.enabled || _amount == 0)
		{
			FollowWindow.instance.CloseWindow();
		}
	}
}
