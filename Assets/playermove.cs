using UnityEngine;
using System.Collections;

public class playermove : MonoBehaviour
{
    public float moveSpeed = 5.0f;
    public float dashSpeed = 10f;
    public float dashDuration = 0.2f;
    private bool isDashing = false;
    private float dashTimer = 0f;
    public Transform pos;
    public Transform pos2;
    public Vector2 boxSize;
    public Vector2 boxSize2;
    public Vector2 boxSize3;

    private Rigidbody2D rb;
    private Animator anim;
    private float curTime;
    public float coolTime = 0.5f;
    public float jumpPower;
    public float qSkillVolume = 0.5f;
    public AudioClip rSkillSound;
    public float rSkillSoundVolume = 0.5f;


    public AudioClip swordSwingSound;
    public AudioClip qSkillSound;
    public AudioClip dashSound;
    public AudioClip wSkillSound;
    private AudioSource audioSource;

    public float dashSoundVolume = 0.5f;
    public float wSkillSoundVolume = 0.5f;

    private int originalLayer; // 플레이어의 원래 레이어를 저장하는 변수

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        originalLayer = gameObject.layer; // 플레이어의 원래 레이어 저장
    }

    private void Update()
    {
        if (Input.GetButtonDown("Jump") && !anim.GetBool("isjumping"))
        {
            rb.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            anim.SetBool("isjumping", true);
        }

        float moveDirection = Input.GetAxis("Horizontal");

        if (Input.GetKeyDown(KeyCode.E) && !isDashing)
        {
            isDashing = true;
            dashTimer = dashDuration;

            PlayDashSound();
        }

        if (isDashing)
        {
            dashTimer -= Time.deltaTime;
            rb.velocity = new Vector2(moveDirection * dashSpeed, rb.velocity.y);

            if (dashTimer <= 0)
            {
                isDashing = false;
            }
        }
        else
        {
            rb.velocity = new Vector2(moveDirection * moveSpeed, rb.velocity.y);
        }

        if (moveDirection < 0)
        {
            transform.localScale = new Vector3(-4, 4, 4);
        }
        else if (moveDirection > 0)
        {
            transform.localScale = new Vector3(4, 4, 4);
        }

        if (Mathf.Abs(rb.velocity.x) < 0.5f)
        {
            anim.SetBool("run", false);
        }
        else
        {
            anim.SetBool("run", true);
        }

        if (curTime <= 0)
        {
            if (!anim.GetBool("isjumping") && Input.GetKey(KeyCode.F))
            {
               

                Collider2D[] collider2Ds = Physics2D.OverlapBoxAll(pos.position, boxSize, 0);
                foreach (Collider2D collider in collider2Ds)
                {
                    if (collider.tag == "Enemy")
                    {
                        collider.GetComponent<Monster>().TakeDamage(1);
                    }
                }
                anim.SetTrigger("atk");
                PlaySwordSwingSound();
                curTime = coolTime;
              
            }
           
        }
        else
        {
            curTime -= Time.deltaTime;
        }

        if (curTime <= 0)
        {
            if (Input.GetKey(KeyCode.Q))
            {
                gameObject.layer = LayerMask.NameToLayer("skill");


                Collider2D[] collider2Ds = Physics2D.OverlapBoxAll(pos.position, boxSize2, 0);
                foreach (Collider2D collider in collider2Ds)
                {
                    if (collider.tag == "Enemy")
                    {
                        collider.GetComponent<Monster>().TakeDamage(1);
                    }
                }
                anim.SetTrigger("Qsk");
                curTime = coolTime;
                StartCoroutine(DealDamageOverTime(1, 0.7f, 0.1f));

                PlayQSFX();

                StartCoroutine(ResetPlayerLayer(2f));
            }
        }
        else
        {
            curTime -= Time.deltaTime;
        }
        if (curTime <= 0)
        {
            if (!anim.GetBool("isjumping") && Input.GetKey(KeyCode.R))
            {
                anim.SetTrigger("Rsk");
                curTime = coolTime;
                PlayRSFX();
            }
        }
        else
        {
            curTime -= Time.deltaTime;
        }

        if (curTime <= 0)
        {
            if (Input.GetKey(KeyCode.E) && Input.GetAxis("Horizontal") != 0)
            {

                gameObject.layer = LayerMask.NameToLayer("skill");

                anim.SetTrigger("Esk");
                curTime = coolTime;

                StartCoroutine(ResetPlayerLayer(2f));

            }
        }
        else
        {
            curTime -= Time.deltaTime;
        }

        if (curTime <= 0)
        {
            if (Input.GetKey(KeyCode.W))
            {
                gameObject.layer = LayerMask.NameToLayer("skill");

                Collider2D[] collider2Ds = Physics2D.OverlapBoxAll(pos2.position, boxSize3, 0);
                foreach (Collider2D collider in collider2Ds)
                {
                    if (collider.tag == "Enemy")
                    {
                        collider.GetComponent<Monster>().TakeDamage(1);
                    }
                }

                anim.SetTrigger("Wsk");
                curTime = coolTime;
                StartCoroutine(DealDamageOverTime(1, 0.7f, 0.1f));

                PlayWSFX();
                StartCoroutine(ResetPlayerLayer(2f));


            }
        }
        else
        {
            curTime -= Time.deltaTime;
        }
    }
    private void PlaySwordSwingSound()
    {
        if (swordSwingSound != null && audioSource != null)
        {
            audioSource.PlayOneShot(swordSwingSound);
        }
    }

    private void PlayQSFX()
    {
        if (qSkillSound != null && audioSource != null)
        {
            audioSource.PlayOneShot(qSkillSound, qSkillVolume);
        }
    }

    private void PlayDashSound()
    {
        if (dashSound != null && audioSource != null)
        {
            audioSource.volume = dashSoundVolume;
            audioSource.PlayOneShot(dashSound);
        }
    }

    private void PlayWSFX()
    {
        if (wSkillSound != null && audioSource != null)
        {
            audioSource.volume = wSkillSoundVolume;
            audioSource.PlayOneShot(wSkillSound);
        }
    }
    private void PlayRSFX()
    {
        if (rSkillSound != null && audioSource != null)
        {
            audioSource.volume = rSkillSoundVolume;
            audioSource.PlayOneShot(rSkillSound);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(pos.position, boxSize);
    }

    private void FixedUpdate()
    {
        if (rb.velocity.y < 0)
        {
            Debug.DrawRay(rb.position, Vector3.down, new Color(0, 1, 0));
            RaycastHit2D rayHit = Physics2D.Raycast(rb.position, Vector3.down, 1, LayerMask.GetMask("platform"));
            if (rayHit.collider != null && rayHit.distance < 4f)
            {
                anim.SetBool("isjumping", false);
            }
        }
    }

    IEnumerator DealDamageOverTime(int damageAmount, float totalDuration, float interval)
    {
        float timer = 0f;

        while (timer < totalDuration)
        {
            Collider2D[] collider2Ds = Physics2D.OverlapBoxAll(pos.position, boxSize2, 0);

            foreach (Collider2D collider in collider2Ds)
            {
                if (collider.tag == "Enemy")
                {
                    collider.GetComponent<Monster>().TakeDamage(damageAmount);
                }
            }

            timer += interval;
            yield return new WaitForSeconds(interval);
        }
    }

    // 플레이어의 레이어를 원래대로 되돌리는 코루틴
    private IEnumerator ResetPlayerLayer(float delay)
    {
        yield return new WaitForSeconds(delay);
        gameObject.layer = originalLayer;
    }
}

