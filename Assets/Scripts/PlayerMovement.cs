using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    public float jumpForce;

    Rigidbody2D player;
    bool isGround = true;
    Vector3 moveDiff;        // movement difference
    Vector3 oldMoveDiff;

    void Start()
    {
        player = gameObject.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        moveDiff = new Vector2(0f, 0f);

        if (Input.GetKey(KeyCode.W))
        {
            moveDiff.x += 1;
        }
        if (Input.GetKey(KeyCode.S))
        {
            moveDiff.x -= 1;
        }
        if (Input.GetKey(KeyCode.A))
        {
            moveDiff.y += 1;
        }
        if (Input.GetKey(KeyCode.D))
        {
            moveDiff.y -= 1;
        }

        transform.position += moveDiff;                           // Перемещение игрока на расчитанное расстояние
    }
}
