using UnityEngine;

public class Wzdplayer : MonoBehaviour
{
    public float moveSpeed = 5.0f;
    public GameObject bulletPrefab; // �Ѿ� ������
    public GameObject fireballPrefab; // ���̾ ������
    public Transform firePoint; // �Ѿ� �߻� ����

    private Rigidbody2D rb;
    private Vector3 originalScale; // �ʱ� �������� ������ ����

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        originalScale = transform.localScale; // �ʱ� ������ ����
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
    }

    void SetFacingDirection(int direction)
    {
        transform.localScale = new Vector3(direction * Mathf.Abs(originalScale.x), originalScale.y, originalScale.z);
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
