using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossUI : MonoBehaviour
{
    [SerializeField] private Image bHp;       // ü�¹� �̹��� 
    [SerializeField] private Text bHpText; // ü�� �ؽ�Ʈ

    private float b_currentHp;
    private float b_maxHp = 100f;

    private void Start()
    {
        b_currentHp = b_maxHp;
        UpdateBossHpUI();
        //HpPercent.text = Hp.fillAmount.ToString();

    }

    public void BossUIHpBar()
    {
        Image bHpBarImg = GameObject.FindGameObjectWithTag("BossUI").GetComponent<Image>();

        if (bHpBarImg != null)
        {
            float fillAmount = 40.0f / 100.0f; // �ӽ� ������ ����
            bHpBarImg.fillAmount = fillAmount; // ü�¿� �°� fillAmount ����

            // ü�� �ؽ�Ʈ ������Ʈ
            bHpText.text = Mathf.RoundToInt(fillAmount * 100f) + "%";
        }
    }

    // ü�� UI ������Ʈ
    public void UpdateBossHpUI()
    {
        float fillAmount = b_currentHp / b_maxHp;
        bHp.fillAmount = fillAmount;
        bHpText.text = Mathf.RoundToInt(fillAmount * 100f) + "%";
    }


}