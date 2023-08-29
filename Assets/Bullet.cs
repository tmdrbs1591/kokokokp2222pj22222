using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10.0f;
    public float lifeTime = 2.0f; // �Ѿ��� ����

    private float direction = 1.0f; // �Ѿ� ���� (1 ������, -1 ����)

    private void Start()
    {
        // ������ �ٵǸ� �ڵ����� ����
        Destroy(gameObject, lifeTime);
    }

    private void Update()
    {
        // �Ѿ��� ������ �������� �̵�
        transform.Translate(Vector2.right * direction * speed * Time.deltaTime);

        // ���⿡ ���� �Ѿ��� �������� �����Ͽ� �ø�
        if (direction < 0)
        {
            Vector3 newScale = transform.localScale;
            newScale.x = Mathf.Abs(newScale.x) * -1;
            transform.localScale = newScale;
        }
    }

    public void SetDirection(float newDirection)
    {
        direction = newDirection;
    }

    // �Ѿ� ũ�⸦ �����ϴ� �޼ҵ�
    public void SetSize(Vector3 newSize)
    {
        transform.localScale = newSize;
    }

    // �浹 ó��
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Monster monster = collision.GetComponent<Monster>();
            if (monster != null)
            {
                monster.TakeDamage(1); // ������ ü���� ���ҽ�Ŵ
                Destroy(gameObject); // �Ѿ��� ����
            }
        }
    }
}
