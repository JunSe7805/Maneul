//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.UI;

//public class BossUIState : MonoBehaviour
//{
//    public RectTransform Boss_UI;
//    public GameObject player;
//    public GameObject Test;
//    public float activationDistance = 5f;
//    private bool isPlayerNearTest = false;

//    void Start()
//    {
//        // Boss_UI�� ã�Ƽ� RectTransform���� ����
//        Boss_UI = GameObject.Find("Boss_UI").GetComponent<RectTransform>();
//        player = GameObject.FindGameObjectWithTag("Player");
//        Test = GameObject.FindGameObjectWithTag("Test");

//        // �ʱ� ���¿����� Boss_UI�� Ȱ��ȭ ���·� ����
//        SetBossUIActive(true);
//    }

//    void Update()
//    {
//        // �÷��̾�� Test ������Ʈ ������ �Ÿ��� ���
//        float distance = Vector3.Distance(player.transform.position, Test.transform.position);

//        // �÷��̾ Test ������Ʈ ��ó�� �ִ��� ���θ� ������Ʈ
//        isPlayerNearTest = distance < activationDistance;

//        // Boss_UI�� Ȱ��ȭ ���¸� ������Ʈ
//        SetBossUIActive(isPlayerNearTest);
//    }

//    // Boss_UI�� Ȱ��ȭ ���¸� �����ϴ� �Լ�
//    void SetBossUIActive(bool active)
//    {
//        if (Boss_UI != null && Boss_UI.gameObject.activeSelf != active)
//        {
//            Boss_UI.gameObject.SetActive(active);
//            Debug.Log(active ? "Boss_UI Ȱ��ȭ" : "Boss_UI ��Ȱ��ȭ");
//        }
//    }
//}
