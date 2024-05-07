using UnityEngine;
using UnityEngine.UI;

public class BossHealthText : MonoBehaviour
{
    public Text BossHpPercent; // ���� ü���� ǥ���� UI Text

    private void Start()
    {
        // ������ ü�� ���� �̺�Ʈ�� UI ������Ʈ �Լ��� ����
        FindObjectOfType<Boss>().OnHealthChanged.AddListener(UpdateHealthText);
    }

    private void UpdateHealthText(float currentHealth)
    {
        // ������ ���� ü���� UI Text�� ǥ��
        BossHpPercent.text = "Boss Health: " + currentHealth.ToString();
    }
}
