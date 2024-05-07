using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerExpUI : MonoBehaviour
{
    // ����ġ
    private float _Exp;

    public void PlayerExpBar()
    {
        Image ExpBarImg = GameObject.FindGameObjectWithTag("Exp").GetComponent<Image>();

        if (ExpBarImg != null)
        {
            _Exp = 70.0f; // ü���� 40���� ����
            ExpBarImg.fillAmount = _Exp / 100.0f; // ü�¿� �°� fillAmount ����
        }
    }
}
