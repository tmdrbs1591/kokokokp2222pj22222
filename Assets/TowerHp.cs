using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerHp : MonoBehaviour
{
    public float Thp = 10;
    private SpriteRenderer spriteRenderer;
    private Color originalColor; // ���� ������ �����ϱ� ���� ����
    public float flashDuration = 0.2f; // ���� ��ȭ �ð�
 

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
