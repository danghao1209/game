using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAndBossMovement : MonoBehaviour
{
    Rigidbody2D rb;
    public Transform player;
    public float moveSpeed;
    private bool hasCollided = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.Find("Characters").transform;
    }

    void Update()
    {
        // Tính hướng di chuyển từ đối tượng hiện tại đến người chơi
        Vector2 directionToPlayer = (player.position - transform.position).normalized;

        if (!hasCollided)
        {
            // Xác định hướng nhìn của đối tượng
            UpdateCharacterDirection(directionToPlayer);
        }

        // Áp dụng tốc độ di chuyển
        Vector2 move = directionToPlayer * moveSpeed;

        // Thay đổi vận tốc của Rigidbody
        rb.velocity = move;
    }

    void UpdateCharacterDirection(Vector2 direction)
    {
        if (direction.x > 0)
        {
            // Di chuyển sang phải, xoay 0 độ theo trục Y
            RotateY(0);
        }
        else if (direction.x < 0)
        {
            // Di chuyển sang trái, xoay 180 độ theo trục Y
            RotateY(180);
        }
    }

    void RotateY(float angle)
    {
        // Đặt giá trị Y rotation theo giá trị angle
        transform.rotation = Quaternion.Euler(0,angle, 0);
    }
}
