using UnityEngine;

public class  bird  : MonoBehaviour
{
    public float speed = 2.0f; // �̵� �ӵ�
    public float delay = 2.0f;

    void Start()
    {
        // ���� �������� �̵��մϴ�.
        Vector2 moveDirection = Vector2.left;

        // Rigidbody2D ������Ʈ�� �����ͼ� �̵��մϴ�.
        Rigidbody2D rb2d = GetComponent<Rigidbody2D>();
        rb2d.velocity = moveDirection * speed;

        // ���� �ð� �Ŀ� ������Ʈ�� �ı��Ͽ� ������� ����ϴ�.
        Destroy(gameObject, delay);
    }
}
