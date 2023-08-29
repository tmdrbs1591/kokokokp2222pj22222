using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10.0f;
    public float lifeTime = 2.0f; // 총알의 수명

    private float direction = 1.0f; // 총알 방향 (1 오른쪽, -1 왼쪽)

    private void Start()
    {
        // 수명이 다되면 자동으로 삭제
        Destroy(gameObject, lifeTime);
    }

    private void Update()
    {
        // 총알을 적절한 방향으로 이동
        transform.Translate(Vector2.right * direction * speed * Time.deltaTime);

        // 방향에 따라 총알의 스케일을 조정하여 플립
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

    // 총알 크기를 설정하는 메소드
    public void SetSize(Vector3 newSize)
    {
        transform.localScale = newSize;
    }

    // 충돌 처리
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Monster monster = collision.GetComponent<Monster>();
            if (monster != null)
            {
                monster.TakeDamage(1); // 몬스터의 체력을 감소시킴
                Destroy(gameObject); // 총알을 삭제
            }
        }
    }
}
