using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerHp : MonoBehaviour
{
    public float Thp = 10;
    private SpriteRenderer spriteRenderer;
    private Color originalColor; // 원래 색상을 저장하기 위한 변수
    public float flashDuration = 0.2f; // 색상 변화 시간
 

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalColor = spriteRenderer.color;
    }

    public void TakeDamage(int damage)
    {
        Thp -= damage;

        StartCoroutine(DamageEffect());
        if (Thp <= 0)
        {
            Destroy(gameObject);
        }
    }

    private IEnumerator DamageEffect()
    {
        spriteRenderer.color = Color.red;
        yield return new WaitForSeconds(flashDuration);
        spriteRenderer.color = originalColor;
    }
}
