using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHpUI : MonoBehaviour
{
    [SerializeField] private Image Hp;       // ü�¹� �̹��� 
    [SerializeField] private Text HpText; // ü�� �ؽ�Ʈ

    private float currentHp;
    private float maxHp = 100f;

    private void Start()
    {
        currentHp = maxHp;
        UpdateHpUI();
        //HpPercent.text = Hp.fillAmount.ToString();
    }

    public void PlayerHpBar()
    {
        Image HpBarImg = GameObject.FindGameObjectsWithTag("State")[0].GetComponent<Image>();

        if (HpBarImg != null)
        {
            float fillAmount = 40.0f / 100.0f; // �ӽ� ������ ����
            HpBarImg.fillAmount = fillAmount; // ü�¿� �°� fillAmount ����

            // ü�� �ؽ�Ʈ ������Ʈ
            HpText.text = Mathf.RoundToInt(fillAmount * 100f) + "%";
        }
    }

    // ü�� UI ������Ʈ
    public void UpdateHpUI()
    {
        float fillAmount = currentHp / maxHp;
        Hp.fillAmount = fillAmount;
        HpText.text = Mathf.RoundToInt(fillAmount * 100f) + "%";
    }


}