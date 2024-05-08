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
//        // Boss_UI를 찾아서 RectTransform으로 설정
//        Boss_UI = GameObject.Find("Boss_UI").GetComponent<RectTransform>();
//        player = GameObject.FindGameObjectWithTag("Player");
//        Test = GameObject.FindGameObjectWithTag("Test");

//        // 초기 상태에서는 Boss_UI를 활성화 상태로 설정
//        SetBossUIActive(true);
//    }

//    void Update()
//    {
//        // 플레이어와 Test 오브젝트 사이의 거리를 계산
//        float distance = Vector3.Distance(player.transform.position, Test.transform.position);

//        // 플레이어가 Test 오브젝트 근처에 있는지 여부를 업데이트
//        isPlayerNearTest = distance < activationDistance;

//        // Boss_UI의 활성화 상태를 업데이트
//        SetBossUIActive(isPlayerNearTest);
//    }

//    // Boss_UI의 활성화 상태를 설정하는 함수
//    void SetBossUIActive(bool active)
//    {
//        if (Boss_UI != null && Boss_UI.gameObject.activeSelf != active)
//        {
//            Boss_UI.gameObject.SetActive(active);
//            Debug.Log(active ? "Boss_UI 활성화" : "Boss_UI 비활성화");
//        }
//    }
//}
