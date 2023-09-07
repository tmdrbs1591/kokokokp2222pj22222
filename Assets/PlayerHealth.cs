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

    public float flashDuration = 0.2f; // 색상 변화 시간
    private Color originalColor; // 원래 색상을 저장하기 위한 변수

    private SpriteRenderer spriteRenderer;
    private playermove playerController;
    private Wzdplayer wzdplayerController;
    private int originalLayer;

    private void Start()
    {
        currentHealth = maxHealth;
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalColor = spriteRenderer.color; // 초기 원래 색상 저장
        playerController = GetComponent<playermove>();
        wzdplayerController = GetComponent<Wzdplayer>();
        originalLayer = gameObject.layer;
        animator = GetComponent<Animator>();
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

        // 피해를 입은 경우 플레이어의 색상 변경 및 복구를 위한 코루틴 실행
        StartCoroutine(DamageEffect());

        if (currentHealth <= 0)
        {
            Die();
        }
        if (currentHealth <= 1)
        {
            WzdDie();
        }

        HandleHp(); // 체력 감소 후 체력바 업데이트
    }

    private void WzdDie()
    {
        Debug.Log("wzdPlayer has died!");

        wzdplayerController.enabled = false;
        gameObject.layer = LayerMask.NameToLayer("skill");
        animator.SetBool("IsDead", true); // Animator 컴포넌트의 파라미터 설정
        StartCoroutine(WzdRespawnAfterDelay());
    }

    private void Die()
    {
        Debug.Log("Player has died!");
        playerController.enabled = false;

        gameObject.layer = LayerMask.NameToLayer("skill");
        animator.SetBool("IsDead", true); // Animator 컴포넌트의 파라미터 설정
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
        animator.SetBool("IsDead", false); // Animator 컴포넌트의 파라미터 설정
    }

    private void Respawn()
    {
        playerController.enabled = true;
        gameObject.layer = originalLayer;
        transform.position = respawnPosition;
        currentHealth = maxHealth;
        Debug.Log("Player has respawned!");
        animator.SetBool("IsDead", false); // Animator 컴포넌트의 파라미터 설정
    }

    private IEnumerator DamageEffect()
    {
        spriteRenderer.color = Color.red; // 빨간색으로 변경
        yield return new WaitForSeconds(flashDuration);
        spriteRenderer.color = originalColor; // 원래 색상으로 복구
    }

    public void RestoreHealth(int amount)
    {
        currentHealth += amount; // amount만큼 체력 회복
        currentHealth = Mathf.Min(currentHealth, maxHealth); // 최대 체력을 초과하지 않도록 제한
    }
}
