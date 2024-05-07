using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
 * ���Կ� ���콺�� ���� ��� ȣ��Ǵ� "�ش� ������ ������ �ߴ� ��ũ��Ʈ"
 */

public class FollowWindow : MonoBehaviour
{
    /* �̱��� */
    public static FollowWindow instance; 

    RectTransform rec; // �ڱ� ��ġ

    Vector3 mousePos; // ���콺 ��ġ ��ǥ

    Transform hidePivot; // �������� ���

    Transform defTr; // �⺻ ��ġ

    bool isShow; // ���̱� ����(�������� �̵��ϴ� �� ������ ����)

	#region *������ ����
	ItemData _data;
    public ItemData Data
	{
        // ������ �����⸸ �� �״� get�� ����x
		set { _data = value; }
	}

    [SerializeField] Image img;
    [SerializeField] Text itmName;
    [SerializeField] Text itmTxt;
	#endregion

	private void Awake()
	{
        instance = this;
        rec = GetComponent<RectTransform>();

        hidePivot = GameObject.FindGameObjectWithTag("PopupPivot").transform;
	}

	private void Start()
	{
        defTr = transform.parent;
        transform.SetParent(hidePivot);
	}


	// Update is called once per frame
	void Update()
    {
		if (_data != null)
		{
            img.sprite = _data.itemSpr;
            itmName.text = _data.itemName;
            itmTxt.text = _data.description;
        }

		if (isShow)
		{
            mousePos = Input.mousePosition;
            rec.position = mousePos;
        }
    }

    // â ����
    public void ShowWindow()
	{
        transform.SetParent(defTr);
        isShow = true;
    }

    // â �ݱ�
    public void CloseWindow()
	{
        transform.SetParent(hidePivot);
        isShow = false;
    }
}
