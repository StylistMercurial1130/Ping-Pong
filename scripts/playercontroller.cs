using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playercontroller : MonoBehaviour
{
    public Rigidbody2D rb;
    public float moveSpeed;
    private float YInput;
    public KeyCode up;
    public KeyCode down;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        YInput = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate()
    {
        if (Input.GetKey(up))
            rb.velocity = moveSpeed * Vector2.up * Time.deltaTime;
        else
            if (Input.GetKey(down))
                rb.velocity = Vector2.down * moveSpeed * Time.deltaTime;
            else
                rb.velocity = Vector2.zero;
    }
}

