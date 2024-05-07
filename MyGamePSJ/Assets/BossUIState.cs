using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossUIState : MonoBehaviour
{
    public GameObject Boss_UI;
    public GameObject player;
    public GameObject Test; // 3페이즈 게임 오브젝트
    public float activationDistance = 5f; // 활성화 거리
    private bool isPlayerNearTest = false; // 플레이어가 Test 오브젝트 근처에 있는지 여부를 나타내는 변수

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
        // 플레이어와 Test 오브젝트 사이의 거리를 계산
        float distance = Vector3.Distance(player.transform.position, Test.transform.position);

        // 플레이어가 Test 오브젝트 근처에 있는지 여부를 업데이트
        isPlayerNearTest = distance < activationDistance;

        // 플레이어가 Test 오브젝트 근처에 있다면 Boss_UI를 비활성화
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
