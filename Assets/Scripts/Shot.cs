using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : MonoBehaviour
{
    public float lifetime;
    private float start;
    public Rigidbody2D rb;


    // Start is called before the first frame update
    void Start()
    {
        start = Time.time;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time-start >= lifetime)
        {
            Destroy(this.gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Boid")
        {
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }
    }
}