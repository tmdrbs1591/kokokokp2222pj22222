using UnityEngine;

public class Coin : MonoBehaviour
{
    private Rigidbody2D rigidBody;

    private void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        Jump();
    }

    void Jump()
    {
        float randomJumpForce = Random.Range(4f, 6f);
        Vector2 jumpVelocity = new Vector2(Random.Range(-1f, 1f), randomJumpForce);
        rigidBody.AddForce(jumpVelocity, ForceMode2D.Impulse);
    }

    private void Update()
    {
        if (transform.position.y <= -4.2f)
        {
            rigidBody.constraints = RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezePositionX; // X, Y 프리즘 켜주기
        }
    }
}
