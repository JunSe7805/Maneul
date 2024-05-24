using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateOnOff : MonoBehaviour
{
    public GameObject Player;
    public GameObject VRplayer;

    void Awake()
    {
        Player = GameObject.Find("Player");
        VRplayer = GameObject.Find("VRplayer");
    }

    void Start()
    {
        // �ʱ� ���� ����: VRplayer Ȱ��ȭ, Player ��Ȱ��ȭ
        SetPlayerState(false);
    }

    void Update()
    {
        // Ű���� �Է��� ���� VRplayer�� Player�� ����մϴ�.
        if (Input.GetKeyDown(KeyCode.V))
        {
            // ���� ���¸� �������� ���
            SetPlayerState(!VRplayer.activeSelf);
        }
    }

    private void SetPlayerState(bool isPlay)
    {
        VRplayer.SetActive(isPlay);
        Player.SetActive(!isPlay);
    }
}
