using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Followmouse : MonoBehaviour
{
    public Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        var pos = new Vector3(0, 0,0);
        pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        rb.position = new Vector2(pos.x,pos.y);
    }
}
