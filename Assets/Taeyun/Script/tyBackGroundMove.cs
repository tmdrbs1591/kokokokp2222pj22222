using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tyBackGroundMove : MonoBehaviour
{
    Rigidbody2D rb;
    public float movespeed;
    public GameObject obj;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        rb.velocity = new Vector2(-movespeed, rb.velocity.y);//리지디드바디에 벨로시티값을 내가 정한 벡터값으로 수정(왼쪽으로 가니까 -)
    }
    private void OnBecameInvisible()//오브젝트가 메인카메라 밖으로 나갔을떄 실행하는 함수
    {
        obj.transform.position = new Vector3(26.41f, 0f, 0f);
    }
}
