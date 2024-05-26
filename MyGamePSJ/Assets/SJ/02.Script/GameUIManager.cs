using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUIManager : MonoBehaviour
{
    public static GameUIManager instance = null; // 싱글톤
    // [플레이어 스테이터스]
    public PlayerStateUI playStateUI;          // 체력
    public BossStateUI bossStateUI; // 보스 체력

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
        playStateUI.SetExp(0, playStateUI.maxExpUI);  // 경험치는 보통 0부터 시작

        bossStateUI.BossSetHp(bossStateUI.curBossHpUI, bossStateUI.maxBossHpUI);
    }

    // Update is called once per frame
    void Update()
    {
        // 누르면 체력감소 
        if (Input.GetKeyDown(KeyCode.Z))
        {
            playStateUI.TakeDamage(10);
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            playStateUI.UseSkill(20f); // 예시로 마나 20을 소모하는 스킬
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            bossStateUI.BossTakeDamage(15f); // 예시로 마나 20을 소모하는 스킬
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
