using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField]
    private Slider hpbar;
    public int maxHealth = 100;
    public int currentHealth;
    private Animator animator;

    public Vector3 respawnPosition;
    public float respawnTime = 5f;

    public float flashDuration = 0.2f; // ���� ��ȭ �ð�
    private Color originalColor; // ���� ������ �����ϱ� ���� ����

    private SpriteRenderer spriteRenderer;
    private playermove playerController;
    private Wzdplayer wzdplayerController;
    private int originalLayer;

    private void Start()
    {
        currentHealth = maxHealth;
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalColor = spriteRenderer.color; // �ʱ� ���� ���� ����
        playerController = GetComponent<playermove>();
        wzdplayerController = GetComponent<Wzdplayer>();
        originalLayer = gameObject.layer;
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        HandleHp(); // ü�¹� ������Ʈ
    }

    private void HandleHp()
    {
        hpbar.value = (float)currentHealth / (float)maxHealth;
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
        if (currentHealth <= 1)
        {
            WzdDie();
        }

        HandleHp(); // ü�� ���� �� ü�¹� ������Ʈ
    }

    private void WzdDie()
    {
        Debug.Log("wzdPlayer has died!");

        wzdplayerController.enabled = false;
        gameObject.layer = LayerMask.NameToLayer("skill");
        animator.SetBool("IsDead", true); // Animator ������Ʈ�� �Ķ���� ����
        StartCoroutine(WzdRespawnAfterDelay());
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

    private IEnumerator WzdRespawnAfterDelay()
    {
        yield return new WaitForSeconds(respawnTime);
        WzdRespawn();
    }

    private void WzdRespawn()
    {
        wzdplayerController.enabled = true;
        gameObject.layer = originalLayer;
        transform.position = respawnPosition;
        currentHealth = maxHealth;
        Debug.Log("Player has respawned!");
        animator.SetBool("IsDead", false); // Animator ������Ʈ�� �Ķ���� ����
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

    public void RestoreHealth(int amount)
    {
        currentHealth += amount; // amount��ŭ ü�� ȸ��
        currentHealth = Mathf.Min(currentHealth, maxHealth); // �ִ� ü���� �ʰ����� �ʵ��� ����
    }
}
