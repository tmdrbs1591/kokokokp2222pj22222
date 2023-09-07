using UnityEngine;
using System.Collections;

public class Laser : MonoBehaviour
{
    public float speed = 10.0f;
    public float lifeTime = 0.6f; // 총알의 수명

    private float direction = 1.0f; // 총알 방향 (1 오른쪽, -1 왼쪽)

    private void Start()
    {
        // 수명이 다되면 자동으로 삭제
        Destroy(gameObject, lifeTime);
    }

    private void Update()
    {
       

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
                StartCoroutine(ApplyDamageWithDelay(monster, 0.2f)); // 0.5초 뒤에 피 효과 적용
            }
        }
    }

    private IEnumerator ApplyDamageWithDelay(Monster monster, float delay)
    {
        yield return new WaitForSeconds(delay); // 일정 시간 대기

        monster.TakeDamage(100); // 몬스터의 체력을 감소시킴
    }
}

