using UnityEngine;

public class MiniMapFollow : MonoBehaviour
{
    public Transform player; // �÷��̾��� Transform
    public Vector3 offset; // �̴ϸ� ī�޶��� ��ġ ������

    void LateUpdate()
    {
        // �÷��̾��� ��ġ�� �������� �̴ϸ��� ��ġ�� ������Ʈ
        if (player != null)
        {
            transform.position = player.position + offset;
        }
    }
}