using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerHealth : MonoBehaviour
{
    [SerializeField]
    private Slider hpbar;
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
    void Update()
    {
        HandleHp(); // 체력바 업데이트
    }

    private void HandleHp()
    {
        hpbar.value = (float)currentHealth / (float)maxHealth;
    }
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        StartCoroutine(DamageEffect());

        if (currentHealth <= 0)
        {

        }
        HandleHp();
    }

    private IEnumerator DamageEffect()
    {
        spriteRenderer.color = Color.red; 
        yield return new WaitForSeconds(flashDuration);
        spriteRenderer.color = originalColor; 
    }
}
