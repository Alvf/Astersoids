﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketMvmnt : MonoBehaviour
{
    // Start is called before the first frame update
    public float rotsp = 180f;
    public float thrust = 5f;
    public float speedmax = 100f;
    public float slowtime = 3f;

    public Rigidbody2D rb;

    Vector2 direction;
    private Vector2 velo;

//Start is called at the start
    void Start()
    {
        direction = Vector2.up;
        velo = Vector2.zero;
    }

    // Update is called once per frame
    void Update()
    {
        rb.rotation -= rotsp * Input.GetAxis("Horizontal") * Time.deltaTime;
        direction.x = Mathf.Cos((rb.rotation+90)*Mathf.Deg2Rad);
        direction.y = Mathf.Sin((rb.rotation+90)*Mathf.Deg2Rad);

        if (Input.GetAxis("Vertical") == 1)
        {
            rb.velocity += thrust * direction * Time.deltaTime;
        }

        rb.velocity = Vector2.SmoothDamp(rb.velocity, Vector2.zero, ref velo, slowtime, speedmax);

        screenwrap();
    }
    void screenwrap()
    {
        if (rb.position.x > 9)
        {
            rb.MovePosition(new Vector2(rb.position.x - 18,rb.position.y));
        }
        if (rb.position.x < -9)
        {
            rb.MovePosition(new Vector2(rb.position.x + 18, rb.position.y));
        }
        if (rb.position.y > 5)
        {
            rb.MovePosition(new Vector2(rb.position.x,rb.position.y - 10));
        }
        if (rb.position.y < -5)
        {
            rb.MovePosition(new Vector2(rb.position.x, rb.position.y + 10));
        } 
    }
}