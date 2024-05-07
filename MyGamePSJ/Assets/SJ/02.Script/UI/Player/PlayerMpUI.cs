using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMpUI : MonoBehaviour
{
    [SerializeField] private Image Mp;
    [SerializeField] private Text MpText;

    // ����
    private float currentMp;
    private float maxMp = 100f;

    public void PlayerMpBar()
    {
        Image MpBarImg = GameObject.FindGameObjectsWithTag("State")[1].GetComponent<Image>();

        if (MpBarImg != null)
        {
            float fillAmount = 30.0f / 100.0f; // �ӽ� ������ ����
            MpBarImg.fillAmount = fillAmount; // ü�¿� �°� fillAmount ����

            // ���� �ؽ�Ʈ ������Ʈ
            MpText.text = Mathf.RoundToInt(fillAmount * 100f) + "%";
        }
    }

    // ü�� UI ������Ʈ
    public void UpdateMpUI()
    {
        float fillAmount = currentMp / maxMp;
        Mp.fillAmount = fillAmount;
        MpText.text = Mathf.RoundToInt(fillAmount * 100f) + "%";
    }
}
