using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorMover : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody2D rb;
    public Screenwrap sw;
    public bool spin;

    void Start()
    {
        var randovec = new Vector2(Random.Range(-2.0f, 2.0f),Random.Range(-2.0f,2.0f));
        rb.velocity = randovec;
        if (spin)
        {
            rb.AddTorque(Random.Range(-10.0f, 10.0f));
        }
    }
}
