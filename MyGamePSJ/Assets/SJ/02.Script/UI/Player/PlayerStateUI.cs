using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStateUI : MonoBehaviour
{
    // �÷��̾� ü��
    public float curHpUI;
    public float maxHpUI;
    // �÷��̾� ����
    public float curMpUI;
    public float maxMpUI;
    // �÷��̾� ���
    public float curSpUI;
    public float maxSpUI;
    // �÷��̾� ����ġ
    public float curExpUI;
    public float maxExpUI;

    private Image[] stateImgUI;
    private Text[] stateTextUI;
    private void Start()
    {
        curHpUI  = maxHpUI;
        curMpUI  = maxMpUI;
        curSpUI  = maxSpUI;
        curExpUI = maxExpUI;

        //stateImgUI = GameObject.FindGameObjectsWithTag("State").Select(go => go.GetComponent<Image>()).ToArray();
        //stateTextUI = GameObject.FindGameObjectsWithTag("pUIText").Select(go => go.GetComponent<Text>()).ToArray();

        //UpdateAllUI();
    }

    private void Update()
    {
        SetHp(70,100);
        SetMp(50, 100);
        SetSp(10, 100);
        SetExp(10, 100);
    }
    public void TakeDamage(float damage)
    {
        curHpUI -= damage;
        curHpUI = Mathf.Clamp(curHpUI, 100, maxHpUI);
    }

    // �÷��̾� ü�� ����
    public void SetHp(float curHpUI, float maxHpUI)
    {
        this.curHpUI = curHpUI;
        this.maxHpUI = maxHpUI;
        PlayerHpBar();
    }
    public void SetMp(float curMpUI, float maxMpUI)
    {
        this.curMpUI = curMpUI;
        this.maxMpUI = maxMpUI;
        PlayerMpBar();
    }
    public void SetSp(float curSpUI, float maxSpUI)
    {
        this.curSpUI = curSpUI;
        this.maxSpUI = maxSpUI;
        PlayerSpBar();
    }
    public void SetExp(float curExpUI, float maxExpUI)
    {
        this.curExpUI = curExpUI;
        this.maxExpUI = maxExpUI;
        PlayerExpBar();
    }
    public void PlayerHpBar()
    {
        Image HpBarImg = GameObject.FindGameObjectsWithTag("State")[0].GetComponent<Image>();
        Text HpText = GameObject.FindGameObjectsWithTag("pUIText")[0].GetComponent<Text>();
        if (HpBarImg != null)
        {
            float fillAmount = curHpUI / maxHpUI;
            HpBarImg.fillAmount = fillAmount; // ü�¿� �°� fillAmount ����

            // ü�� �ؽ�Ʈ ������Ʈ
            HpText.text = Mathf.RoundToInt(fillAmount * 100f) + "%";
        }
    }

    public void PlayerMpBar()
    {
        Image MpBarImg = GameObject.FindGameObjectsWithTag("State")[1].GetComponent<Image>();
        Text MpText = GameObject.FindGameObjectsWithTag("pUIText")[1].GetComponent<Text>();
        if (MpBarImg != null)
        {
            float fillAmount = curMpUI / maxMpUI;
            MpBarImg.fillAmount = fillAmount; // ü�¿� �°� fillAmount ����

            // ���� �ؽ�Ʈ ������Ʈ
            MpText.text = Mathf.RoundToInt(fillAmount * 100f) + "%";
        }
    }

    public void PlayerSpBar()
    {
        Image SpBarImg = GameObject.FindGameObjectsWithTag("State")[2].GetComponent<Image>();
        if (SpBarImg != null)
        {
            float fillAmount = curSpUI / maxSpUI;
            SpBarImg.fillAmount = fillAmount; // ü�¿� �°� fillAmount ����
        }
    }

    public void PlayerExpBar()
    {
        Image ExpBarImg = GameObject.FindGameObjectsWithTag("State")[3].GetComponent<Image>();
        Text ExpText = GameObject.FindGameObjectWithTag("pUIText").GetComponent<Text>();
        if (ExpBarImg != null)
        {
            float fillAmount = curExpUI / maxExpUI;
            ExpBarImg.fillAmount = fillAmount; // ü�¿� �°� fillAmount ����

            // ü�� �ؽ�Ʈ ������Ʈ
            ExpText.text = Mathf.RoundToInt(fillAmount * 100f) + "%";
        }
    }
}