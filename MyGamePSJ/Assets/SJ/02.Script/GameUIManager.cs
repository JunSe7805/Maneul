using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUIManager : MonoBehaviour
{
    public static GameUIManager instance = null; // �̱���
    // [�÷��̾� �������ͽ�]
    [SerializeField] private PlayerHpUI playerHpUI;          // ü��
    [SerializeField] private Text HpPercent; // ü�� �ؽ�Ʈ
    [SerializeField] public PlayerMpUI  playerMpUI;          // ����
    [SerializeField] private PlayerSpUI  playerSpUI;          // ���¹̳�
    [SerializeField] private PlayerExpUI playerExpUI;         // ����ġ

    // �÷��̾� ��ų
    [SerializeField] private PlayerSkillUI playerSkiUI; // �÷��̾� ��ų 1��

    // ��Ƽ ��ų
    [SerializeField] private PartyHpUI_1 partyHpUI_1; // ��Ƽ ü��1��
    //[SerializeField] private PartyHpUI_2 partyHpUI_2; // ��Ƽ ü��2��

    // ���� UI
    [SerializeField] private BossUI bossUI;

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
        #region �÷��̾� UI
        playerHpUI = GameObject.Find("Hp").GetComponent<PlayerHpUI>();
        HpPercent = GameObject.Find("HpPercent").GetComponent<Text>();
        playerMpUI  = GameObject.Find("Mp").GetComponent<PlayerMpUI>();
        playerSpUI  = GameObject.Find("SpImg").GetComponent<PlayerSpUI>();
        playerExpUI = GameObject.Find("Prograss").GetComponent<PlayerExpUI>();
        playerSkiUI = GameObject.Find("BuffDelay").GetComponent<PlayerSkillUI>();
        #endregion

        #region ��Ƽ UI
        partyHpUI_1 = GameObject.Find("pHp").GetComponent<PartyHpUI_1>();
        //partyHpUI_2 = GameObject.Find("pHp1").GetComponent<PartyHpUI_2>();
        #endregion

        #region ���� UI
        bossUI = GameObject.Find("BossHpUI").GetComponent<BossUI>();
        #endregion
    }
    // Start is called before the first frame update
    void Start()
    {
        #region �÷��̾� UI Start
        GameUIManager.instance.playerHpUI.PlayerHpBar();
        GameUIManager.instance.playerMpUI.PlayerMpBar();

        GameUIManager.instance.playerSpUI.PlayerSpBar();

        GameUIManager.instance.playerExpUI.PlayerExpBar();

        GameUIManager.instance.playerSkiUI.PlayerSkiUIBar();
        #endregion

        #region ��Ƽ UI Start
        GameUIManager.instance.partyHpUI_1.PartyHpBar();
        //UIManager.instance.partyHpUI_2.PartyHpBar();
        #endregion

        #region ���� UI Start
        GameUIManager.instance.bossUI.BossUIHpBar();
        #endregion
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
