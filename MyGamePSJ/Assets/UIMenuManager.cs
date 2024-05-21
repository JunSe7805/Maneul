using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class UIMenuManager : MonoBehaviour
{
    public GameObject UI_Menu;
    public InputActionProperty showButton;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // 액션 도트가 이 프레임을 눌렀을때.
        if(showButton.action.WasPressedThisFrame())
        {
            UI_Menu.SetActive(!UI_Menu.activeSelf);
        }
    }
}
