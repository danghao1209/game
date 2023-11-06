using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public DynamicJoystick dynamicJoystick;

    Rigidbody2D rb;

    Vector2 move;
    public float moveSpeed;
    public static bool PointerDown = false;
    private bool hasCollided = false;
    public Animator anim;
    private void Awake()
    {
        GameObject player = GameObject.Find("Player1");
        GameObject player2 = GameObject.Find("Player2");
        if (player != null)
        {
            anim = player.GetComponent<Animator>();
            moveSpeed = Character1Stats.Instance.speed_run;
        }
        else if(player2 != null)
        {
            anim = player2.GetComponent<Animator>();
            moveSpeed = Character2Stats.Instance.speed_run;
        }
        else
        {
            Debug.LogError("Không tìm thấy Player.");
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        move.x = dynamicJoystick.Horizontal;
        move.y = dynamicJoystick.Vertical;

        if (hasCollided)
        {
            // Nếu đã va chạm, không thay đổi hướng xoay
        }
        else
        {
            // Chưa va chạm, xác định hướng mà nhân vật nhìn
            UpdateCharacterDirection();
        }

        // Đặt giá trị rotation trên trục Z thành 0
        transform.rotation = Quaternion.Euler(0f, 0f, 0f);


        // Animation
        if (Mathf.Abs(move.x) != 0 || Mathf.Abs(move.y) != 0)
        {
            anim.SetFloat("movePl", 1);
        }
        else
        {
            anim.SetFloat("movePl", 0);
        }
       
    }

    private void FixedUpdate()
    {
        if (PointerDown)
        {
            rb.position = Vector3.zero;
        }
        else
        {
            rb.MovePosition(rb.position + move * moveSpeed * Time.fixedDeltaTime);
        }
    }

    void UpdateCharacterDirection()
    {
        if (move.x > 0)
        {
            // Di chuyển sang phải, xoay mặt sang phải
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if (move.x < 0)
        {
            // Di chuyển sang trái, xoay mặt sang trái
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Object")
        {
            // Đã va chạm với đối tượng "Object"
            hasCollided = true;

            // Ngăn chặn xoay
            rb.freezeRotation = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Object")
        {
            // Rời khỏi va chạm với đối tượng "Object"
            hasCollided = false;

            // Cho phép xoay trở lại
            rb.freezeRotation = false;
        }
    }
}
