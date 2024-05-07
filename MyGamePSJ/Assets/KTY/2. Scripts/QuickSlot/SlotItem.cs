using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlotItem : MonoBehaviour
{
    public bool FullItem = false;
    Image itemImg;

    string contentName;

    // ������ �̸��� �о���� ���� ������Ƽ?
    public string ContentName
	{
		get { return contentName; }
	}


	private void Awake()
	{
        itemImg = GetComponent<Image>();
	}
	// Start is called before the first frame update
	void Start()
    {
		if (itemImg.sprite == null)
		{
            this.contentName = "None";
        }
		else
		{
            this.contentName = itemImg.sprite.name;
		}
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
