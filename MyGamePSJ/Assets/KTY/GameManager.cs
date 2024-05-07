using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
/*
 * 1. ��ųʸ� Ȯ�� ��
 * 
 * 2. ������ ��� �׽���
 */

public class GameManager : MonoBehaviour
{
	List<int> amylist = new List<int> { 1, 5, 8, 4, 3 };

	Transform status;
	Transform BuffPnl;

	Image img_Eq1;
	Image img_Eq2;

	[SerializeField] Sprite defSpr;

	Text txt_Eq1;
	Text txt_Eq2;

	Text txt_Hp;
	Text txt_Mp;
	Text txt_Sp;

	Text txt_Atk;
	Text txt_Def;

	Image img_Sick;
	[SerializeField] Sprite sickSpr;

	[Space(10)]
	[Header("���� ����")]
	[SerializeField] float maxHp; // ��ü ü��
	[SerializeField] float maxMp;
	[SerializeField] float maxSp;

	[Space(10)]
	[SerializeField] float atk;   // ���ݷ�
	[SerializeField] float def;   // ����

	[Space(10)]
	[Header("���")]
	[Space(20)]
	// ����
	[SerializeField] WeaponData eq1;
	public WeaponData Eq1
	{
		get { return eq1; }
		set { eq1 = value; }
	}

	// ��
	[SerializeField] ArmorData eq2;
	public ArmorData Eq2
	{
		get { return eq2; }
		set { eq2 = value; }
	}

	[Space(10)]
	[Header("��� ����")]
	[Space(20)]
	public float it_Hp;
	public float it_Atk;
	public float it_Def;

	float MaxHp;
	float MaxMp;
	float MaxSp;

	[Space(10)]
	[Header("�÷��̾� ����")]
	[Space(50)]
	public float hp = 1000;
	public float mana = 100;
	public float stamina = 100;

	[Space(10)]
	public bool isSick;

	private void Awake()
	{
		// �������ͽ� ���۷��� --------------------------------------------
		status = GameObject.FindGameObjectWithTag("Status").transform;

		txt_Hp = status.GetChild(1).GetComponent<Text>();
		txt_Mp = status.GetChild(2).GetComponent<Text>();
		txt_Sp = status.GetChild(3).GetComponent<Text>();

		txt_Atk = status.GetChild(4).GetComponent<Text>();
		txt_Def = status.GetChild(5).GetComponent<Text>();

		txt_Eq1 = status.GetChild(6).GetComponent<Text>();
		txt_Eq2 = status.GetChild(7).GetComponent<Text>();

		img_Eq1 = txt_Eq1.GetComponentInChildren<Image>();
		img_Eq2 = txt_Eq2.GetComponentInChildren<Image>();


		BuffPnl = status.GetChild(8);
		img_Sick = BuffPnl.GetChild(0).GetComponent<Image>();
	}

	private void Start()
	{
		isSick = true;
	}

	private void Update()
	{
		ShowSetting();

		ChangeStatus(eq1, eq2);

		if (hp > MaxHp)
		{
			hp = MaxHp;
		}

		if (mana > maxMp)
		{
			mana = maxMp;
		}

		if (stamina > maxSp)
		{
			stamina = maxSp;
		}
	}

	/// <summary>
	/// �������ͽ� UI����
	/// </summary>
	void ShowSetting()
	{
		MaxHp = maxHp + it_Hp;

		txt_Hp.text = "HP: " + hp.ToString("0,0") + "/" + (MaxHp).ToString("0,0");
		txt_Mp.text = "MP: " + mana.ToString("0,0") + "/" + maxMp.ToString("0,0");
		txt_Sp.text = "SP: " + stamina.ToString("0,0") + "/" + maxSp.ToString("0,0");

		txt_Atk.text = "ATK: " + (atk + it_Atk).ToString("0,0");
		txt_Def.text = "DEF: " + (def + it_Def).ToString("0,0");

		if (eq1 == null)
		{
			txt_Eq1.text = "����: ����";
			img_Eq1.sprite = defSpr;
		}
		else
		{
			txt_Eq1.text = "����: " + eq1.itemName;
			img_Eq1.sprite = eq1.itemSpr;
		}

		if (eq2 == null)
		{
			txt_Eq2.text = "��: ����";
			img_Eq2.sprite = defSpr;
		}

		else
		{
			txt_Eq2.text = "��: " + eq2.itemName;
			img_Eq2.sprite = eq2.itemSpr;
		}

		if (isSick)
		{
			img_Sick.sprite = sickSpr;
		}
		else
		{
			img_Sick.sprite = defSpr;
		}
	}

	void ChangeStatus(WeaponData _wp, ArmorData _am)
	{
		if (_wp == null && _am == null)
		{
			it_Hp = 0;
			it_Atk = 0;
			it_Def = 0;
		}
		else if (_am == null)
		{
			it_Hp = 0;
			it_Atk = _wp.Atk;
			it_Def = 0;
		}
		else if (_wp == null)
		{
			it_Hp = _am.MaxHpPlus;
			it_Atk = 0;
			it_Def = _am.Def;
		}
		else
		{
			it_Hp = _am.MaxHpPlus;
			it_Atk = _wp.Atk;
			it_Def = _am.Def;
		}
	}

	public void UneqWeapon()
	{
		if (eq1 != null)
			eq1 = null;
	}
	public void UneqArmor()
	{
		if (eq2 != null)
			eq2 = null;
	}

	/// <summary>
	/// ��ųʸ� �׽���
	/// </summary>
	public void Test()
	{
		foreach (var read in ItemDictionary.itemDic)
		{
			Debug.Log("Key: " + read.Key + ", Value: " + read.Value);
		}
	}
}
