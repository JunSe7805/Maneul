using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class LoadingSceneManager : MonoBehaviour
{
    public static string next1Scene;
    public static string next2Scene;

    [SerializeField]
    Image progressBar;

    private float time = 0f;
    public static void LoadScene(string sceneName)
    {
        next1Scene = sceneName;
        SceneManager.LoadScene("LobbyLoading");
    }
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(LoadSceneProcess());
    }

    IEnumerator LoadSceneProcess()
    {
        AsyncOperation op = SceneManager.LoadSceneAsync(next1Scene);
        op.allowSceneActivation = false;

        float timer = 0f;
        while (timer < 5f)
        {
            // ���� �ε� ���� ��Ȳ�� ����մϴ�.
            float progress = Mathf.Clamp01(timer / 5f);

            // �ε� ���� ��Ȳ�� ǥ���մϴ�.
            progressBar.fillAmount = progress;

            timer += Time.deltaTime;
            yield return null;
        }
        op.allowSceneActivation = true;
    }
 }

