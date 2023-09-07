using UnityEngine;
using System.Collections;
public class Monster : MonoBehaviour
{
    [SerializeField]
    private GameObject coin;

    public float moveSpeed = 3f;
    public float deathDelay = 1.5f;
    public AudioClip hitSound;
    public AudioClip deathSound;
    private AudioSource audioSource;
    public float hitSoundVolume = 0.5f;
    public float deathSoundVolume = 1.0f;
    private Animator animator;
    private Transform player;
    private Transform playertower;
    public float Hp = 10;

    private bool isDying = false;
    private float originalMoveSpeed;
    private bool isSlowed = false;
    private bool isPlayerInAttackRange = false;
    private bool isPlayerTowerInAttackRange = false;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        playertower = GameObject.FindGameObjectWithTag("playertower").transform;

        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        originalMoveSpeed = moveSpeed;
    }

    private void Update()
    {
        if (!isDying && Hp > 0)
        {
            Vector3 moveDirection = (playertower.position - transform.position).normalized;
            transform.Translate(moveDirection * moveSpeed * Time.deltaTime);

            // 몬스터가 플레이어를 향하도록 스케일 조정
            if (moveDirection.x > 0)
                transform.localScale = new Vector3(-4f, 4f, 4f); // 스케일을 반전하여 좌우 방향 변경
            else if (moveDirection.x < 0)
                transform.localScale = new Vector3(4f, 4f, 4f);


        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!isDying && (collision.gameObject.CompareTag("Player")))
        {
            isPlayerInAttackRange = true; // 플레이어가 공격 범위 내에 있음을 표시
            StartCoroutine(AttackCoroutine()); // 일정 주기로 공격하는 코루틴 실행



        }
        else if (!isDying && (collision.gameObject.CompareTag("playertower")))
        {
            isPlayerTowerInAttackRange = true;
            StartCoroutine(TowerAttackCoroutine());
        }
    }
    

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isPlayerInAttackRange = false; // 플레이어가 공격 범위 밖으로 나감을 표시
        }

        if (collision.gameObject.CompareTag("playertower"))
        {
            isPlayerTowerInAttackRange = false; // 플레이어가 공격 범위 밖으로 나감을 표시
        }

    }
    private IEnumerator AttackCoroutine()
    {
        while (isPlayerInAttackRange)
        {
            animator.SetTrigger("Attack");
            yield return new WaitForSeconds(attackInterval);


            PlayerHealth playerHealth = player.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(1);
            }
        }
    }
    private IEnumerator TowerAttackCoroutine()
    {
        while (isPlayerTowerInAttackRange)
        {
            animator.SetTrigger("Attack");
            yield return new WaitForSeconds(attackInterval);


            TowerHealth towerHealth = playertower.GetComponent<TowerHealth>();
            if (towerHealth != null)
            {
                towerHealth.TakeDamage(1);
            }
        }
    }
    private float attackInterval = 0.62f;

    public void TakeDamage(int damage)
    {
        if (isDying) return;

        Hp -= damage;

        if (Hp <= 0)
        {
            Hp = 0;
            Die();
            Instantiate(coin, transform.position,Quaternion.identity);

        }
        else
        {
            if (!isSlowed)
            {
                isSlowed = true;
                moveSpeed *= 0.5f;
                Invoke(nameof(ResetSpeed), 1f);
            }

            animator.SetTrigger("Hit");
            PlayHitSound();

            Vector2 knockbackDirection = transform.position - player.position; // 플레이어 쪽으로 넉백
            Knockback(knockbackDirection);
        }
    }

    private void Knockback(Vector2 direction)
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.velocity = direction.normalized * 2.5f; // 적절한 넉백 강도 설정
    }

    private void ResetSpeed()
    {
        isSlowed = false;
        moveSpeed = originalMoveSpeed;
    }

    private void Die()
    {
        isDying = true;
        animator.SetTrigger("Die");
        PlayDeathSound();
        PlayHitSound();
        StartCoroutine(DestroyWithDelay(deathDelay));
    }
    private IEnumerator DestroyWithDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(gameObject);
    }
    private void Disappear()
    {
        gameObject.SetActive(false);
    }

    private void PlayHitSound()
    {
        if (hitSound != null && audioSource != null)
        {
            audioSource.volume = hitSoundVolume;
            audioSource.PlayOneShot(hitSound);
        }
    }

    private void PlayDeathSound()
    {
        if (deathSound != null && audioSource != null)
        {
            audioSource.volume = deathSoundVolume;
            audioSource.PlayOneShot(deathSound);
        }
    }
}