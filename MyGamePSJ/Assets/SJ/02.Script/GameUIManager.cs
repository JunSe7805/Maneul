using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUIManager : MonoBehaviour
{
    public static GameUIManager instance = null; // �̱���
    // [�÷��̾� �������ͽ�]
    public PlayerStateUI playStateUI;          // ü��
    public BossStateUI bossStateUI; // ���� ü��
    public PartyStateUI partyStateUI;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            if(instance != this)
            {
                Destroy(this.gameObject);
            }
        }
        //playStateUI = GameObject.FindGameObjectWithTag("State").GetComponent<PlayerStateUI>();
    }
    // Start is called before the first frame update
    void Start()
    {    
        playStateUI.SetHp(playStateUI.curHpUI, playStateUI.maxHpUI);
        playStateUI.SetMp(playStateUI.curMpUI, playStateUI.maxMpUI);
        playStateUI.SetSp(playStateUI.curSpUI, playStateUI.maxSpUI);
        playStateUI.SetExp(0, playStateUI.maxExpUI);  // ����ġ�� ���� 0���� ����

        bossStateUI.BossSetHp(bossStateUI.curBossHpUI, bossStateUI.maxBossHpUI);

        partyStateUI.PartySetHp(partyStateUI.mCurHpUI, partyStateUI.mMaxHpUI);
    }

    // Update is called once per frame
    void Update()
    {
        // ������ ü�°��� 
        if (Input.GetKeyDown(KeyCode.Z))
        {
            playStateUI.TakeDamage(10);
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            playStateUI.UseSkill(20f); // ���÷� ���� 20�� �Ҹ��ϴ� ��ų
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            bossStateUI.BossTakeDamage(15f); // ���÷� ���� 20�� �Ҹ��ϴ� ��ų
        }
        if (Input.GetKeyDown(KeyCode.B))
        {
            partyStateUI.PartyTakeDamage(20f); // ���÷� ���� 20�� �Ҹ��ϴ� ��ų
        }
    }

    //public void PlayerHpUI(float curHpUI, float maxHpUI)
    //{
    //    playStateUI.curHpUI = curHpUI;
    //    playStateUI.maxHpUI = maxHpUI;
    //}
    //public void PlayerMpUI(float curMpUI, float maxMpUI)
    //{
    //    playStateUI.curMpUI = curMpUI;
    //    playStateUI.maxMpUI = maxMpUI;
    //}
    //public void PlayerSpUI(float curSpUI, float maxSpUI)
    //{
    //    playStateUI.curSpUI = curSpUI;
    //    playStateUI.maxSpUI = maxSpUI;
    //}
    //public void PlayerExpUI(float curExpUI, float maxExpUI)
    //{
    //    playStateUI.curExpUI = curExpUI;
    //    playStateUI.maxExpUI = maxExpUI;
    //}
}
