using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemSO", menuName = "Create_ItemData/Others", order =  23)] // CreateAssetMenu(defult ���ϸ�, �޴� �̸�, ����)
public class OtherItemData : ItemData
{
	public enum OthersType
	{
		none = 0,
	}


	[Header("���/��Ÿ ������")]
	[Space(20)]
	public OthersType othersType;
}
