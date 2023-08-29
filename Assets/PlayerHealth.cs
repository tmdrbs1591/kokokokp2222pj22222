using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    private Animator animator;


    public Vector3 respawnPosition;
    public float respawnTime = 5f;

    public float flashDuration = 0.2f; // ���� ��ȭ �ð�
    private Color originalColor; // ���� ������ �����ϱ� ���� ����

    private SpriteRenderer spriteRenderer;
    private playermove playerController;
    private int originalLayer;

    private void Start()
    {
        currentHealth = maxHealth;
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalColor = spriteRenderer.color; // �ʱ� ���� ���� ����
        playerController = GetComponent<playermove>();
        originalLayer = gameObject.layer;
        animator = GetComponent<Animator>();
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        // ���ظ� ���� ��� �÷��̾��� ���� ���� �� ������ ���� �ڷ�ƾ ����
        StartCoroutine(DamageEffect());

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Debug.Log("Player has died!");
        playerController.enabled = false;
        gameObject.layer = LayerMask.NameToLayer("skill");
        animator.SetBool("IsDead", true); // Animator ������Ʈ�� �Ķ���� ����
        StartCoroutine(RespawnAfterDelay());
    }


    private IEnumerator RespawnAfterDelay()
    {
        yield return new WaitForSeconds(respawnTime);
        Respawn();
    }

    private void Respawn()
    {
        playerController.enabled = true;
        gameObject.layer = originalLayer;
        transform.position = respawnPosition;
        currentHealth = maxHealth;
        Debug.Log("Player has respawned!");
        animator.SetBool("IsDead", false); // Animator ������Ʈ�� �Ķ���� ����
    }


    private IEnumerator DamageEffect()
    {
        spriteRenderer.color = Color.red; // ���������� ����
        yield return new WaitForSeconds(flashDuration);
        spriteRenderer.color = originalColor; // ���� �������� ����
    }
}
