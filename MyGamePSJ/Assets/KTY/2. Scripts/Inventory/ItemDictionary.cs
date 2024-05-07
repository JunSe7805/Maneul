using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDictionary
{
	/// <summary>
	/// ������ ��ųʸ� = ������ ������ ��ȣ�� Ű�� ����
	/// </summary>
	public static Dictionary<int, ItemData> itemDic = new Dictionary<int, ItemData>();

	/// <summary>
	/// ������ �߰�
	/// </summary>
	/// <param name="_id">Ű��</param>
	/// <param name="_item">������ ������</param>
	public static void SetData(int _id, ItemData _item)
	{
		itemDic.Add(_id, _item);
	}

	/// <summary>
	/// ������ �˻�
	/// </summary>
	/// <param name="_id">Ű��</param>
	/// <returns></returns>
	public static bool CheckData(int _id)
	{
		if (itemDic.ContainsKey(_id))
		{
			return true;
		}
		else
		{
			return false;
		}
	}

	///// <summary>
	///// ������ ����
	///// </summary>
	///// <param name="_num"></param>
	//public void RemoveData(int _num)
	//{
	//	itemDic.Remove(_num);
	//}
}
