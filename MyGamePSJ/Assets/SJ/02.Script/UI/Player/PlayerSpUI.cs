using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSpUI : MonoBehaviour
{
    // ü��
    private float _Sp;

    public void PlayerSpBar()
    {
        Image SpBarImg = GameObject.FindGameObjectsWithTag("State")[2].GetComponent<Image>();

        if (SpBarImg != null)
        {
            _Sp = 90.0f; // ü���� 40���� ����
            SpBarImg.fillAmount = _Sp / 100.0f; // ü�¿� �°� fillAmount ����
        }
    }
}
