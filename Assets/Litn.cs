using UnityEngine;


public class Litn : MonoBehaviour
{


private void OnTriggerEnter2D(Collider2D collision)
{
    if (collision.CompareTag("Enemy"))
    {
        Monster monster = collision.GetComponent<Monster>();
        if (monster != null)
          {   
            monster.TakeDamage(7); // ������ ü���� ���ҽ�Ŵ

         }
        }
    }
}