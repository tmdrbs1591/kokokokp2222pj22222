using UnityEngine;

public class  bird  : MonoBehaviour
{
    public float speed = 2.0f; // 이동 속도
    public float delay = 2.0f;

    void Start()
    {
        // 왼쪽 방향으로 이동합니다.
        Vector2 moveDirection = Vector2.left;

        // Rigidbody2D 컴포넌트를 가져와서 이동합니다.
        Rigidbody2D rb2d = GetComponent<Rigidbody2D>();
        rb2d.velocity = moveDirection * speed;

        // 일정 시간 후에 오브젝트를 파괴하여 사라지게 만듭니다.
        Destroy(gameObject, delay);
    }
}
