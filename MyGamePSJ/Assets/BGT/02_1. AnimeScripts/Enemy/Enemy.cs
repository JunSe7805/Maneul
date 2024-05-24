using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public MeshRenderer lifeBar;
    public GameObject _player;
    public Transform VRPlayer;
    public Transform charaterBody;
    Animator anime;

    [field:SerializeField]
    public float _range { get; private set; }
    public float _rangespeed;
    public float _speed;
    public float _curHp;
    public float _maxHp;

    public Vector3 originPos;

    // 플레이어가 맞게끔
    public PlayerStateUI playStateUI;
    public float damage = 10.0f;

    public float invincibilltyDuration = 2.0f;  // 무적 지속시간
    private bool isInvincible = false; // 무적 상태 인지 여부
    void Awake()
    {
        anime = GetComponent<Animator>();
        playStateUI = FindObjectOfType<PlayerStateUI>();
        VRPlayer = GameObject.FindGameObjectWithTag("VRPlayer").GetComponent<Transform>();
        
    }

    void Start()
    {
        originPos = transform.position;
        _curHp = _maxHp;
        anime.SetBool("isAlive", true);
        //GameUIManager.instance.playerHpUI.UpdateHpUI();
    }

    void OnTriggerEnter(Collider col)
    {
        // 플레이어 맞게
        if(col.gameObject.tag == "Player")
        {
            Debug.Log(damage);
            //_player.TakeDamage(damage);
        }
        // 히트판정
        if(col.gameObject.tag == "Arrow" && _curHp > 0)
        {
            Arrow arrow = col.GetComponent<Arrow>();
            _curHp -= arrow.damage;
            lifeBar.material.SetFloat("_Progress", _curHp / 100.0f);
            StartCoroutine(Damage());
            // 무적 판정
            StartCoroutine(Invincible());
        }

        if(col.gameObject.tag == "VRSword" && _curHp > 0)
        {
            VRSword vrsword = col.GetComponent<VRSword>();
            _curHp -= vrsword.damage;
            lifeBar.material.SetFloat("_Progress", _curHp / 100.0f);
            StartCoroutine(Damage());
            StartCoroutine(Invincible());
        }
        if (col.gameObject.tag == "Skill" && _curHp > 0)
        {
            Debug.Log("SkillHit");
            Skill skill = col.GetComponent<Skill>();
            _curHp -= skill.damage;
            lifeBar.material.SetFloat("_Progress", _curHp / 100.0f);
            StartCoroutine(Damage());
        }


    }
    //public void Attack()
    //{
    //    _player.Damage();
    //}

    IEnumerator Damage()
    {
        anime.SetTrigger("isHit");
        yield return new WaitForSeconds(2.0f);

        if (_curHp <= 0)
        {
            StartCoroutine(Die());
        }
    }

    IEnumerator Die()
    {
        anime.SetBool("isAlive", false);
        anime.SetBool("isDie", true);
        this.gameObject.GetComponent<CapsuleCollider>().enabled = false;
        yield return new WaitForSeconds(10f);
        Destroy(this.gameObject);
    }
    // 무적
    IEnumerator Invincible()
    {
        isInvincible = true; // 무적 상태 전환
        yield return new WaitForSeconds(invincibilltyDuration);
        isInvincible = false; // 무적 상태 해제
    }
}
