using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public float damage;

    void Start()
    {
    }
    private void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "Enemy")
        {
            
            Debug.Log("Hit");
        }
    }
}
