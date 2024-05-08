using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossSetActive : MonoBehaviour
{
    public Image BossHp_Border;
    public GameObject player;
    public GameObject Test;
    public float activationDistance = 5f; // Ȱ��ȭ �Ÿ�

    // Start is called before the first frame update
    void Awake()
    {
        // �̹��� ������Ʈ�� ã�� BossHp_Border�� �Ҵ�
        BossHp_Border = GetComponent<Image>();
        player = GameObject.FindGameObjectWithTag("Player");
        Test = GameObject.FindGameObjectWithTag("Test");
    }

    // ui ����
    void Start()
    {
        BossHp_Border.gameObject.SetActive(false);
    }

    // �ٽ�Ȱ��
    // Update is called once per frame
    void Update()
    {
        // �÷��̾�� Test ������Ʈ ������ �Ÿ��� ���
        float distance = Vector3.Distance(player.transform.position, Test.transform.position);

        // �÷��̾ Test ������Ʈ ��ó�� �ִ��� ���θ� ������Ʈ
        bool isPlayerNearTest = distance < activationDistance;

        // BossHpUI�� Ȱ��ȭ
        if (isPlayerNearTest && Input.GetKeyDown(KeyCode.X))
        {
            // "BossHpUI" GameObject�� ã�Ƽ� Ȱ��ȭ
            Transform bossHpUI = transform.Find("BossHpUI");
            if (bossHpUI != null)
            {
                bossHpUI.gameObject.SetActive(true);
            }
            else
            {
                Debug.LogError("BossHpUI�� ã�� �� �����ϴ�.");
            }
        }

        // BossHp_Border GameObject�� ��Ȱ��ȭ
        if (Input.GetKeyDown(KeyCode.Z))
        {
            BossHp_Border.gameObject.SetActive(false);
        }
    }
}
