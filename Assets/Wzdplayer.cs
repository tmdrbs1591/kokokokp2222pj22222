using UnityEngine;

public class Wzdplayer : MonoBehaviour
{
    public float moveSpeed = 5.0f;
    public GameObject bulletPrefab; // �Ѿ� ������
    public GameObject fireballPrefab; // ���̾ ������

    public Transform firePoint; // �Ѿ�, ���̾ �߻� ����
    public GameObject laserPrefab; // ������ ������
    public Transform laserSpawnPoint; // ������ �߻� ����
    public AudioClip thunderSound;
    public float soundVolume = 0.5f;
    public AudioClip WSound; 
    private PlayerHealth playerHealthScript;
    private AudioSource audioSource;


    private Rigidbody2D rb;
    private Vector3 originalScale; // �ʱ� �������� ������ ����

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {

            audioSource = gameObject.AddComponent<AudioSource>();
        }
        audioSource.clip = thunderSound;
        audioSource.volume = soundVolume;
        playerHealthScript = GetComponent<PlayerHealth>();
        rb = GetComponent<Rigidbody2D>();
        originalScale = transform.localScale; // �ʱ� ������ ����
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Coin")
        {
            GameManager.instance.IncreaseCoin();
            Destroy(other.gameObject);
        }
    }
    void PlayRSound()
    {
        if (thunderSound != null && audioSource != null)
        {
            audioSource.PlayOneShot(thunderSound);
        }
    }
    void PlayWSound()
    {
        if (thunderSound != null && audioSource != null)
        {
            audioSource.PlayOneShot(WSound);
        }
    }

    private void Update()
    {
      

        float moveDirection = Input.GetAxis("Horizontal"); // -1(left) ~ 1(right)

        Vector2 movement = new Vector2(moveDirection * moveSpeed, rb.velocity.y);
        rb.velocity = movement;


        if (moveDirection < 0)
        {
            SetFacingDirection(-1); // �������� �̵��ϴ� ���
        }
        else if (moveDirection > 0)
        {
            SetFacingDirection(1); // ���������� �̵��ϴ� ���
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            ShootBullet();
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            ShootFireball();
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            int missingHealth = 10 - playerHealthScript.currentHealth; // �ִ�ġ�� 10���� ���� ü���� �� ��
            int healthToRestore = Mathf.Min(missingHealth, 3); // �ִ� 5��ŭ ü���� ȸ���ϰų�, ������ ��ŭ�� ȸ��

            playerHealthScript.RestoreHealth(healthToRestore); // ȸ������ŭ ü�� ȸ��
            PlayWSound();
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            ShootLaser();
            PlayRSound();
        }
    }

    void SetFacingDirection(int direction)
    {
        transform.localScale = new Vector3(direction * Mathf.Abs(originalScale.x), originalScale.y, originalScale.z);
    }
    void ShootLaser()
    {
        float laserDirection = Mathf.Sign(transform.localScale.x);

        GameObject laser = Instantiate(laserPrefab, laserSpawnPoint.position, Quaternion.identity);
        Laser laserScript = laser.GetComponent<Laser>();

        laserScript.SetDirection(laserDirection);
    }

    void ShootBullet()
    {
        float bulletDirection = Mathf.Sign(transform.localScale.x);

        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Bullet bulletScript = bullet.GetComponent<Bullet>();

        bulletScript.SetDirection(bulletDirection);
    }

    void ShootFireball()
    {
        float fireballDirection = Mathf.Sign(transform.localScale.x);

        GameObject fireball = Instantiate(fireballPrefab, firePoint.position, firePoint.rotation);
        Fireball fireballScript = fireball.GetComponent<Fireball>();

        fireballScript.SetDirection(fireballDirection);
    }

 
}
