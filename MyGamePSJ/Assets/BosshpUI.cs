using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BosshpUI : MonoBehaviour
{
    public Image BossHp_Border;
    public GameObject player;
    public float activationDistance = 5f; // Ȱ��ȭ �Ÿ�

    // Start is called before the first frame update
    void Awake()
    {
        // �̹��� ������Ʈ�� ã�� BossHp_Border�� �Ҵ�
        BossHp_Border = GetComponent<Image>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // ui ����
    void Start()
    {
        BossHp_Border.gameObject.SetActive(false);
    }

    // �ٽ�Ȱ��
    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Debug.Log("GetKeyDown(KeyCode.Z)");
            Debug.Log("BossHp_Border: " + BossHp_Border.gameObject.activeSelf);
            BossHp_Border.gameObject.SetActive(true);
            Debug.Log("BossHp_Border: " + BossHp_Border.gameObject.activeSelf);
        }
    }
}
