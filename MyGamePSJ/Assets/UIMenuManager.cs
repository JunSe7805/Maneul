using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class UIMenuManager : MonoBehaviour
{
    bool leftValue;
    bool prevLeftValue;
    [SerializeField] XRController m_left;
    public Transform head;  // VR 플레이어의 머리(카메라) 위치
    public float spawnDistance = 2.0f;  // 메뉴가 생성될 거리
    public GameObject UI_Menu;

    void Awake()
    {
        UI_Menu = GameObject.Find("VR UI_Menu");
    }

    void Start()
    {
        UI_Menu.SetActive(false);
        prevLeftValue = false; // 초기화
    }

    // Update is called once per frame
    void Update()
    {
        if (m_left.inputDevice.TryGetFeatureValue(CommonUsages.menuButton, out leftValue))
        {
            // 메뉴 버튼이 눌린 상태에서 이전 상태와 다를 때만 토글
            if (leftValue && !prevLeftValue)
            {
                UI_Menu.SetActive(!UI_Menu.activeSelf);

                if (UI_Menu.activeSelf)
                {
                    // 머리 앞에 메뉴 배치
                    PositionMenuInFrontOfHead();
                }
            }

            // 이전 상태 업데이트
            prevLeftValue = leftValue;
        }
    }

    void PositionMenuInFrontOfHead()
    {
        // 머리의 위치와 회전
        Vector3 headPosition = head.position;
        Quaternion headRotation = head.rotation;

        // 머리의 앞쪽으로 spawnDistance 만큼 떨어진 위치 계산
        Vector3 spawnPosition = headPosition + (headRotation * Vector3.forward * spawnDistance);

        // UI 메뉴의 위치와 회전 설정
        UI_Menu.transform.position = spawnPosition;
        UI_Menu.transform.rotation = Quaternion.Euler(0, headRotation.eulerAngles.y, 0);
    }
}
