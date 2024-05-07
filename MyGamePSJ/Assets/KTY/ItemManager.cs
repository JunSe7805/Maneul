using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    public static ItemManager instance;

    [SerializeField] GameManager gManager;

    enum EquipSlot { No1 = 0, No2,}
    EquipSlot equipSlot;

    enum Consumable { HPPotion = 2001, MPPotion, SPPotion, CLPotion, Dango, }
    Consumable csNum;
    private void Awake()
	{
        instance = this;

        gManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
	}


    /// <summary>
    /// ��� ����
    /// </summary>
    /// <param name="_eq"></param>
    public void Equip(EquipmentData _eq)
	{
		switch (_eq.equipmentType)
		{
            case EquipmentData.EquipmentType.Weapon:
                gManager.Eq1 = (WeaponData)_eq;
                break;
            case EquipmentData.EquipmentType.Armor:
                gManager.Eq2 = (ArmorData)_eq;
                break;
		}
	}

    /// <summary>
    /// �Ҹ�ǰ ���
    /// </summary>
    /// <param name="_cs"></param>
    public void Consume(ConsumableData _cs)
	{
        csNum = (Consumable)_cs.itemNum;

		//if (_cs.itemName == "��������")
		//{
  //          gManager.hp += 500;
		//}

		switch (csNum)
		{
            case Consumable.HPPotion:
                gManager.hp += 500;
                break;

            case Consumable.MPPotion:
                gManager.mana += 500;
                break;

            case Consumable.SPPotion:
                gManager.stamina += 100;
                break;

            case Consumable.CLPotion:
                gManager.isSick = false;
                break;

            case Consumable.Dango:
                break;

            default:
                return;
        }
    }

    // ���� ������� ��� �ذ�����?
    IEnumerator Buff_DeBuff(float coolTime)
	{

        yield return new WaitForSeconds(coolTime);
	}
}
