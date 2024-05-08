using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossSetActive : MonoBehaviour
{
    public Image BossHp_Border;
    public GameObject player;
    public GameObject Test;
    public float activationDistance = 5f; // 활성화 거리

    // Start is called before the first frame update
    void Awake()
    {
        // 이미지 컴포넌트를 찾아 BossHp_Border에 할당
        BossHp_Border = GetComponent<Image>();
        player = GameObject.FindGameObjectWithTag("Player");
        Test = GameObject.FindGameObjectWithTag("Test");
    }

    // ui 끄기
    void Start()
    {
        BossHp_Border.gameObject.SetActive(false);
    }

    // 다시활성
    // Update is called once per frame
    void Update()
    {
        // 플레이어와 Test 오브젝트 사이의 거리를 계산
        float distance = Vector3.Distance(player.transform.position, Test.transform.position);

        // 플레이어가 Test 오브젝트 근처에 있는지 여부를 업데이트
        bool isPlayerNearTest = distance < activationDistance;

        // BossHpUI를 활성화
        if (isPlayerNearTest && Input.GetKeyDown(KeyCode.X))
        {
            // "BossHpUI" GameObject를 찾아서 활성화
            Transform bossHpUI = transform.Find("BossHpUI");
            if (bossHpUI != null)
            {
                bossHpUI.gameObject.SetActive(true);
            }
            else
            {
                Debug.LogError("BossHpUI를 찾을 수 없습니다.");
            }
        }

        // BossHp_Border GameObject를 비활성화
        if (Input.GetKeyDown(KeyCode.Z))
        {
            BossHp_Border.gameObject.SetActive(false);
        }
    }
}
