using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BossUI_OnOff : MonoBehaviour
{
    public GameObject Boss;
    public GameObject player;
    public GameObject Point;
    public float activationDistance = 60.0f;

    private void Awake()
    {
        Boss = GameObject.FindGameObjectWithTag("Boss");
        player = GameObject.FindGameObjectWithTag("Player");
        Point = GameObject.FindGameObjectWithTag("Point");
    }
    // Start is called before the first frame update
    void Start()
    {
        Boss.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null && Point != null)
        {
            float distance = Vector3.Distance(player.transform.position, Point.transform.position);
            if (distance <= activationDistance)
            {
                Boss.SetActive(true);
            }
            else
            {
                Boss.SetActive(false);
            }
        }
    }
    void ShowUI()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            Boss.gameObject.SetActive(true);
        }
    }
}
