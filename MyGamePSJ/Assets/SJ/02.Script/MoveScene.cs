using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MoveScene : MonoBehaviour
{
    void Start()
    {
       LoadUIScene();
    }

    public void SceneChange()
    {
        SceneManager.LoadScene("UI", LoadSceneMode.Additive);
    }

    void LoadUIScene()
    {
        // ���� "UI" ���� �ε��ߴ��� Ȯ�� ��, �̹� �ε�� ���¶�� �߰������� �ε����� ����
        if (!SceneManager.GetSceneByName("UI").isLoaded)
        {
            SceneManager.LoadScene("UI", LoadSceneMode.Additive);
        }
    }
}
