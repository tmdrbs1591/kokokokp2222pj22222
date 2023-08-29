using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    private SpriteRenderer spriteRenderer;
    private Color originalColor; // 원래 색상을 저장하기 위한 변수
    public float flashDuration = 0.2f; // 색상 변화 시간

    private void Start()
    {
        currentHealth = maxHealth;
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalColor = spriteRenderer.color;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        StartCoroutine(DamageEffect());

        if (currentHealth <= 0)
        {

        }
    }

    private IEnumerator DamageEffect()
    {
        spriteRenderer.color = Color.red; 
        yield return new WaitForSeconds(flashDuration);
        spriteRenderer.color = originalColor; 
    }
}
