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
    public Transform head;  // VR �÷��̾��� �Ӹ�(ī�޶�) ��ġ
    public float spawnDistance = 2.0f;  // �޴��� ������ �Ÿ�
    public GameObject UI_Menu;

    void Awake()
    {
        UI_Menu = GameObject.Find("VR UI_Menu");
    }

    void Start()
    {
        UI_Menu.SetActive(false);
        prevLeftValue = false; // �ʱ�ȭ
    }

    // Update is called once per frame
    void Update()
    {
        if (m_left.inputDevice.TryGetFeatureValue(CommonUsages.menuButton, out leftValue))
        {
            // �޴� ��ư�� ���� ���¿��� ���� ���¿� �ٸ� ���� ���
            if (leftValue && !prevLeftValue)
            {
                UI_Menu.SetActive(!UI_Menu.activeSelf);

                if (UI_Menu.activeSelf)
                {
                    // �Ӹ� �տ� �޴� ��ġ
                    PositionMenuInFrontOfHead();
                }
            }

            // ���� ���� ������Ʈ
            prevLeftValue = leftValue;
        }
    }

    void PositionMenuInFrontOfHead()
    {
        // �Ӹ��� ��ġ�� ȸ��
        Vector3 headPosition = head.position;
        Quaternion headRotation = head.rotation;

        // �Ӹ��� �������� spawnDistance ��ŭ ������ ��ġ ���
        Vector3 spawnPosition = headPosition + (headRotation * Vector3.forward * spawnDistance);

        // UI �޴��� ��ġ�� ȸ�� ����
        UI_Menu.transform.position = spawnPosition;
        UI_Menu.transform.rotation = Quaternion.Euler(0, headRotation.eulerAngles.y, 0);
    }
}
