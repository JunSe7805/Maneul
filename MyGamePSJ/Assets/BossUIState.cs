using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossUIState : MonoBehaviour
{
    public GameObject Boss_UI;
    public GameObject player;
    public GameObject Test; // 3������ ���� ������Ʈ
    public float activationDistance = 5f; // Ȱ��ȭ �Ÿ�
    private bool isPlayerNearTest = false; // �÷��̾ Test ������Ʈ ��ó�� �ִ��� ���θ� ��Ÿ���� ����

    // Start is called before the first frame update
    void Start()
    {
        Boss_UI = GameObject.Find("Boss_UI").GetComponent<GameObject>();
        player = GameObject.Find("Player").GetComponent<GameObject>();
        Test = GameObject.FindGameObjectWithTag("Test");
    }

    // Update is called once per frame
    void Update()
    {
        // �÷��̾�� Test ������Ʈ ������ �Ÿ��� ���
        float distance = Vector3.Distance(player.transform.position, Test.transform.position);

        // �÷��̾ Test ������Ʈ ��ó�� �ִ��� ���θ� ������Ʈ
        isPlayerNearTest = distance < activationDistance;

        // �÷��̾ Test ������Ʈ ��ó�� �ִٸ� Boss_UI�� ��Ȱ��ȭ
        if (isPlayerNearTest)
        {
            Boss_UI.SetActive(true);
            Debug.Log(1);
        }
        else
        {
            Boss_UI.SetActive(false);
            Debug.Log(2);
        }
    }
}
