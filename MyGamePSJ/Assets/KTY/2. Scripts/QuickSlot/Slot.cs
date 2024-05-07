using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    public GameObject ActiveImg;
    public SlotItem slotItem;
    public Text showTxt;

    bool isSelected = false; // ���� ����

    Color color;

    private void Awake()
	{
        slotItem = transform.GetComponentInChildren<SlotItem>();
        showTxt = transform.root.GetComponentInChildren<Text>();
    }
    // Start is called before the first frame update
    void Start()
    {
        SlotInit();
    }

    // Update is called once per frame
    void Update()
    {
		//if (slotItem.FullItem)
		//    child.gameObject.SetActive(true);
		//else
		//    child.gameObject.SetActive(false);
    }

    // ������ Ȱ��ȭ
    public void ActiveSlotState()
	{
        this.ActiveImg.SetActive(true);
        this.isSelected = true;

        showTxt.text = this.slotItem.ContentName;

        color.a = 255;
        showTxt.color = color;
    }

    // ������ ��Ȱ��ȭ
    public void DisabledSlotState()
	{
        this.ActiveImg.SetActive(false);
        this.isSelected = false;
    }

    IEnumerator FadeText()
	{
        yield return new WaitForSeconds(0.1f);
	}

	// ���� �ʱ�ȭ
	void SlotInit()
	{
        color = showTxt.color;
        color.r = 255;
        color.g = 255;
        color.b = 255;
        color.a = 0;
        showTxt.color = color;

        isSelected = false;
    }
}
